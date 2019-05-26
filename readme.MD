## Project: Image.Server
## Description: ASP.net core 2.1 Wep API server for images with MySQL database storage
## Date: 5/23/2019


## Ref: Project MySql_Image

## Check: Setup for MySql database
* Nuget packages: ```Pomelo.EntityFrameworkCore.MySql```Version 2.1.4 for core 1.1
* Connection string for MySql (user secrets) and seed data in startup.cs:
```
{
  "ConnectionStrings": {
    "dbconnect": "server=localhost;userid=root;password=this_is_not_a_password##;database=Test;"
  }
}
```
* Startup.cs Connection string and data seed:
```
public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductImageDbContext>(options => 
                options.UseMySql(_dbconnect));

			services.AddTransient<ProductImageSeeder>();
			...
			...
 // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<ProductImageSeeder>();
                    seeder.Seed();
                }
            }
            else
			...
			...
```
* Migrations:
* Run```Add-Migration InitDb```
* Run```Update-Database```

## Check: Add ProductController

* Code out ImageRepository.GetProductsAsync()
* Code out Dispose 
```
public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
```
* Add Json Formating (StartUp.cs) to handle recussion
```
services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
    .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

```

