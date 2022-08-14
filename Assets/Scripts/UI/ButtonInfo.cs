using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{

    public int ItemID;
    public TextMeshProUGUI PirceTxt;
    public TextMeshProUGUI QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {       
        PirceTxt.text = "Price: $" + ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        QuantityTxt.text = ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();
    }
}
