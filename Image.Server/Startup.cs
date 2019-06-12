using AutoMapper;
using Image.Server.Context;
using Image.Server.Profiles;
using Image.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

            // services.AddTransient will return a new instance each time - This will not keep state TOO SHORT!
            // services.AddSingleton is not equal to OR shorter than the DbContext scope TOO LONG!
            services.AddScoped<IImageRepository, ImageRepository>();

            //services.AddAutoMapper(); needs update as shown below:-
            // AutoMapper Configurations #1
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ImageProfile>();
            });

            // AutoMapper Configurations #2
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ImageProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddHttpClient();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
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

                app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );
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
