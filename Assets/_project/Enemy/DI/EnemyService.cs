using System.Collections.Generic;
using UnityEngine;

public class EnemyService
{
    private readonly List<Enemy> _enemies = new();

    public void Register(Enemy enemy)
    {
        if (!_enemies.Contains(enemy))
        {
            _enemies.Add(enemy);
        }
    }

    public void Unregister(Enemy enemy)
    {
        if (_enemies.Contains(enemy))
        {
            _enemies.Remove(enemy);
        }
    }

    public IReadOnlyList<Enemy> GetAll() => _enemies;
}
