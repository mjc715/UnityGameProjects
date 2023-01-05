using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] public Transform[] spawnPoints;
    [SerializeField] private float spawnRate = 4;
    [SerializeField] private float spawnRateGrowthRate;
    private int j = 1;
    private float timer, totalTime;
    void Update()
    {
        if (timer <= spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            int i = Random.Range(0, spawnPoints.Length - 1);
            Instantiate(enemyPrefab, spawnPoints[i].transform.position, Quaternion.identity);
        }
        totalTime += Time.deltaTime;
        if (totalTime > 30 * j && !UIManager.instance.gameOver)
        {
            spawnRate /= spawnRateGrowthRate;
            ++j;
            UIManager.instance.DisplaySpawnRateIncrease();
        }
    }
}
