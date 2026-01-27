using Zenject;
using UnityEngine;

public class ArenaInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyService>()
            .AsSingle()
            .NonLazy();

        Container.Bind<EnemyFactory>()
            .AsSingle()
            .NonLazy();

        Container.Bind<ProjectileFactory>()
            .AsSingle()
            .NonLazy();
    }
}