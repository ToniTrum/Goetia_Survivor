using System.Collections.Generic;
using UnityEngine;

public static class WaveSystemPresenter
{
    public static EnemySpawnModel Pick(IReadOnlyList<EnemySpawnModel> list)
    {
        float totalWeight = 0f;

        foreach (var enemy in list)
            totalWeight += enemy.SpawnWeight;

        if (totalWeight <= 0)
        {
            Debug.LogError("SpawnConfig has zero total weight");
            return list[0];
        }

        float roll = Random.value * totalWeight;

        foreach (var enemy in list)
        {
            roll -= enemy.SpawnWeight;
            if (roll <= 0)
                return enemy;
        }

        return list[^1];
    }
}

