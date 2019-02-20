using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Sample.BasicRestAspnetCore.Business.BookBusiness.Implementation;
using Sample.BasicRestAspnetCore.Business.BookBusiness.Interface;
using Sample.BasicRestAspnetCore.Business.Person.Implementation;
using Sample.BasicRestAspnetCore.Business.Person.Interface;
using Sample.BasicRestAspnetCore.Data.Context;
using Sample.BasicRestAspnetCore.Data.Repositories.BookRepository.Implementation;
using Sample.BasicRestAspnetCore.Data.Repositories.BookRepository.Interface;
using Sample.BasicRestAspnetCore.Data.Repositories.GenericRepository;
using Sample.BasicRestAspnetCore.Data.Repositories.Person.Implementation;
using Sample.BasicRestAspnetCore.Data.Repositories.Person.Interface;
using Sample.BasicRestAspnetCore.DatabaseMigration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

namespace Sample.BasicRestAspnetCore.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = $"{Configuration["CONNECTION_STRING"]}Database={Configuration["DATABASE_NAME"]};";

            Migration.Apply(Configuration["CONNECTION_STRING"], Configuration["DATABASE_NAME"]);

            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RESTFul API .Net Core Repository Pattern Sample",
                    Version = "v1"
                });
            });

            /*
            Dependency Groups */
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBookBusiness, BookBusiness>();
            services.AddScoped<IBookRepository, BookRepository>();


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

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Sample V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            //app.UseHttpsRedirection();
            app.UseMvc();
        }


    }
}
