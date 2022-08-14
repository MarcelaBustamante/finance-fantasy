using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_UI : MonoBehaviour
{
    private bool popUpAskBuy = false;
    // Start is called before the first frame update
    void Awake()
    {
       
    }

   public void setPopUpBuyTrue()
    {
        popUpAskBuy = true;
    }
}
