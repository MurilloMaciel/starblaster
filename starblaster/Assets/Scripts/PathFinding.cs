using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private WaveConfigSO _waveConfig;
    private Transform[] _waypoints;
    private int _waypointIndex = 0;

    private void Start()
    {
        _enemySpawner = FindFirstObjectByType<EnemySpawner>();
        _waveConfig = _enemySpawner.GetCurrentWave();
        _waypoints = _waveConfig.GetWaypoints();
        transform.position = _waveConfig.GetStartingWayPoint().position;
    }

    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (_waypointIndex < _waypoints.Length)
        {
            var targetPosition = _waypoints[_waypointIndex].position;
            var moveDelta = _waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveDelta);
            if (transform.position == targetPosition) _waypointIndex++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
