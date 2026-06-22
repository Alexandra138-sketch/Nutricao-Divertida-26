using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class arrastar : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public arrastar gerenciador; // Arraste seu PuzzleManager aqui no Inspector
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;
    private Transform startParent;
    public bool estaEncaixada = false; // Controle para saber se já encaixou

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (estaEncaixada) return; // Se já encaixou, não arrasta mais

        startPosition = rectTransform.position;
        startParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (estaEncaixada) return;
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Se após o fim do arraste a peça não mudou de pai, ela falhou
        if (transform.parent == startParent)
        {
            rectTransform.position = startPosition;
        }
    }
}