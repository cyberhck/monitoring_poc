using System;
using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.InfluxDB;
using App.Metrics.Reporting.InfluxDB;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Rooft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureMetricsWithDefaults((builder) =>
                {
                    var reporting = new MetricsReportingInfluxDbOptions();
                    reporting.InfluxDb.BaseUri = new Uri("http://localhost:8086");
                    reporting.InfluxDb.Database = "monitoring";
                    reporting.InfluxDb.UserName = "cyberhck";
                    reporting.InfluxDb.Password = "secret";
                    reporting.InfluxDb.CreateDataBaseIfNotExists = true;
                    reporting.FlushInterval = TimeSpan.FromSeconds(5);
                    reporting.MetricsOutputFormatter = new MetricsInfluxDbLineProtocolOutputFormatter();


                    builder.Report.ToInfluxDb(reporting);
                })
                .UseMetrics()
                .UseUrls("http://localhost:8080")
                .UseStartup<Startup>();
    }
}
