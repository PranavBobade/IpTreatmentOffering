using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using aspnet_core_dotnet_core.OfferingRepository;
using aspnet_core_dotnet_core.OfferingService;


namespace aspnet_core_dotnet_core
{
    [ExcludeFromCodeCoverage]
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
            services.AddControllers();
            services.AddTransient<ITreatmentServices, TreatmentServices>();
            services.AddTransient<ITreatmentOfferingsRepository, TreatmentOfferingsRepository>();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "IP TreatmentOffering Microservice",
                    Version = "v2",
                    Description = "",
                });
            });



            // Jwt Authentication Settings

            string securityKey = "myPodfourSecretKey";

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));



            services.AddAuthentication(x =>

            {



                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                x.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;

            })

            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>

            {



                x.TokenValidationParameters = new TokenValidationParameters

                {

                    //what to validate 

                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,



                    //setup validate data 

                    ValidIssuer = "910311",

                    ValidAudience = "910311",

                    IssuerSigningKey = symmetricSecurityKey

                };

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "IP TreatmentOffering Microservice"));


            logger.AddLog4Net();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }




}
