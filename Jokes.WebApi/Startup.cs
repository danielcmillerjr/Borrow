using Jokes.WebApi.Data;
using Jokes.WebApi.Data.GenericRepository;
using Jokes.WebApi.Models;
using Jokes.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using Jokes.WebApi.Validators;

namespace Jokes.WebApi
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
            services.AddDbContextPool<JokesDbContext>(options => options.UseInMemoryDatabase(databaseName: "Jokes"));
            services.AddScoped<IGenericRepository<Joke>, GenericRepository<Joke>>();
            services.AddScoped<IJokeService, JokeService>();

            services.AddControllers();

            //Adding swagger to the api so we can provide some documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jokes API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddResponseCompression();

            services.AddMvcCore()
                .AddApiExplorer()
                .AddFluentValidation(o =>
                 {
                     o.RegisterValidatorsFromAssemblyContaining<JokeValidator>();
                 });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Adding Swagger to the project for documentation purposes
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jokes API V1");
            });
        }
    }
}
