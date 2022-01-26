using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ecommerce.Models;
using Ecommerce.Repositories;

namespace Ecommerce.WebHost
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
            services.InjectServices();
            services.InjectRepositories();
            services.InjectMappings();
            services.AddControllers();

            #region To Change the naming policy to Pascal Case in API Response (Not in use)
            // services.AddControllers().AddJsonOptions(options =>
            // {
            //     options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //     options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            // });
            #endregion

            #region Database Connection Preparations
            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            #endregion

            #region Adding Swagger UI
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce.WebHost", Version = "v1" });
                c.EnableAnnotations();
                // var SecurityScheme = new OpenApiSecurityScheme
                // {
                //     Name = "JWT Authentication",
                //     Description = "Enter JWT Bearer token **_only_**",
                //     In = ParameterLocation.Header,
                //     Type = SecuritySchemeType.Http,
                //     Scheme = "bearer", // must be lower case
                //     BearerFormat = "JWT",
                //     Reference = new OpenApiReference
                //     {
                //         Id = JwtBearerDefaults.AuthenticationScheme,
                //         Type = ReferenceType.SecurityScheme
                //     }
                // };
                // c.AddSecurityDefinition(SecurityScheme.Reference.Id, SecurityScheme);
                // c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //     {
                //         {SecurityScheme, new string[] { }}
                //     });
            });
            #endregion

            #region CORS Configuration
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce.WebHost v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
