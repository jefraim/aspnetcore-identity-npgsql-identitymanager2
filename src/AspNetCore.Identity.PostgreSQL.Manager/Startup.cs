using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.PostgreSQL.Entity;
using IdentityManager2.AspNetIdentity;
using IdentityManager2.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCore.Identity.PostgreSQL.Manager
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
            services.ConfigureNpgsqlIdentityForAspNetIdentity<Guid>(Configuration.GetConnectionString("IdentityDbConnection"));

            services.AddMvc();

            services.AddIdentityManager()
                .AddIdentityMangerService<AspNetCoreIdentityManagerService<ApplicationUser<Guid>, Guid, ApplicationRole<Guid>, Guid>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityManager();
            app.UseMvc();
        }
    }
}
