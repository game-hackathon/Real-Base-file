using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AppearBanner : MonoBehaviour
{

    public Slider slTimer;
    public Movement2D movement;
    bool isArrivalEventTriggered = false;
    public float Speed;
    [SerializeField] float DownValue = 0.0f;
    [SerializeField] float Resttime = 0f;
    public GameObject Bannerselect;
    static float enemySpeed;
    static float speedEnemySpeed;
    static float bigEnemySpeed;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject speedEnemyPrefab;
    [SerializeField] GameObject bigEnemyPrefab;

    Vector2 target = new Vector2(490, 382);

    void Start()
    {
        movement = GetComponent<Movement2D>();
        StartCoroutine(ChangeVariableForSeconds(10f));
        enemySpeed = enemyPrefab.GetComponent<Movement2D>().moveSpeed;
        speedEnemySpeed = speedEnemyPrefab.GetComponent<Movement2D>().moveSpeed;
        bigEnemySpeed = bigEnemyPrefab.GetComponent<Movement2D>().moveSpeed;
    }

    IEnumerator ChangeVariableForSeconds(float seconds)
    {
        float originalValue1 = enemySpeed;
        float originalValue2 = speedEnemySpeed;
        float originalValue3 = bigEnemySpeed;

        enemySpeed *= 1.5f;
        speedEnemySpeed *= 1.5f;
        bigEnemySpeed *= 1.5f;

        yield return new WaitForSeconds(seconds);

        enemySpeed = originalValue1;
        speedEnemySpeed = originalValue2;
        bigEnemySpeed = originalValue3;
    }
    void moving()
    {
        transform.position =
            Vector2.Lerp(transform.position, target, Speed);
    }

    void Update()
    {
        if (slTimer.value > DownValue)
        {
            if (!isArrivalEventTriggered)
            {
                moving();
                StartCoroutine(WaitForIt());
            }
        }

        IEnumerator WaitForIt()
        {
            yield return new WaitForSeconds(4.0f);
            target = new Vector2(1500, 382);
            moving();
        }

        if(slTimer.value > Resttime)
        {
            StartCoroutine(ChangeVariableForSeconds(3));
        }

    }
}
