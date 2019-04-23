using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemDatabase : ScriptableObject
{
    // Variables that will be deafult for new items that are created
    public string itemName = "New Item";
    public string description = "New Description";
    public Sprite itemImage;
    public int price = 0;
    public int sellPrice = 0;
    public ItemType type = ItemType.Default;
}
