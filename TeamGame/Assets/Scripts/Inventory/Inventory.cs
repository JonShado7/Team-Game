using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, ICraftingContainer
{
    public static Inventory instance;

    [Header("==========Inventory==========")]
    //Setting the array of Items in the ItemDatabase to 35
    public ItemDatabase[] itemDatabase = new ItemDatabase[36];
    //Setting an inventory slots list to a new list for the slots
    public InventorySlots[] inventorySlots = new InventorySlots[36];
    //Referencing the ItemAmount struct in the Crafting Recipe
    ItemAmount itemAmount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        Debug.Log("Dont Fucking destroy this!");
    }

    private void Start()
    {
        UpdateImageUI();
    }

    private bool Add(ItemDatabase item)
    {
        //This is going to loop through the length of the Item Database
        for (int i = 0; i < itemDatabase.Length; i++)
        {

            if (itemDatabase[i] == null)
            {
                itemDatabase[i] = item;
                return true;
            }
        }
        return false;
    }

    public void UpdateImageUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            // Looping through the Slots
            inventorySlots[i].UpdateSlot();
        }
    }

    public void AddItem(ItemDatabase item)
    {
        bool hasAdded = true;

        if (hasAdded)
        {
            UpdateImageUI();
        }
    }

    public void RemoveItem(ItemDatabase item)
    {
        bool hasRemoved = true;

        if (hasRemoved)
        {
            UpdateImageUI();
        }
    }

    private bool Remove(ItemDatabase item)
    {
        for (int i = 0; i < itemDatabase.Length; i++)
        {

            if (itemDatabase[i] == item)
            {
                itemDatabase[i] = null;
                return true;
            }
        }
        return false;
    }

    public bool ContainsItems(ItemDatabase item)
    {
        for (int i = 0; i < itemDatabase.Length; i++)
        {

            if (itemDatabase[i] == item)
            {
                
                return true;
            }
        }
        return false;
    }

    public int ItemCounter(ItemDatabase item)
    {
        int number = 0;
        //This is going to loop through the length of the Item Database
        for (int i = 0; i < itemDatabase.Length; i++)
        {

            if (itemDatabase[i] == null)
            {
                itemDatabase[i] = item;
                number++;
                number += itemAmount.Amount++;
                
            }
        }
        return number;
    }

    public bool RemoveItems(ItemDatabase item)
    {
        //This is going to loop through the length of the Item Database
        for (int i = 0; i < itemDatabase.Length; i++)
        {

            if (itemDatabase[i] == item)
            {
                itemDatabase[i] = null;
                itemAmount.Amount--;
                Debug.Log(itemAmount.Amount);
                return true;
            }
        }
        return false;
    }

    public bool AddItems(ItemDatabase item)
    {
        //This is going to loop through the length of the Item Database
        for (int i = 0; i < itemDatabase.Length; i++)
        {

            if (itemDatabase[i] == null)
            {
                itemDatabase[i] = item;
                itemAmount.Amount++;
                Debug.Log(itemAmount.Amount);
                return true;
            }
        }
        return false;
    }
}
