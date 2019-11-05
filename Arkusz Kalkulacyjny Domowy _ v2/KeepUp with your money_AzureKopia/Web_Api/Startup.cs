using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Web_Api
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

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(
					builder =>
					{
						builder.WithOrigins("https://webappkuwym.azurewebsites.net");
					});

				options.AddPolicy("AnotherPolicy",
					builder =>
					{
						builder.WithOrigins("http://www.contoso.com")
											.AllowAnyHeader()
											.AllowAnyMethod();
					});

			});
			services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "SWAGGER CORE API", Description = "KeepUp with your money Info" });
				var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Web_Api.xml";
				c.IncludeXmlComments(xmlPath);
			}
				);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseSwagger();
			app.UseSwaggerUI(c=>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "SWAGGER CORE API");
			}
				);
			app.UseMvc();
		}
	}
}
