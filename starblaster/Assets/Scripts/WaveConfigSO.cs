using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private int enemyMoveSpeed = 5;
    [SerializeField] private float timeBetweenEnemySpawns = 1;
    [SerializeField] private float enemySpawnVariance = 0;
    [SerializeField] private float minimumSpawnTime = 0.2F;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public int GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWaypoints()
    {
        Transform[] waypoints = new Transform[pathPrefab.childCount];
        
        for (var i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints[i] = pathPrefab.GetChild(i);
        }
        
        return waypoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomEnemySpawnTime()
    {
        var spawnTime = Random.Range(
            minInclusive: timeBetweenEnemySpawns - enemySpawnVariance,
            maxInclusive: timeBetweenEnemySpawns + enemySpawnVariance
        );
        spawnTime = Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
        return spawnTime;
    }
}
