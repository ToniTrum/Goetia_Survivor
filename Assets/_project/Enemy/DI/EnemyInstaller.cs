using Zenject;
using UnityEngine;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private EnemyBaseModel _config;

    public override void InstallBindings()
    {
        Container.Bind<IEntityModel>()
            .To<EnemyModel>()
            .AsSingle()
            .WithArguments(_config);

        Container.Bind<IEntityPresenter>()
            .To<EnemyPresenter>()
            .AsSingle();
        
        Container.Bind<IEntityView<EnemyStateType>>()
            .To<EnemyView>()
            .AsSingle();
    }
}
