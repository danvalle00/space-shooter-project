using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float enemyMoveSpeed = 5f;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private float enemySpawnRandomFactor = 0f;
    [SerializeField] private float minSpawnDelay = 0.2f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWaypoints()
    {
        Transform[] waypoints = new Transform[pathPrefab.childCount];
        for (int i = 0; i < pathPrefab.childCount; i++)
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

    public float GetRandomEnemyTime()
    {
        float spawnTime = Random.Range(timeBetweenSpawns - enemySpawnRandomFactor, timeBetweenSpawns + enemySpawnRandomFactor);
        spawnTime = Mathf.Clamp(spawnTime, minSpawnDelay, float.MaxValue);
        return spawnTime;
    }
}
