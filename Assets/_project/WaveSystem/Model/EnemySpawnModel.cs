using UnityEngine;

[System.Serializable]
public class EnemySpawnModel
{
    public GameObject EnemyPrefab;
    public EnemyConfig EnemyConfig;
    [Min(0.01f)] public float SpawnWeight = 1f;
}