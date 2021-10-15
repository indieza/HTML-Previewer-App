// <copyright file="Startup.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using PreviewerApp.AutoMapperProfiles;
    using PreviewerApp.Data;
    using PreviewerApp.Services.CheckHtmlRecordServices;
    using PreviewerApp.Services.CreateHtmlRecordServices;
    using PreviewerApp.Services.HomeServices;
    using PreviewerApp.Services.PreviewHtmlRecordServices;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register Application DB Context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            // Register Logic Services
            services.AddTransient<ICreateHtmlRecordService, CreateHtmlRecordService>();
            services.AddTransient<IPreviewHtmlRecordService, PreviewHtmlRecordService>();
            services.AddTransient<ICheckHtmlRecordService, CheckHtmlRecordService>();
            services.AddTransient<IHomeService, HomeService>();

            // Setup AutoMapper Profiles Configurations
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new HtmlRecordProfile());
            }).CreateMapper());

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
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