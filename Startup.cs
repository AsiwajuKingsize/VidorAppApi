using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
using static DAL_SERVICES.Data.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;
using DAL_SERVICES.Interface;
using DAL_SERVICES.Repository;
using BAL_SERVICES.Services;
using DAL_SERVICES.Models;
using BAL_SERVICES.Helpers;
using DAL_SERVICES.Pagination_Helpers;

namespace WebApp_EComm
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IRepository<Category>, RepositoryCategory>();
            services.AddTransient<CategoryService, CategoryService>();
            services.AddTransient<IRepository<Merchant>, RepositoryMerchant>();
            services.AddTransient<MerchantService, MerchantService>();
            services.AddTransient<IRepository<Customer>, RepositoryCustomer>();
            services.AddTransient<CustomerService, CustomerService>();
            services.AddTransient<IRepository<Product>, RepositoryProduct>();
            services.AddTransient<IProductRepository, ProductPage>();
            services.AddTransient<ProductService, ProductService>();
            services.AddTransient<SecurityHelper, SecurityHelper>();
            services.AddTransient<LogInService, LogInService>();
            services.AddTransient<IRepository<Order>, RepositoryOrder>();
            services.AddTransient<OrderService, OrderService>();
            services.AddTransient<IRepository<OrderDetail>, RepositoryOrderDetail>();
            services.AddTransient<OrderDetailService, OrderDetailService>();
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Vidor E-Commerce API",
                    Description = "Vidor E-Commerce ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Osun Temidayo",
                        Email = "kingsize.wood@gmail.com",
                        Url = new Uri("https://twitter.com/osunmakinwa"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
