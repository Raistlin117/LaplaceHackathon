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
        [SerializeField] private PhotoConfigs _photoConfigs;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_userDataConfigs);
            builder.RegisterInstance(_photoConfigs);
            builder.Register<SaveAndLoad>(Lifetime.Singleton);

            // builder.RegisterInstance(...); - конфиги (SerializeField)
            // builder.RegisterComponent(...); - компоненты (SerializeField)
            // builder.Register<...>(Lifetime.Singleton); - просто регистрация класса
            // builder.RegisterEntryPoint<...>(); - регистрация класса с опциями Start Update Destroy
        }
    }
}