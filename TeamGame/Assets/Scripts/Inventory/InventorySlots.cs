using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public ItemDatabase item;
    public GameObject imageItem;

    public void UpdateSlot()
    {
        if(item != null)
        {
            imageItem.GetComponent<Image>().sprite = item.itemImage;
            imageItem.SetActive(true);
        }
        else
        {
            imageItem.SetActive(false);
        }
    }
}
