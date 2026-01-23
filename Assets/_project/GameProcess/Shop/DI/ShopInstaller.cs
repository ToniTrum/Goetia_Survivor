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

        Container.Bind<ShopModel>()
        .AsSingle();
        
        Container.Bind<ShopPresenter>()
        .AsSingle()
        .NonLazy();
    }
}