using UnityEngine;
using UnityEngine.EventSystems;

public class DragFood : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isSaudavel;
    public bool foiColocado = false;
    private Vector3 startPosition;
    private Transform startParent;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        startPosition = transform.position;
        startParent = transform.parent;
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (foiColocado) return;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (foiColocado) return;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (!foiColocado)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}