using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPannel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPannel.activeSelf)
        {
            inventoryPannel.SetActive(true);
        }
        else
        {
            inventoryPannel.SetActive(false);
        }
    }
}
