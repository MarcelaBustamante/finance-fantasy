using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{

    public int[,] shopItems = new int[5, 5];
    public float coins;
    public TextMeshProUGUI CoinsTXT;
    public GameObject checkoutPannel;
    public GameObject checkoutUI;
  

    void Start()
    {
        CoinsTXT.text = "Coins:" + coins.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 200;
        shopItems[2, 3] = 300;
        shopItems[2, 4] = 400;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

    }


    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "Coins:" + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

        }


    }

    public void Checkout()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (ButtonRef)
        {
            float price = shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            //CFT costo financiero total se toma 200 pero normalmente es mas
            float priceIn2Quotas = (price + (price * 2)) / 2;
            float priceIn3Quotas = (price + (price * 2)) / 3;
            checkoutUI.GetComponent<Checkout_UI>().DebitLbl.text = "1 X $" + price.ToString();
            checkoutUI.GetComponent<Checkout_UI>().CreditLbl.text = "1 X $" + price.ToString();
            checkoutUI.GetComponent<Checkout_UI>().CreditLbl2.text = "2 X $" + priceIn2Quotas.ToString();
            checkoutUI.GetComponent<Checkout_UI>().CreditLbl3.text = "3 X $" + priceIn3Quotas.ToString();
            ToggleCheckoutPannel();
        }
    }

    public void ToggleCheckoutPannel()
    {
        if (!checkoutPannel.activeSelf)
        {
            checkoutPannel.SetActive(true);
        }
        else
        {
            checkoutPannel.SetActive(false);
        }
    }
}
