using Zenject;
using UnityEngine;

public class EnemyFactory
{
    private readonly DiContainer _container;
    private readonly Enemy _enemyPrefab;

    public EnemyFactory(DiContainer container, Enemy enemyPrefab)
    {
        _container = container;
        _enemyPrefab = enemyPrefab;
    }

    public Enemy Create(EnemyBaseModel config, Vector3 position)
    {
        var enemy = _container.InstantiatePrefabForComponent<Enemy>
        (
            _enemyPrefab,
            position, 
            Quaternion.identity, 
            null
        );

        enemy.GetComponent<EnemyInstaller>().SetConfig(config);

        return enemy;
    }
}
