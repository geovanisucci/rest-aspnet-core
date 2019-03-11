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
using Sample.BasicRestAspnetCore.Data.Repositories.Person.Implementation;
using Sample.BasicRestAspnetCore.Data.Repositories.Person.Interface;
using Sample.BasicRestAspnetCore.DatabaseMigration;
using Microsoft.AspNetCore.Rewrite;
using System.IO;
using System;
using Sample.BasicRestAspnetCore.Data.Repositories.UsersRepository.Implementation;
using Sample.BasicRestAspnetCore.Data.Repositories.UsersRepository.Interface;
using Sample.BasicRestAspnetCore.Business.UserBusiness.Interface;
using Sample.BasicRestAspnetCore.Business.UserBusiness.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Sample.BasicRestAspnetCore.Authentication.Configuration;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace Sample.BasicRestAspnetCore.Host
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        public IConfiguration Configuration { get; }

        ///
        /// // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = $"{Configuration["CONNECTION_STRING"]}Database={Configuration["DATABASE_NAME"]};";

            //Migration.Apply(Configuration["CONNECTION_STRING"], Configuration["DATABASE_NAME"]);

            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning();

            //Auth
            var signingConfigurations = new SigningConfiguration();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration();
            tokenConfigurations.Audience = "MyAudienceExample";
            tokenConfigurations.Issuer = "MyIssuerExapmle";
            tokenConfigurations.Seconds = 1200;

            services.AddSingleton(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });


            //Swagger
            services.AddSwaggerGen(c =>
            {

               c.SwaggerDoc ("v1", new Info {
                    Title = "RESTFul API .Net Core Repository Pattern Sample",
                    Version = "v1"
                }); 
                //Creating the button to inform the JWT Token
                c.AddSecurityDefinition ("Bearer", new ApiKeyScheme {
                    In = "header",
                        Description = "Please enter JWT with Bearer into field",
                        Name = "Authorization",
                        Type = "apiKey"
                });
                c.AddSecurityRequirement (new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string> () },
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });



            /*
            Dependency Groups */
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBookBusiness, BookBusiness>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserRepository, UserRepository>();


        }

        ///
        /// // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Sample V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            //app.UseHttpsRedirection();
            app.UseMvc();

            app.UseAuthentication();
        }


    }
}
