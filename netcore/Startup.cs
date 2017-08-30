using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using Skeleton.Data;

namespace Skeleton{
    public class Startup{

        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env){

            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .Build();
            
        }

        public void ConfigureServices(IServiceCollection services){
            // DB setting.
            services.AddDbContext<SkeletonContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            // MVC enable.
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory){

            // Nginx proxy
            app.UseForwardedHeaders(new ForwardedHeadersOptions{
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // ログ出力先指定
            loggerFactory.AddFile(Configuration.GetSection("Logging"));

            // 開発時
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }else{
            	app.UseExceptionHandler("/error");
            }

            // MVC setting.
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}