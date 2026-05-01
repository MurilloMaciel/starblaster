using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSO[] waveConfigs;
    [SerializeField] private float timeBetweenWaves = 1F;
    [SerializeField] private bool isLooping;
    private WaveConfigSO _currentWave;

    private void Start()
    {
        StartCoroutine(routine: SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (var waveConfig in waveConfigs)
            {
                _currentWave = waveConfig;
                for (var i = 0; i < _currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(
                        original: _currentWave.GetEnemyPrefab(i), 
                        position: _currentWave.GetStartingWayPoint().position, 
                        rotation: Quaternion.identity,
                        parent: transform
                    );
                    yield return new WaitForSeconds(_currentWave.GetRandomEnemySpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return _currentWave;
    }
}
