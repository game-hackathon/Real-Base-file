using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSystem : MonoBehaviour
{
    
    [SerializeField] float powerUpPercentage = 5f;
    [SerializeField] float powerUpTime;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject speedEnemyPrefab;
    [SerializeField] GameObject bigEnemyPrefab;

    public float enemyHealth;
    public float speedEnemyHealth;
    public float bigEnemyHealth;
    public float enemySpeed;
    public float speedEnemySpeed;
    public float bigEnemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyPrefab.GetComponent<Enemy>().health;
        speedEnemyHealth = speedEnemyPrefab.GetComponent<Enemy>().health;
        bigEnemyHealth = bigEnemyPrefab.GetComponent<Enemy>().health;
        enemySpeed = enemyPrefab.GetComponent<Movement2D>().moveSpeed;
        speedEnemySpeed = speedEnemyPrefab.GetComponent<Movement2D>().moveSpeed;
        bigEnemySpeed = bigEnemyPrefab.GetComponent<Movement2D>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PowerUp();
    }

    void PowerUp()
    {
        if(Time.time >= powerUpTime)
        {
            powerUpTime += 5f;
            enemyHealth += enemyHealth * (powerUpPercentage / 100);
            speedEnemyHealth += speedEnemyHealth * (powerUpPercentage / 100);
            bigEnemyHealth += bigEnemyHealth * (powerUpPercentage / 100);
        }
    }
}
