using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Checkout_UI : MonoBehaviour
{
    
    public Text DebitLbl;
    public Text CreditLbl;
    public Text CreditLbl2;
    public Text CreditLbl3;
    public TextMeshProUGUI totalTxt;
    public GameObject infoPannel;
    private float totalPrice = 0.0F;
    private int quota = 0;
    public ShopManager shopManager;

    public void Buy()
    {
        shopManager.Buy(totalPrice, quota);
    }

    public void ToggleInfoPannel()
    {
        if (!infoPannel.activeSelf)
        {
            totalTxt.SetText("Total:0");
            infoPannel.SetActive(true);
            
        }
        else
        {
            infoPannel.SetActive(false);
        }
    }

    public void updateTotal(int _quota)
    {
        quota = _quota;
        if(quota == 0)
        {
            totalPrice = getTotalPrice(DebitLbl.text, 1);
            totalTxt.text ="Total :" + totalPrice.ToString();
        }
        else
        {
            switch (quota)
            {
                case 1:
                    totalPrice = getTotalPrice(CreditLbl.text, 1);
                    break;
                case 2:
                    totalPrice = getTotalPrice(CreditLbl2.text, 2);
                    break;
                case 3:
                    totalPrice = getTotalPrice(CreditLbl3.text, 3);
                    break;
                default:
                    totalPrice = getTotalPrice(CreditLbl.text, 0);
                    break;
            }

            totalTxt.text = "Total :" + totalPrice.ToString();
        }
    }

    private float getTotalPrice(string valueTOConvert, int quota)
    {
        string numberOnly = Regex.Replace(valueTOConvert, "[^0-9]", "");
        float converToFload = float.Parse(numberOnly);
        return converToFload * quota;
    }

}
