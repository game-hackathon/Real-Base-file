using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuyer2 : MonoBehaviour
{
    private Vector3 _scale;
    private bool isGenerating = false;
    public GameObject Game;

    // Start is called before the first frame update
    void Start()
    {
        _scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGenerating)
        {
            Vector3 Pointer = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Pointer.x, Pointer.y + 1f, 0);

            if (Input.GetMouseButton(0))
            {
                isGenerating = false;
            }
        }
        else if (!isGenerating)
        {
            transform.position = new Vector3(12.8f, -4.22f, 0);
        }
    }

    // private void OnMouseEnter()
    // {
        // transform.localScale = _scale / 1.2f;
    // }

    private void OnMouseExit()
    {
        transform.localScale = _scale;
    }

    private void OnMouseUp()
    {
        if (!isGenerating && Game.GetComponent<GameController>().Coin >= 150)
        {
            Game.GetComponent<GameController>().TowerType = 2;
            isGenerating = true;
            Game.GetComponent<GameController>().Coin -= 150;
        }
    }
}
