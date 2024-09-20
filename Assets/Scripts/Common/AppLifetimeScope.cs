using VContainer;
using VContainer.Unity;

namespace Common
{
    public class AppLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // builder.RegisterInstance(...); - конфиги (SerializeField)
            // builder.RegisterComponent(...); - компоненты (SerializeField)
            // builder.Register<...>(Lifetime.Singleton); - просто регистрация класса
            // builder.RegisterEntryPoint<...>(); - регистрация класса с опциями Start Update Destroy
        }
    }
}