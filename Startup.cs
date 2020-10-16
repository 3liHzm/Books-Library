using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksLp.Models;
using BooksLp.Models.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BooksLp
{
    public class Startup
    {

        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddScoped<IBookStoreRepo<Auther>, AutherDbRepo>();
            services.AddScoped<IBookStoreRepo<Books>, BooksDbRepo>();
            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("SqlConnection"));
            });

           // services.AddSingleton<The iterface <Tentity the type>, entity repo "the service u want that contain the matodes" >();
            //services.AddSingleton<IBookStoreRepo<Auther>, AutherRepo>();
            //services.AddSingleton<IBookStoreRepo<Books>, BookRepo>();

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(route=> { route.MapRoute("default", "{controller=Books}/{action=Index}/{id?}");
            });
            
            
    
        }
    }
}
