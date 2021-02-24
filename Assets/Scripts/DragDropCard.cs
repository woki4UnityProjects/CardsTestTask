using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Transform hand;
    
    private RectTransform _rectTransform;
    private Image _image;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
        transform.SetParent(canvas.transform);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DropPanel panel = GetComponentInParent<DropPanel>();
        if(!panel)
        {
            transform.SetParent(hand);
            _image.raycastTarget = true;
        }
    }
}
