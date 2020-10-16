using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NFPL.Data;

namespace NFPL
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
            services.AddRouting(option => option.LowercaseUrls = true);
            services.AddControllersWithViews().AddNewtonsoftJson();

            //the below two codes registers sessions in the local storage of the browser
            services.AddMemoryCache();
            services.AddSession();

            services.AddDbContext<DbContextApp>(options => options.UseSqlServer(Configuration.GetConnectionString("TeamConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            //This code is to be used before the 'useRouting' middleware so as to do a check for whoever is about to visit a particular protected site,
            //lest we visist an authorized/protected route easily.
            app.UseSession();

            app.UseRouting();

            //routes are added from the most specific to the least specific
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{controller=Home}/{action=Index}/conf/{activeConf}/div/{activeDiv}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}