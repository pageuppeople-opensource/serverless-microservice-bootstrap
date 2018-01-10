using System.IO;
using Amazon.Lambda.Core;
using Autofac;
using DomainService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Handlers
{
    public class DependencyModule : Module
    {
        private readonly ILambdaContext lambdaContext;

        public DependencyModule(ILambdaContext lambdaContext)
        {
            this.lambdaContext = lambdaContext;
        }

        private void ConfigureLogging()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddAWSProvider(configuration.GetAWSLoggingConfigSection());
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterInstance(lambdaContext);

            ConfigureLogging();

            builder.RegisterType<DomainService.DomainService>().As<IDomainService>().SingleInstance();
        }
    }
}
