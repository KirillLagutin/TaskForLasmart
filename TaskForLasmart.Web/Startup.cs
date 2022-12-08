using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskForLasmart.Data.Ef.Data;
using TaskForLasmart.Data.Ef.Repositories;
using TaskForLasmart.Domain.IRepositories;


namespace TaskForLasmart.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EfDbContext>(o => 
                o.UseInMemoryDatabase(databaseName: "DotCommentsInMemoryDb"));
            
            services.AddScoped<IPointRepository, PointRepository>();
            
            services.AddControllersWithViews();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Point}/{action=Index}");
            });
        }
    }
}