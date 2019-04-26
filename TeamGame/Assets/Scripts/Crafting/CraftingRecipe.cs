using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public ItemDatabase item;
    [Range(1,999)]
    public int Amount;
}

[CreateAssetMenu(fileName = "Crafting", menuName = "Crafting/Results")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Essences;
    public List<ItemAmount> Crystals;
    public List<ItemAmount> PureEssences;
    public List<ItemAmount> Results;

    public bool CanCraft(ICraftingContainer craftingContainer)
    {
        foreach (ItemAmount itemAmount in Crystals)
        {
            if(craftingContainer.ItemCounter(itemAmount.item) < itemAmount.Amount)
            {
                return false;
            }
        }
        foreach (ItemAmount itemAmount in Essences)
        {
            if (craftingContainer.ItemCounter(itemAmount.item) < itemAmount.Amount)
            {
                return false;
            }
        }
        foreach (ItemAmount itemAmount in PureEssences)
        {
            if (craftingContainer.ItemCounter(itemAmount.item) < itemAmount.Amount)
            {
                return false;
            }
        }
        return true;
    }
    public void Craft(ICraftingContainer craftingContainer)
    {
        foreach (ItemAmount itemAmount in PureEssences)
        {
            for (int i = 0; i < itemAmount.Amount; i++)
            {
                craftingContainer.RemoveItems(itemAmount.item);
            }
        }
        foreach (ItemAmount itemAmount in Crystals)
        {
            for (int i = 0; i < itemAmount.Amount; i++)
            {
                craftingContainer.RemoveItems(itemAmount.item);
            }
        }
        foreach (ItemAmount itemAmount in Essences)
        {
            for (int i = 0; i < itemAmount.Amount; i++)
            {
                craftingContainer.RemoveItems(itemAmount.item);
            }
        }
        foreach (ItemAmount itemAmount in Results)
        {
            for (int i = 0; i < itemAmount.Amount; i++)
            {
                craftingContainer.AddItems(itemAmount.item);
            }
        }
    }
}
