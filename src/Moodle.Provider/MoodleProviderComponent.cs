using CluedIn.Core.Server;
using Castle.MicroKernel.Registration;

using CluedIn.Core;
using CluedIn.Core.Providers;
// 
using CluedIn.Crawling.Moodle.Core;
using CluedIn.Crawling.Moodle.Infrastructure.Installers;
// 
using CluedIn.Server;
using ComponentHost;

namespace CluedIn.Provider.Moodle
{
    [Component(MoodleConstants.ProviderName, "Providers", ComponentType.Service, ServerComponents.ProviderWebApi, Components.Server, Components.DataStores, Isolation = ComponentIsolation.NotIsolated)]
    public sealed class MoodleProviderComponent : ServiceApplicationComponent<IBusServer>
    {
        public MoodleProviderComponent(ComponentInfo componentInfo)
            : base(componentInfo)
        {
            // Dev. Note: Potential for compiler warning here ... CA2214: Do not call overridable methods in constructors
            //   this class has been sealed to prevent the CA2214 waring being raised by the compiler
            Container.Register(Component.For<MoodleProviderComponent>().Instance(this));  
        }

        public override void Start()
        {
            Container.Install(new InstallComponents());

            Container.Register(Types.FromAssembly(System.Reflection.Assembly.GetExecutingAssembly()).BasedOn<IProvider>().WithServiceFromInterface().If(t => !t.IsAbstract).LifestyleSingleton());
            Container.Register(Types.FromAssembly(System.Reflection.Assembly.GetExecutingAssembly()).BasedOn<IEntityActionBuilder>().WithServiceFromInterface().If(t => !t.IsAbstract).LifestyleSingleton());



            State = ServiceState.Started;
        }

        public override void Stop()
        {
            if (State == ServiceState.Stopped)
                return;

            State = ServiceState.Stopped;
        }
    }
}
