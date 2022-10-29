using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using FinanceFantasy.Bank;

public class ShopManager : MonoBehaviour
{

    public int[,] shopItems = new int[5, 5];
    public float coins;
    public TextMeshProUGUI CoinsTXT;
    public TextMeshProUGUI errorTxt;
    public GameObject checkoutPannel;
    public GameObject checkoutUI;
    private int itemID;
    
    [SerializeField] private Dictionary<string, GameObject> collectables;
    GameObject ButtonRef;
    public Player player;

    void Start()
    {
        coins = GameManager.instance.GetMoney();
        CoinsTXT.text = "Dinero:" + coins.ToString();
        //ID's
        //Zanahoria
        shopItems[1, 1] = 1;
        //Tomate
        shopItems[1, 2] = 2;
        //lechuga
        shopItems[1, 3] = 3;
        //maiz
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

       // shopItems
    }


    public void Buy(float totalPrice, int quota)
    {
        errorTxt.text = "";
        this.ToggleCheckoutPannel();
        if (coins >= totalPrice && quota == 0)
        {
           
            //cliente paga
            coins -= totalPrice;
            shopItems[3, itemID]++;
            CoinsTXT.text = "Coins:" + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, itemID].ToString();
            //se actualiza el precio en game manager
            GameManager.instance.pesos = coins;
            //se lleva el producto en su inventario y ademas se suma el producto al game manager
            AddProduct(itemID);
        }
        if(quota > 0  && quota < 4)
        {
            bool haveCrediCard = false;
            //TODO:
           // if (GameManager.instance.AQUIVAMETODOPARASABERSITIENETARJETAONO !=null)
            {
                haveCrediCard = true;
            }
            if (!haveCrediCard)
            {
                errorTxt.text = "Ustend no tiene tarjeta de crédito, se recomienda ir al banco y pedir una";
            }
            else
            {
                errorTxt.text = "";
                //cliente paga
                //TODO:agregar el descuento de  la tarjeta de crédito totalPrice;
                shopItems[3, itemID]++;
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, itemID].ToString();
                //se actualiza el precio en game manager
                GameManager.instance.pesos = coins;
                //se lleva el producto en su inventario y ademas se suma el producto al game manager
                AddProduct(itemID);
            }
        }
       if(coins < totalPrice)
        {
            errorTxt.text = "Fondos insuficientes.";
        }
    }

    public void Checkout()
    {
        ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (ButtonRef)
        {
            itemID = ButtonRef.GetComponent<ButtonInfo>().ItemID;
            float price = shopItems[2, itemID];
            //CFT costo financiero total se toma 200 pero normalmente es mas
            float priceIn2Quotas = (price + (price * 2)) / 2;
            float priceIn3Quotas = (price + (price * 2)) / 3;
            checkoutUI.GetComponent<Checkout_UI>().DebitLbl.text = "Contado $" + price.ToString();
            checkoutUI.GetComponent<Checkout_UI>().CreditLbl.text = "Un pago $" + price.ToString();
            checkoutUI.GetComponent<Checkout_UI>().CreditLbl2.text = "Dos pagos $" + priceIn2Quotas.ToString();
            checkoutUI.GetComponent<Checkout_UI>().CreditLbl3.text = "Tres pagos $" + priceIn3Quotas.ToString();
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

    private void AddProduct(int itemID)
    {
        Collectable coll;
        switch (itemID)
        {
            case 1:
                coll = Instantiate(GameManager.instance.itemManager.GetItemByType(CollectableType.CARROTE_SEED));
                GameManager.instance.szana += 1;
                GameManager.instance.inventory.Add(coll);
                break;

            case 2:
                coll = Instantiate(GameManager.instance.itemManager.GetItemByType(CollectableType.TOMATOES_SEED));
                GameManager.instance.stomate += 1;
                GameManager.instance.inventory.Add(coll);
                break;

            case 3:
                coll = Instantiate(GameManager.instance.itemManager.GetItemByType(CollectableType.LETTUCE_SEED));
                GameManager.instance.slechuga += 1;
                GameManager.instance.inventory.Add(coll);
                break;

            case 4:
                coll = Instantiate(GameManager.instance.itemManager.GetItemByType(CollectableType.CORN_SEED));
                GameManager.instance.schoclo += 1;
                GameManager.instance.inventory.Add(coll);
                break;
            default:
                errorTxt.text = "Producto inexistente";
                break;
        }
    }
}


