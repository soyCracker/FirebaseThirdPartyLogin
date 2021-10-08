using AspNetCore.Firebase.Authentication.Extensions;
using BaseConfiguration;
using FirebaseAuthEntity.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace FirebaseThirdPartyLogin
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
            services.AddControllersWithViews();
            var connection = Config.DB_CONN;
            services.AddDbContext<FirebaseAuthDBContext>(options => options.UseSqlServer(connection));
            /*services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = "https://securetoken.google.com/1:237834925635:web:37bdc024baac882e2706f6";
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = "https://securetoken.google.com/1:237834925635:web:37bdc024baac882e2706f6",
                            ValidateAudience = true,
                            ValidAudience = "1:237834925635:web:37bdc024baac882e2706f6",
                            ValidateLifetime = true
                        };
                    });*/

            var FirebaseAuthentication_Issuer = "https://securetoken.google.com/thirdpartylogin-9c8ee";
            var FirebaseAuthentication_Audience = "thirdpartylogin-9c8ee";
            services.AddFirebaseAuthentication(FirebaseAuthentication_Issuer,
                                               FirebaseAuthentication_Audience);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
