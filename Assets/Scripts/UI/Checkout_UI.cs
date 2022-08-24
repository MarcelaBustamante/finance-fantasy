using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Checkout_UI : MonoBehaviour
{
    
    public Text DebitLbl;
    public Text CreditLbl;
    public Text CreditLbl2;
    public Text CreditLbl3;
    public GameObject infoPannel;

    public void ToggleInfoPannel()
    {
        if (!infoPannel.activeSelf)
        {
            infoPannel.SetActive(true);
        }
        else
        {
            infoPannel.SetActive(false);
        }
    }


}
