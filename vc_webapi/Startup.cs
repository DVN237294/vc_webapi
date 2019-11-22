using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using vc_webapi.Data;
using vc_webapi.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using vc_webapi.Helpers;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using vc_webapi.Services;
using vc_webapi.SwashbuckleFilters;

namespace vc_webapi
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
            services.AddCors();
            services.AddControllers();
            services.AddEntityFrameworkNpgsql().AddDbContext<Vc_webapiContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PostgresqlConnection")));

            //Authentication setup
            services.AddDbContext<AuthenticationContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PostgresqlConnection")));
            services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<AuthenticationContext>();
           
            //Generate swagger json document
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "vc_webapi",
                    Version = "v1",
                    Description = "Web API for the Virtual Classroom project",
                    Contact = new OpenApiContact
                    {
                        Email = "237294@via.dk",
                        Name = "David V. Nielsen"
                    },
                });
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" }
                        },
                        new string[] { }
                    }
                });
                c.OperationFilter<BinaryPayloadFilter>();
                c.OperationFilter<RequestEncodingContentTypeFilter>();
                c.SchemaFilter<ReadOnlyPropertyFilter>();
            });

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("39e9fab8f48f2b49d070b7aa135230a97d1b2a4e02aa153965f50c0880596bad"));
            services.AddSingleton<IJWTTokenGenerator>(new JWTTokenHelper(new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)));
            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.SaveToken = false;
                opts.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<VideoStoreService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var db = scope.ServiceProvider.GetService<Vc_webapiContext>())
                    db.Database.Migrate();
                using (var db = scope.ServiceProvider.GetService<AuthenticationContext>())
                    db.Database.Migrate();
            }

            app.UseAuthentication();

            app.UseCors(opts =>
            {
                opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            //Enable swagger (doc generation)
            app.UseSwagger();

            //Enable swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "vc_webapi v1");
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
