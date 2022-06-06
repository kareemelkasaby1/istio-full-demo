using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace BookInfo.Details
{
    public class Startup
    {
        private readonly IEnumerable<string> _headersToForward;


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _headersToForward = new List<string>
            {
                "x-request-id",
                "x-b3-traceid",
                "x-b3-spanid",
                "x-b3-parentspanid",
                "x-b3-sampled",
                "x-b3-flags",
                "x-ot-span-context",
                "x-datadog-trace-id",
                "x-datadog-parent-id",
                "x-datadog-sampled"
            };
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    foreach (var header in context.Request.Headers)
                    {
                        if (_headersToForward.Contains(header.Key))
                        {
                            context.Response.Headers.Add(header.Key, header.Value);
                        }
                    }
                    return System.Threading.Tasks.Task.FromResult(0);
                });
                await next();
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}