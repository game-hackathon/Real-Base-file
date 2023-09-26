using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject Game;
    public TMP_Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        // coinText = GetComponentInChildren<TextMeshPro>();
        InvokeRepeating("CoinIncrement", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.SetText(Game.GetComponent<GameController>().Coin.ToString());
    }

    void CoinIncrement()
    {
        Game.GetComponent<GameController>().Coin += 2;
    }
}
