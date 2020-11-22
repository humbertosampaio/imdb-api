using Autofac;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DataContext>(options => 
				options
					.UseSqlServer(Configuration.GetConnectionString("Default"))
					.EnableSensitiveDataLogging()
			);

			services.AddOptions();

			services
				.AddMvc()
				.AddControllersAsServices();
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

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
