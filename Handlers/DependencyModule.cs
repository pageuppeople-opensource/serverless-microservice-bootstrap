using System.IO;
using Amazon.Lambda.Core;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        private ILoggerFactory CreateLoggerFactory(ContainerBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = configBuilder.Build();

            var services = new ServiceCollection().AddLogging();

            builder.Populate(services);

            var loggerFactory = services.BuildServiceProvider().GetService<ILoggerFactory>();

            return loggerFactory.AddAWSProvider(configuration.GetAWSLoggingConfigSection());
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterInstance(lambdaContext);

            var loggerFactory = CreateLoggerFactory(builder);

            builder.RegisterInstance(loggerFactory).SingleInstance();

            builder.RegisterType<DomainService>().As<IDomainService>().SingleInstance();
        }
    }
}
