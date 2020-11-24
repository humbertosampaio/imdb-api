using Autofac;
using Data;
using Data.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.DTOs.AppSettings;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.OpenApi.Models;

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

			services.AddSwaggerGen(c =>
			{
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme.",
					Name = "Authorization",
					Scheme = "Bearer",
					BearerFormat = "Bearer {token}",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement 
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[] { }
					}
				});

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
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
			app.UseSwagger();

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
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMDb API");
			});

			AuthenticationContextInitializer.SeedRolesAndUsers(userManager, roleManager, systemDefaultOptions);
		}
	}
}
