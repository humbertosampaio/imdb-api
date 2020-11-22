using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Get()
		{
			var users = await _userService.GetAll();
			return Ok(users);
		}
	}
}
