using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSO[] waveConfigs;
    private WaveConfigSO currentWave;
    [SerializeField] private float timeBetweenWaves = 2f;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                yield return new WaitForSeconds(currentWave.GetRandomEnemyTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
