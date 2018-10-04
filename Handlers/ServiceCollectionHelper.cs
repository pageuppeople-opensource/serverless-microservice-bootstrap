using System;
using Amazon.Lambda.Core;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Handlers
{
    public static class ServiceCollectionHelper
    {
        public static IServiceProvider ConfigureServiceCollection(ILambdaContext context)
        {
            var serviceCollection = new ServiceCollection().AddSingleton(context);

            ConfigureServices(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddLambdaLogger());
            services.AddSingleton<IDomainService, DomainService>();
        }
    }
}
