using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Transform originalParent;
    public bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(Inventory.instance.itemDatabase[transform.parent.GetSiblingIndex()] != null)
        {
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                isDragging = true;
                originalParent = transform.parent;
                transform.SetParent(transform.parent.parent);
                GetComponent<CanvasGroup>().blocksRaycasts = false;

            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(Inventory.instance.itemDatabase[originalParent.transform.GetSiblingIndex()] != null && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Inventory.instance.itemDatabase[transform.parent.GetSiblingIndex()] != null && eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = false;
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

}
