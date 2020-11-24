using Data.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.DTOs;
using Service.DTOs.AppSettings;
using Service.DTOs.User;
using Service.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly IUserRepository _userRepository;
		private readonly JwtSettings _jwtSettings;

		public AuthenticationService(
			UserManager<IdentityUser> userManager,
			SignInManager<IdentityUser> signInManager,
			IUserRepository userRepository,
			IOptions<JwtSettings> jwtSettings)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_userRepository = userRepository;
			_jwtSettings = jwtSettings.Value;
		}

		public async Task<string> GenerateJwt(string userLogin)
		{
			var user = await _userRepository.GetAsync(userLogin);
			var role = Role.Parse(user.Role);

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = _jwtSettings.Issuer,
				Audience = _jwtSettings.Audience,
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Login),
					new Claim(ClaimTypes.Role, role.AsString())
				}),
				Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiresInHours),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key), 
					SecurityAlgorithms.HmacSha256Signature
				)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public async Task RegisterNewUserAsync(UserInputDto userInputDto)
		{
			var identityUser = new IdentityUser(userInputDto.Login);
			var creationResult = await _userManager.CreateAsync(identityUser, userInputDto.Password);

			if (!creationResult.Succeeded)
				throw new ApplicationException(string.Join("\n", creationResult.Errors.Select(error => error.Description)));

			var addToRoleResult =  await _userManager.AddToRoleAsync(identityUser, userInputDto.Role);
			if (!addToRoleResult.Succeeded)
				throw new ApplicationException(string.Join("\n", creationResult.Errors.Select(error => error.Description)));
		}

		public async Task<bool> Login(AuthenticationInputDto authenticationInputDto)
		{
			var signInResult = await _signInManager.PasswordSignInAsync(authenticationInputDto.Login, authenticationInputDto.Password, true, true);
			return signInResult.Succeeded;
		}
	}
}
