using AppSaveAndLoad;
using Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Common
{
    public class AppLifetimeScope : LifetimeScope
    {
        [SerializeField] private UserDataConfigs _userDataConfigs;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_userDataConfigs);
            builder.Register<SaveAndLoad>(Lifetime.Singleton);

            // builder.RegisterInstance(...); - конфиги (SerializeField)
            // builder.RegisterComponent(...); - компоненты (SerializeField)
            // builder.Register<...>(Lifetime.Singleton); - просто регистрация класса
            // builder.RegisterEntryPoint<...>(); - регистрация класса с опциями Start Update Destroy
        }
    }
}