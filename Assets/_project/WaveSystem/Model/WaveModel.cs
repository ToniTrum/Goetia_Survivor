using UnityEngine;

[CreateAssetMenu(menuName = "Model/Wave")]
public class WaveModel : ScriptableObject
{
    public EnemySpawnModel[] Enemies;
    public int SpawnCount;
    public float SpawnInterval;
}
