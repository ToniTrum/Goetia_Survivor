using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public float speed = 5.0f;
    public override void InstallBindings()
    {
        Debug.Log("PlayerInstaller: InstallBindings called");

        Container.Bind<IPlayerView>()
            .FromComponentInHierarchy()
            .AsSingle();

        Container.Bind<PlayerModel>()
            .AsSingle()
            .WithArguments(speed);
        
        Container.Bind<PlayerPresenter>()
            .AsSingle();
        
        Container.Bind<PLayerFsm>()
            .AsSingle();
    }
}