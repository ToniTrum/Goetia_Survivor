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
            .AsSingle()
            .NonLazy();
        Container.Bind<EnemyFsm>()
            .AsSingle();
        Container.Bind<IEntityView<EnemyStateType>>()
            .To<EnemyView>()
            .AsSingle()
            .NonLazy();
        Container.Bind<Enemy>()
            .FromComponentOnRoot()
            .AsSingle();
    }

    public void SetConfig(EnemyBaseModel config)
    {
        _config = config;
    }
}
