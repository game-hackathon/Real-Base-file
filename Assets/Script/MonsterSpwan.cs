using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MonsterSpwan : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject speedEnemyPrefab;
    [SerializeField] GameObject bigEnemyPrefab;
    [SerializeField] float spawnTime;
    [SerializeField] int waveEnemyValue;
    [SerializeField] Transform[] wayPoints;
    int i = 0;
    int index;
    public List<Enemy> enemyList;
    IEnumerator Wave;
    Enemy enemy;

    [SerializeField] bool isWaveEnd;
    //public List<Enemy> EnemyList => enemyList;
    //Wave currentWave;

    void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
        StartWave();
    }

    void Update()
    {
        if(enemyList.Count == 0 && !isWaveEnd)
        {
            isWaveEnd = true;
            StartCoroutine(FreeTime());
        }
    }

    void StartWave()
    {
        enemyList = new List<Enemy>();
        i = 0;
        index = 1;
        Wave = SpawnEnemy();
        isWaveEnd = false;
        StartCoroutine(Wave);
    }

    IEnumerator SpawnEnemy()
    {
        //int spawnEnemyCount = 0;
        while(i < waveEnemyValue)
        {
            //int enemyIndex = UnityEngine.Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject clone;
            Enemy enemy;
            switch(index)
            {
                case 1:
                    clone = Instantiate(enemyPrefab);
                    enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints);
                    enemyList.Add(enemy);
                    break;
                case 2:
                    clone = Instantiate(enemyPrefab);
                    enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints);
                    enemyList.Add(enemy);
                    break;
                case 3:
                    clone = Instantiate(speedEnemyPrefab);
                    enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints);
                    enemyList.Add(enemy);
                    break;
                case 4:
                    clone = Instantiate(bigEnemyPrefab);
                    enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints);
                    enemyList.Add(enemy);
                    break;
                case 5:
                    clone = Instantiate(speedEnemyPrefab);
                    enemy = clone.GetComponent<Enemy>();
                    enemy.Setup(wayPoints);
                    enemyList.Add(enemy);
                    break;
            }
            i++;
            index++;
            if(index > 5)
            {
                index = 1;
            }
            //spawnEnemyCount++;

            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator FreeTime()
    {
        yield return new WaitForSeconds(3f);
        StartWave();
    } 
}