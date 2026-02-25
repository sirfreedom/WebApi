using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using WebApi.Infrastructure.Jwt;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        #region Declaraciones

        public IConfiguration _Configuration { get; }

        private readonly string _MyAllowSpecificOrigins = "MyPolicy";
        private string _CorsPolicy;
        private string[] _lCorsPolicy;

        #endregion

        #region Constructor

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
            _CorsPolicy = _Configuration.GetValue(typeof(string), "AppConfig:CorsPolicy", string.Empty).ToString();
            _lCorsPolicy = _CorsPolicy.Split(",");
        }

        #endregion

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services )
        {
            services.AddCors(options =>
            {
                options.AddPolicy(_MyAllowSpecificOrigins, policy =>
                {
                    policy
                    .WithOrigins(_lCorsPolicy) //  Lista de orígenes válidos
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });


            services.AddControllers();
            services.AddEndpointsApiExplorer();

            var token = _Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            services.AddSingleton(token);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("AdminType", "1"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("AdminType", "2", "1"));
                options.AddPolicy("User", policy => policy.RequireClaim("AdminType",  "3", "2","1" ));
            });


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = token.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidAudience = token.Audience,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SirFreedom WebApi",
                    Description = "Una Api de Test Swagger y JWT",
                    Contact = new OpenApiContact
                    {
                        Name = @"Una Api para probar Swagger y JWT",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/sirfreedom")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);

                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "SirFreedom WebApi",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

                // add Basic Authentication
                var basicSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Reference = new OpenApiReference { Id = "BasicAuth", Type = ReferenceType.SecurityScheme }
                };
                c.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {basicSecurityScheme, new string[] { }}
                });
            });

            services.AddScoped<IUserService, UserService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(_MyAllowSpecificOrigins);

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseSwagger(options => options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.DocumentTitle = "SirFreedom WebApi";
                c.DefaultModelsExpandDepth(0);
                c.RoutePrefix = string.Empty;
            });
            app.UseForwardedHeaders();
            app.UseHttpMethodOverride();

            # region Uso correcto del orden 

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #endregion
        }

    }
}
