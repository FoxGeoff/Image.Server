﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Image.Server.Context;
using Image.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Image.Server
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly string _dbconnect;

        public Startup(IConfiguration config)
        {
            _config = config;
            _dbconnect = _config["ConnectionStrings:ProductImageDbContext"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductImageDbContext>(options =>
                options.UseMySql(_dbconnect));

            services.AddTransient<ProductImageSeeder>();

            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole();

                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<ProductImageSeeder>();
                    seeder.Seed();
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
