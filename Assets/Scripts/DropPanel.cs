using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPanel : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            RectTransform cardRect = eventData.pointerDrag.GetComponent<RectTransform>();
            cardRect.SetParent(transform, false);
            cardRect.transform.position = transform.position;
        }
    }
}
