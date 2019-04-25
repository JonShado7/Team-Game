using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlots : MonoBehaviour, IDropHandler
{
    public GameObject imageItem;


    public void UpdateSlot()
    {
        if(Inventory.instance.itemDatabase[transform.GetSiblingIndex()] != null)
        {
            imageItem.GetComponent<Image>().sprite = Inventory.instance.itemDatabase[transform.GetSiblingIndex()].itemImage;
            imageItem.SetActive(true);
        }
        else
        {
            imageItem.SetActive(false);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemDatabase droppedItem = Inventory.instance.itemDatabase[eventData.pointerDrag.GetComponent<ItemDragManager>().transform.parent.GetSiblingIndex()];
        if(eventData.pointerDrag.transform.parent.name == gameObject.name)
        {
            return;
        }
        if(Inventory.instance.itemDatabase[transform.GetSiblingIndex()] == null)
        {
            Inventory.instance.itemDatabase[transform.GetSiblingIndex()] = droppedItem;
            Inventory.instance.itemDatabase[eventData.pointerDrag.GetComponent<ItemDragManager>().transform.parent.GetSiblingIndex()] = null;
            Inventory.instance.UpdateImageUI();
        }
        else
        {
            ItemDatabase temItem = Inventory.instance.itemDatabase[transform.GetSiblingIndex()];
            Inventory.instance.itemDatabase[transform.GetSiblingIndex()] = droppedItem;
            Inventory.instance.itemDatabase[eventData.pointerDrag.GetComponent<ItemDragManager>().transform.parent.GetSiblingIndex()] = temItem;
            Inventory.instance.UpdateImageUI();
        }
    }
}
