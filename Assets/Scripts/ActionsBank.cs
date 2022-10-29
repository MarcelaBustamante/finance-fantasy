using System.Collections;
using System.Collections.Generic;
using FinanceFantasy.Bank;
using UnityEngine;

public class ActionsBank : MonoBehaviour
{
    private BankManager bankmanager;


    // Update is called once per frame
    void Update()
    {
        GameObject bankManagerObj = GameObject.Find("BankManager");


        if (bankmanager == null)
            try
            {
                bankmanager = bankManagerObj.GetComponent<BankManager>();
            }
            catch
            {
                //Debug.Log("no se puede instanciar el objeto");
            }

    }

    public void pedirCredito()
    {
        GameObject bankManagerObj = GameObject.Find("BankManager");
        bankmanager.TakeLoan();
       
    }

    public void pedirTarjeta()
    {
        GameObject bankManagerObj = GameObject.Find("BankManager");
        bankmanager.TakeCredit();
    }

    public void pedirSeguro()
    {
        GameObject bankManagerObj = GameObject.Find("BankManager");
        bankmanager.TakeInsurance();
    }
}
