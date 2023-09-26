using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    public GameObject TowerPrefab;
    public GameObject TowerPrefab2;
    public GameObject TowerPrefab3;
    public GameObject Game;
    private bool isExist = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseOver()
    {
        if (Game.GetComponent<GameController>().TowerType == 1)
        {
            if (Game.GetComponent<GameController>().TowerLimit >= 20)
            {
                Debug.Log("20 towers are LIMIT.");
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("TowerGenerator: Generated!");

                    var position = transform.position;
                    Instantiate(TowerPrefab, new Vector3(position.x, position.y, position.z), Quaternion.identity);
                    Game.GetComponent<GameController>().TowerLimit++;
                    Game.GetComponent<GameController>().TowerType = 0;
                }
            }
        }
        else if (Game.GetComponent<GameController>().TowerType == 2)
        {
            if (Game.GetComponent<GameController>().TowerLimit >= 20)
            {
                Debug.Log("20 towers are LIMIT.");
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var position = transform.position;
                    Instantiate(TowerPrefab2, new Vector3(position.x, position.y, position.z), Quaternion.identity);
                    Game.GetComponent<GameController>().TowerLimit++;
                    Game.GetComponent<GameController>().TowerType = 0;
                }
            }
        }
        else if (Game.GetComponent<GameController>().TowerType == 3)
        {
            if (Game.GetComponent<GameController>().TowerLimit >= 20)
            {
                Debug.Log("20 towers are LIMIT.");
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var position = transform.position;
                    Instantiate(TowerPrefab3, new Vector3(position.x, position.y, position.z), Quaternion.identity);
                    Game.GetComponent<GameController>().TowerLimit++;
                    Game.GetComponent<GameController>().TowerType = 0;
                }
            }
        }
    }
}