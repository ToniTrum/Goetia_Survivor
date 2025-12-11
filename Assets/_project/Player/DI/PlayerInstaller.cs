using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public float speed = 5.0f;
    public override void InstallBindings()
    {
        Container.Bind<PlayerView>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container.Bind<PlayerModel>()
            .AsSingle()
            .WithArguments(speed);
        
        Container.Bind<PlayerPresenter>()
            .AsSingle();

        Container.Bind<PlayerFsm>()
            .AsSingle();
    }
}