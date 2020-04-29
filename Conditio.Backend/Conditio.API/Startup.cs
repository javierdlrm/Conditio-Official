using AutoMapper;
using Conditio.Adapter.API.Assets;
using Conditio.Adapter.API.Domains;
using Conditio.Adapter.API.Entities;
using Conditio.Adapter.API.Users;
using Conditio.API;
using Conditio.Core.Assets;
using Conditio.Core.Domains;
using Conditio.Core.Entities;
using Conditio.Core.Users;
using Conditio.Infrastructure.MongoDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConditioWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string ALLOW_ALL_ORIGINS_POLICY = "AllowAllOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Options

            services.Configure<MongoDbOptions>(options =>
            {
                Configuration.GetSection("MongoDb").Bind(options);
                options.ConnectionString = Configuration.GetConnectionString("MongoDb");
            });
            services.Configure<AppInsightsAPIOptions>(options =>
            {
                Configuration.GetSection("ApplicationInsights").Bind(options);
            });

            #endregion

            #region Repositories

            services.AddSingleton<IMongoDbConnection>((provider) => new MongoDbConnection(provider.GetService<IOptions<MongoDbOptions>>().Value));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IDomainRepository, DomainRepository>();

            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserServiceAdapter, UserServiceAdapter>();

            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<IEntityServiceAdapter, EntityServiceAdapter>();

            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IAssetServiceAdapter, AssetServiceAdapter>();

            services.AddScoped<IDomainService, DomainService>();
            services.AddScoped<IDomainServiceAdapter, DomainServiceAdapter>();

            #endregion

            #region CORS

            services.AddCors(options =>
            {
                options.AddPolicy(ALLOW_ALL_ORIGINS_POLICY, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Conditio.Web/dist";
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(ALLOW_ALL_ORIGINS_POLICY);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "Conditio.Web";

                if (env.IsDevelopment())
                {
                    // NOTE: 
                    // UseProxyToSpaDevelopmentServer: Run angular app and api independently.
                    // UseAngularCliServer: Run both simultaneously
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
