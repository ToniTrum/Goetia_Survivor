using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField] private ShopConfiguration shopConfiguration;
    public override void InstallBindings()
    {
        Container.Bind<ShopConfiguration>()
        .FromInstance(shopConfiguration)
        .AsSingle();

        Container.Bind<ShopService>()
        .AsSingle()
        .NonLazy();
    }
}