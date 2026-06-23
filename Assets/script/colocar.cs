using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class colocar : MonoBehaviour, IDropHandler
{
    public Image imagemEsperada;       // Arraste a imagem correta para este slot no Inspector
    public GameManeger gameManager;    // Arraste o objeto GameManager para cá

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (gameManager == null)
            {
                gameManager = FindFirstObjectByType<GameManeger>();
            }

            if (gameManager != null)
            {
                gameManager.RegistrarMovimento();
            }
            else
            {
                Debug.LogWarning("GameManeger não encontrado no OnDrop de colocar.");
            }

            Image pecaArrastada = eventData.pointerDrag.GetComponent<Image>();
            arrastar dragScript = eventData.pointerDrag.GetComponent<arrastar>();

            // 1. Verifica se o slot está vazio
            if (transform.childCount == 0)
            {
                // 2. Verifica se a peça arrastada é a correta
                if (pecaArrastada == imagemEsperada)
                {
                    // É a peça correta: ENCAIXA E TRAVA
                    eventData.pointerDrag.transform.SetParent(transform);
                    eventData.pointerDrag.transform.position = transform.position;
                    
                    RectTransform dr = eventData.pointerDrag.GetComponent<RectTransform>();
                    dr.sizeDelta = GetComponent<RectTransform>().sizeDelta;
                    dr.localScale = Vector3.one;

                    // Trava a peça desativando o script de arrastar
                    if (dragScript != null) 
                    {
                        dragScript.enabled = false;
                    }
                    
                    // Desativa o raycast da peça para não interferir
                    pecaArrastada.raycastTarget = false;

                    // Avisa o GameManager que uma peça foi encaixada corretamente
                    if (gameManager != null)
                    {
                        gameManager.RegistrarPecaCorreta();
                    }
                }
                else
                {
                    Debug.Log("Peça errada! A peça retornará à origem.");
                }
            }
        }
    }
}