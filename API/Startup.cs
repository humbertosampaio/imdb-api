using Autofac;
using Data;
using Data.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.DTOs.AppSettings;
using System.Reflection;
using System.Text;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")).EnableSensitiveDataLogging());

			services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")))
				.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<AuthenticationContext>()
				.AddDefaultTokenProviders();

			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequiredLength = 5;
				options.Password.RequiredUniqueChars = 3;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
				options.Password.RequireUppercase = false;
			});

			services
				.AddCors()
				.AddMvc()
				.AddControllersAsServices()
				.AddNewtonsoftJson();

			var jwtConfigSection = Configuration.GetSection("Jwt");
			services.Configure<JwtSettings>(jwtConfigSection, opt => opt.BindNonPublicProperties = true);

			var systemDefaultsConfigSection = Configuration.GetSection("SystemDefaults");
			services.Configure<SystemDefaults>(systemDefaultsConfigSection, opt => opt.BindNonPublicProperties = true);

			var jwtSettings = jwtConfigSection.Get<JwtSettings>(opt => opt.BindNonPublicProperties = true);
			var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidIssuer = jwtSettings.Issuer,
					ValidAudience = jwtSettings.Audience
				};
			});
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			var assemblies = new Assembly[]
			{
				Assembly.Load(nameof(API)),
				Assembly.Load(nameof(Service)),
				Assembly.Load(nameof(Data))
			};

			builder.RegisterAssemblyTypes(assemblies)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}

		public void Configure(
			IApplicationBuilder app,
			IWebHostEnvironment env,
			UserManager<IdentityUser> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<SystemDefaults> systemDefaultOptions)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(x =>
				x.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader()
			);

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => endpoints.MapControllers());

			AuthenticationContextInitializer.SeedRolesAndUsers(userManager, roleManager, systemDefaultOptions);
		}
	}
}
