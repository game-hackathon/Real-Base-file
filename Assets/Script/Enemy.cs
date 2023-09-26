using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int wayPointCount;
    Transform[] wayPoints;
    int currentIndex = 0;
    [SerializeField] int type;
    Movement2D movement2D;
    MonsterSpwan spwan;
    PowerUpSystem powerUp;
    public float health;

    void Awake()
    {
        powerUp = FindObjectOfType<PowerUpSystem>();
        spwan = FindObjectOfType<MonsterSpwan>();
    }

    void Update()
    {
        Health();
    }

    public void Setup(Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();

        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(OnMove());
    }
    IEnumerator OnMove()
    {
        NextMoveTo();

        while(true)
        {
            //transform.Rotate(Vector3.forward * 10);

            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                NextMoveTo();
            }
            yield return null;
        }
    }

    void NextMoveTo()
    {
        if(currentIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;

            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position-transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else
        {
            spwan.enemyList.Remove(spwan.enemyList[0]);
            Destroy(gameObject);
        }
    }

    void Attack(float AD)
    {
        health -= AD;
        if(health <= 0)
        {
            spwan.enemyList.Remove(spwan.enemyList[0]);
            Destroy(gameObject);
        }
    }

    void Health()
    {
        switch(type)
        {
            case 1:
                health = powerUp.enemyHealth;
                break;
            case 2:
                health = powerUp.speedEnemyHealth;
                break;
            case 3:
                health = powerUp.bigEnemyHealth;
                break;
        }
    }
}
