using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPannel;
    public GameObject removeItem;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();
    private int itemSelected = -1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
        Refresh();
    }

    public void ToggleInventory()
    {
        if (!inventoryPannel.activeSelf)
        {
            inventoryPannel.SetActive(true);
            //Refresh();       
        }
        else
        {
            inventoryPannel.SetActive(false);
        }
    }


    void Refresh()
    {
        //if(slots.Count == player.inventory.slots.Count)
        //{
            for( int i = 0; i < slots.Count; i++)
            {
                if (slots[i])
                {
                    if (player.inventory.slots[i].type != CollectableType.NONE)
                    {
                        slots[i].SetItem(player.inventory.slots[i]);
                    }
                    else
                    {
                        slots[i].SetEmpty();
                    }
                }
            }
        // }
    }

    public void SelectItem(int slotID)
    {
        if (slots[slotID].isEmpty) return;
        if (itemSelected == slotID)
        {
            disableTrash();
        }
        else
        {
            itemSelected = slotID;
            removeItem.SetActive(true);
        }

    }

    public void Remove()
    {
        Collectable itemToDrop = GameManager.instance.itemManager.GetItemByType(
            player.inventory.slots[itemSelected].type);
        if (itemSelected != -1 && itemToDrop != null)
        {
            player.inventory.Remove(itemSelected);
            disableTrash();
        }
    }

    private void disableTrash()
    {
        itemSelected = -1;
        removeItem.SetActive(false);

    }
}
