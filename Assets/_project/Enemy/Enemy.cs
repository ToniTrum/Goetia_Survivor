using UnityEngine;
using Zenject;

public class Enemy : Entity
{
    [Inject] private readonly EnemyService _enemyService;

    private void OnEnable()
    {
        _enemyService.Register(this);
    }

    private void OnDisable()
    {
        _enemyService.Unregister(this);
    }

    public class Factory : PlaceholderFactory<Vector3, GameObject, Enemy> { }
}
