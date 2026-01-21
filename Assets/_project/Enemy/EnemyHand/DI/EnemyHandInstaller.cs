using Zenject;

public class EnemyHandInstaller: Installer
{
    private readonly DiContainer _container;
    private readonly HandConfig _handConfig;
    private readonly EnemyType _enemyType;

    public EnemyHandInstaller(DiContainer container, HandConfig handConfig, EnemyType enemyType)
    {
        _container = container;
        _handConfig = handConfig;
        _enemyType = enemyType;
    }

    public override void InstallBindings()
    {
        _container.Bind<HandModel>()
            .To<EnemyHandModel>()
            .AsTransient()
            .WithArguments(_handConfig);

        _container.Bind<HandPresenter>()
            .AsTransient();

        _container.Bind<HandTargetLocator>()
            .AsTransient();

        var handAttackProvider = new EnemyHandAttackProvider();
        _container.Bind<IHandAttack>()
            .To(handAttackProvider.GetEnemyHandAttack(_enemyType))
            .AsTransient();

        _container.Bind<HandFsm<EnemyStateType>>()
            .To<EnemyHandFsm>()
            .AsTransient();

        _container.Bind<HandView<EnemyStateType>>()
            .To<EnemyHandView>()
            .AsTransient();
    }
}