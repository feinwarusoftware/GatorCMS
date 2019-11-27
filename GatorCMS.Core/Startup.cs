using GatorCMS.Core.Connectors.MongoDB;
using GatorCMS.Core.Models;
using GatorCMS.Core.Services.LemonService;
using GatorCMS.Core.Wrappers.DBSettings;
using GraphQL;
using GraphQL.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.IO;

namespace GatorCMS.Core {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = false;
            //});

            // var test = Configuration.GetSection(nameof(LemonDBSettings)).GetChildren();

            // services.Configure<LemonDBSettings>(Configuration.GetSection(nameof(LemonDBSettings)));
            // services.AddSingleton<ILemonDBSettings>(sp => sp.GetRequiredService<IOptions<LemonDBSettings>>().Value);

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo {
                    Version = "v1",
                        Title = "GatorCMS",
                        Description = "An *epic* headless CMS. Name change pending...",
                });
            });

            services.AddSingleton<ILemonService, LemonService>();
            services.AddSingleton<IMongoDBConnector, MongoDBConnector>();
            services.AddSingleton<ILemonDBSettings, LemonDBSettings>();

            // graphql
            services.AddTransient<IDependencyResolver>(servicesProvider =>
            {
                return new FuncDependencyResolver(servicesProvider.GetService);
            });
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            // services.AddTransient<QueryType>();
            // services.AddTransient<LemonSchema>();
            services.AddTransient<AppQuery>();
            services.AddTransient<LemonType>();
            services.AddTransient<AppSchema>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "GatorCMS V1");
                c.RoutePrefix = string.Empty;
            });

            // graphql
            // app.UseGraphiQl();
            app.UseGraphQLMiddleware<AppSchema>();
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = "/playground",
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "playground"
                    )
                )
            });
        }
    }
}
