using GatorCMS.Core.Connectors.MongoDB;
using GatorCMS.Core.Services.GatorPagesService;
using GatorCMS.Core.Wrappers.MongoDB;
using GatorCMS.Core.Wrappers.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using GatorCMS.Core.Models.Pages;
using MongoDB.Bson.Serialization;
using System.Collections.Generic;
using System;
using GatorCMS.Core.Connectors.MongoGridFS;

namespace GatorCMS.Core
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

            services.Configure<MongoDBSettings>(Configuration.GetSection(nameof(MongoDBSettings)));

            services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GatorCMS",
                    Description = "A Snappy CMS",
                });
            });

            services.AddSingleton<IDBCredentials, DBCredentials>();
            services.AddSingleton<IGatorPagesService, GatorPagesService>();
            services.AddSingleton<IMongoDBConnector, MongoDBConnector>();
            services.AddSingleton<IMongoGridFSConnector, MongoGridFSConnector>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GatorCMS V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}