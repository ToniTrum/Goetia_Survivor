using UnityEngine;

[System.Serializable]
public class EnemySpawnModel
{
    public GameObject EnemyPrefab;
    public EnemyConfig EnemyConfig;
    public HandConfig HandConfig;
    public EnemyType EnemyType;
    [Min(0.01f)] public float SpawnWeight = 1f;
}