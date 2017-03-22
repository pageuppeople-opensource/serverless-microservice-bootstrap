using Autofac;

namespace Serverless.Dotnet.Core
{
    public class CoreAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ServiceProcess>().As<IServiceProcess>().InstancePerDependency();
        }
    }
}