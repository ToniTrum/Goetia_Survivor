using UnityEngine;

[CreateAssetMenu(menuName = "Wave/WaveModel")]
public class WaveModel : ScriptableObject
{
    public EnemySpawnModel[] Enemies;
    public int SpawnCount;
    public float SpawnInterval;
}
