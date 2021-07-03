using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlRouting.Infrastructure;

namespace UrlRouting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            options.ConstraintMap.Add("weekday", typeof(WeekdayConstraint)));
            services.AddMvc();
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
                app.UseExceptionHandler("/Error");
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                //    routes.MapRoute(
                //        name: "Shop1",
                //        template: "shop/{action}",
                //        defaults: new { controller = "Product" }
                //        );
                //    routes.MapRoute(
                //        name: "Shop2",
                //        template: "shop/newest",
                //        defaults: new { controller = "Product", action = "Index" }
                //        );
                //    routes.MapRoute(
                //        name: "",
                //        template: "a{controller=Home}/{action=Index}"
                //        );
                //    routes.MapRoute(
                //        name: "catalog",
                //        template: "catalog/{controller}/{action=Index}"
                //        );
                //    routes.MapRoute(
                //        name: "default",
                //        template: "{controller=Home}/{action=Index}/{id?}/{*extraparams}"
                //        );
                //    routes.MapRoute(
                //     name: "default",
                //     template: "{controller=Home}/{action=Index}/{id:int?}"
                //     );
                //    routes.MapRoute(
                //     name: "default",
                //     template: "{controller=Home}/{action=Index}/{id:range(1,1000)?}"
                //     );
                //    routes.MapRoute(
                //     name: "default",
                //     template: "{controller=Home}/{action=Index}/{id:alpha:minlength(3)?}" //->string veri
                //     );
                //    routes.MapRoute(
                //        name: "default",
                //        template: "{controller=Home}/{action=Index}/{id?}",
                //        defaults: new { controller = "Home", action = "Index" },
                //        constraints: new { id = new IntRouteConstraint() }
                //        );
                //    routes.MapRoute(
                //        name: "default",
                //        template: "{controller=Home}/{action=Index}/{id?}",
                //        defaults: new { controller = "Home", action = "Index" },
                //        constraints: new
                //        {
                //            id = new CompositeRouteConstraint(
                //            new IRouteConstraint[]
                //            {
                //                new AlphaRouteConstraint(),
                //                new MinLengthRouteConstraint(3)
                //            })
                //        });
                //    routes.MapRoute(
                //       name: "deneme",
                //       template: "{controller}/{action}/{id?}",
                //       defaults: new { controller = "Home", action = "Index" },
                //       constraints: new { id = new WeekdayConstraint() }
                //       );
                //    routes.MapRoute(
                //       name: "deneme2",
                //       template: "{controller}/{action}/{id:weekday?}",
                //       defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(
                     name: "appRoute",
                     template: "app/{action}",
                     defaults: new { controller = "Product" }
                     );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
