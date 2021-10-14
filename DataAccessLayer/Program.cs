using log4net;
using MedChart.DataAccessLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace DataAccess.Layer
{
    class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));
        private static MedChartContext _appDbContext;

        static void Main(string[] args)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = log4net.LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            
            var services = new ServiceCollection();


            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var initialConfig = builder.Build();
            bool useUserSecrets = initialConfig.GetValue<bool>("UseUserSecrets");

            if (useUserSecrets)
            {
                try
                {
                    builder.AddUserSecrets(Assembly.GetExecutingAssembly());
                }
                catch (Exception ex)
                {
                    _logger.Debug($"Error processing AddUserSecrets: ", ex);
                }
            }

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetSection("MyProjectSettings").GetConnectionString("MedChartAssessmentConnection");
            services.AddDbContext<MedChartContext>(options => options.UseSqlServer(connectionString));

            var serviceProvider = services.BuildServiceProvider();
            _appDbContext = serviceProvider.GetService<MedChartContext>();
        }
    }
}
