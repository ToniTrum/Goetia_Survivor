using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public float speed = 5.0f;
    public override void InstallBindings()
    {
        Debug.Log("HELLO?");
        Container.Bind<Entity<PlayerStateType>>().
            To<Player>()
            .FromComponentInHierarchy()
            .AsSingle();
        Container.Bind<IEntityView<PlayerStateType>>()
            .To<PlayerView>()   
            .AsSingle();

        Container.Bind<PlayerModel>()
            .AsSingle()
            .WithArguments(speed);
        
        Container.Bind<IEntityPresenter>()
            .To<PlayerPresenter>()
            .AsSingle();

        Container.Bind<PlayerFsm>()
            .AsSingle();
    }
}