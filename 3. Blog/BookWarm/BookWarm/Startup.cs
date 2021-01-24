using BookWarm.Data;
using BookWarm.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using BookWarm.Data.FileManager;
using Microsoft.AspNetCore.Mvc;
using BookWarm.Configuration;
using BookWarm.Services.Email;

namespace BookWarm
{
	public class Startup
	{
		private IConfiguration _config;

		public Startup(IConfiguration config)
		{
			_config = config;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<SmtpSettings>(_config.GetSection("SmtpSettings"));
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_config["DefaultConnection"]));
			services.AddIdentity<IdentityUser, IdentityRole>(options=>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 6;
			})
				//.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Auth/Login";
			});
			services.AddTransient<IRepository, Repository>();
			services.AddTransient<IFileManager, FileManager>();
			services.AddSingleton<IEmailService, EmailService>();

			services.AddMvc(options =>
			{
				options.EnableEndpointRouting = false;
				options.CacheProfiles.Add("Monthly", new CacheProfile { Duration = 60 * 60 * 24 * 7 * 4 });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{				
			}

			app.UseDeveloperExceptionPage();

			app.UseStaticFiles(); //to display images

			app.UseAuthentication();

			app.UseMvcWithDefaultRoute();

			//app.UseRouting();

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapGet("/", async context =>
			//	{
			//		await context.Response.WriteAsync("Hello World!");
			//	});
			//});
		}
	}
}
