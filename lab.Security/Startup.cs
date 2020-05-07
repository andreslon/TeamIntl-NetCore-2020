using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using lab.Data;
using lab.Data.Interfaces;
using lab.Data.Repositories;
using lab.Security.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace lab.Security
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
            services.AddControllers();


            var builder = services.AddIdentityServer()
                .AddInMemoryApiResources(Config.Apis)
                //.AddInMemoryClients(Config.Clients)
                //.AddTestUsers(new List<IdentityServer4.Test.TestUser> {

                //    new IdentityServer4.Test.TestUser{
                //        Password="12345",
                //        Username="andreslon",
                //        IsActive=true,
                //        SubjectId= Guid.NewGuid().ToString(),
                //        Claims= new List<Claim>{
                //            new Claim("last_name","londoño") 
                //        }
                //    }}
                //)
                ;

            builder.Services.AddTransient<IClientStore, ClientStore>();
            builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            var cs = Configuration.GetConnectionString("SQL_CS");
            services.AddDbContext<TeamDbContext>(
                options =>
                    options.UseSqlServer(cs)
                );

            builder.AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

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
