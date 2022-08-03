using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPannel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
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
