using Donation_Management.BusinessLayer.Interfaces;
using Donation_Management.BusinessLayer.Services;
using Donation_Management.BusinessLayer.Services.Repository;
using Donation_Management.DataLayer;
using Donation_Management.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Donation_Management
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
            services.AddDbContext<NgoDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));
            
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INgoRepository, NgoRepository>();
            services.AddScoped<INgoServices, NgoServices>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonorServices, DonorServices>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IDonationServices, DonationServices>();
            services.AddScoped<IDonationRequestRepository, DonationRequestRepository>();
            services.AddScoped<IDonationRequestServices, DonationRequestServices>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ngo}/{action=register}/{id?}");
            });
        }
    }
}
