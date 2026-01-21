using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ShopService>()
        .AsSingle();
    }
}