using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private WaveModel[] _waveSequence;
    [SerializeField] private float _timeBetweenWaves = 8f;
    [SerializeField] private Vector2 _spawnAreaSize = new(23f, 22f);
    [SerializeField] private WaitForSeconds _waveStartWaiting = new(1.5f);

    private EnemyFactory _enemyFactory;
    private int _currentWaveIndex = -1;

    [Inject]
    private void Construct(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    private void Start()
    {
        if (_waveSequence.Length == 0)
        {
            Debug.LogWarning("Нет ни одной волны в WaveSpawner!");
            return;
        }

        StartCoroutine(WaveRoutine());
    }

    private IEnumerator WaveRoutine()
    {
        while (true)
        {
            yield return _waveStartWaiting;

            _currentWaveIndex++;
            if (_currentWaveIndex >= _waveSequence.Length)
            {
                break;
            }

            WaveModel currentWave = _waveSequence[_currentWaveIndex];

            yield return StartCoroutine(SpawnWave(currentWave));

            yield return new WaitForSeconds(_timeBetweenWaves);
        }
    }

    private IEnumerator SpawnWave(WaveModel wave)
    {
        for (int i = 0; i < wave.SpawnCount; i++)
        {
            EnemySpawnModel selected = WaveSystemPresenter.Pick(wave.Enemies);
            Vector3 position = GetRandomSpawnPosition();

            _enemyFactory.Create(selected, position);

            yield return new WaitForSeconds(wave.SpawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(
            Random.Range(-_spawnAreaSize.x / 2, _spawnAreaSize.x / 2),
            Random.Range(-_spawnAreaSize.y / 2, _spawnAreaSize.y / 2),
            -1
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(_spawnAreaSize.x, _spawnAreaSize.y, 1));
    }
}

public interface IEnemyFactory : IFactory<EnemySpawnModel, Vector3, Enemy> { }