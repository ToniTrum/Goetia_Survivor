using Zenject;
using UnityEngine;

public class EnemyFactory
{
    private readonly DiContainer _container;
    
    public EnemyFactory(DiContainer container)
    {
        _container = container;
    }
    
    public Enemy Create(EnemySpawnModel enemySpawnModel, Vector3 position)
    {
        var subContainer = _container.CreateSubContainer();

        subContainer.Bind<EnemyModel>()
            .AsTransient()
            .WithArguments(enemySpawnModel.EnemyConfig);

        subContainer.Bind<IEntityPresenter>()
            .To<EnemyPresenter>()
            .AsTransient();

        subContainer.Bind<EnemyFsm>()
            .AsTransient();
            
        subContainer.Bind<IEntityView<EnemyStateType>>()
            .To<EnemyView>()
            .AsTransient();
        
        return subContainer.InstantiatePrefabForComponent<Enemy>(
            enemySpawnModel.EnemyPrefab,
            position,
            Quaternion.identity,
            null
        );
    }
}