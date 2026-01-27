using UnityEngine;
using Zenject;

public class PlayerHandInstaller : MonoInstaller
{
    [SerializeField] HandConfig handConfig;

    public override void InstallBindings()
    {

        Container.Bind<HandModel>()
            .To<PlayerHandModel>()
            .AsSingle()
            .WithArguments(handConfig);
        
        Container.Bind<HandPresenter>()
            .To<PlayerHandPresenter>()
            .AsSingle();
        
        Container.Bind<HandTargetLocator>()
            .AsSingle();
            
        Container.Bind<IHandAttack>()
            .To<PlayerHandAttack>()
            .AsSingle();

        Container.Bind<Hand<PlayerStateType>>()
            .To<PlayerHand>()
            .FromComponentInChildren()
            .AsSingle();


        Container.Bind<HandFsm<PlayerStateType>>()
            .To<PlayerHandFsm>()
            .AsSingle();

        Container.Bind<HandView<PlayerStateType>>()
            .To<PlayerHandView>()
            .AsSingle();
    }
}