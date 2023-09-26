using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private GameObject Game;
    private int sellPrice = 100;
    private int currentLevel = 1;
    private int L1Damage = 2;
    private int L2Damage = 5;
    private int L3Damage = 10;
    private int L4Damage = 20;
    private int L5Damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi, I'm Tower!");
        Game = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(gameObject);
            Game.GetComponent<GameController>().Coin += (int)Math.Ceiling(sellPrice * 0.7f);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentLevel == 1 && Game.GetComponent<GameController>().Coin >= 50)
            {
                currentLevel++;
                Game.GetComponent<GameController>().Coin -= 50;
                sellPrice += 50;
            }
            else if (currentLevel == 2 && Game.GetComponent<GameController>().Coin >= 250)
            {
                currentLevel++;
                Game.GetComponent<GameController>().Coin -= 250;
                sellPrice += 250;
            }
            else if (currentLevel == 3 && Game.GetComponent<GameController>().Coin >= 1000)
            {
                currentLevel++;
                Game.GetComponent<GameController>().Coin -= 1000;
                sellPrice += 1000;
            }
            else if (currentLevel == 4 && Game.GetComponent<GameController>().Coin >= 3000)
            {
                currentLevel++;
                Game.GetComponent<GameController>().Coin -= 3000;
                sellPrice += 3000;
            }
        }
    }
}
