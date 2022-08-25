using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin_UI : MonoBehaviour
{
    public TextMeshProUGUI CoinsTXT;

    // Update is called once per frame
    void Update()
    {
        CoinsTXT.text = "Dinero: " + GameManager.instance.GetMoney().ToString();
    }
}
