using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Setting the array of Items in the ItemDatabase to 35
    public ItemDatabase[] itemDatabase = new ItemDatabase[36];
    //Setting an inventory slots list to a new list for the slots
    public List<InventorySlots> inventorySlots = new List<InventorySlots>();

    private bool Add(ItemDatabase item)
    {
        //This is going to loop through the length of the Item Database
        for (int i = 0; i < itemDatabase.Length; i++)
        {

            if (itemDatabase[i] == null)
            {
                itemDatabase[i] = item;
                inventorySlots[i].item = item;
                return true;
            }
        }
        return false;
    }

    public void UpdateImageUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            // Looping through the Slots
            inventorySlots[i].UpdateSlot();
        }
    }

    public void AddItem(ItemDatabase item)
    {
        bool hasAdded = Add(item);

        if (hasAdded)
        {
            UpdateImageUI();
        }
    }
}
