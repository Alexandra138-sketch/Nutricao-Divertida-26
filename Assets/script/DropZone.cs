using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropZone : MonoBehaviour, IDropHandler
{
    public bool isSaudavel;
    public TextMeshProUGUI textCorretos;
    public TextMeshProUGUI textErros;

    private static int corretos = 0;
    private static int erros = 0;

    public void OnDrop(PointerEventData eventData)
    {
        DragFood food = eventData.pointerDrag.GetComponent<DragFood>();
        if (food == null || food.foiColocado) return;

        if (food.isSaudavel == isSaudavel)
        {
            corretos++;
            textCorretos.text = "Corretos: " + corretos;
            food.transform.SetParent(transform);
            food.transform.SetAsLastSibling();
            food.foiColocado = true;
        }
        else
        {
            erros++;
            textErros.text = "Erros: " + erros;
        }
    }
}