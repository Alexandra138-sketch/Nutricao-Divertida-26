using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class ContentSet
{
    [TextArea]
    public string texto; // compatibilidade com entradas antigas
    public List<string> textos = new List<string>(); // múltiplos campos de texto
    public TMP_Text[] textTargets; // referências diretas a UI Text (arraste aqui componentes TMP_Text)
    public GameObject[] textTargetObjects; // alternativa: arraste GameObjects que contenham TMP_Text
    public Sprite[] sprites;
}

public class BotaoTrocaConteudo : MonoBehaviour
{
    public Button botao; // botão que dispara a troca
    [Header("Text Targets (optional)")]
    public TMP_Text targetText; // (legacy) texto único
    public TMP_Text[] targetTexts; // múltiplos campos de texto

    [Header("Image Targets")]
    public Image[] targetImages; // imagens a serem atualizadas (ordem corresponde a ContentSet.sprites)

    public List<ContentSet> conjuntos = new List<ContentSet>();
    public int inicioIndex = 0; // índice inicial
    private int currentIndex = 0;

    void Awake()
    {
        currentIndex = Mathf.Clamp(inicioIndex, 0, Mathf.Max(0, conjuntos.Count - 1));
    }

    void OnEnable()
    {
        if (botao != null)
            botao.onClick.AddListener(OnButtonClicked);

        ApplyCurrent();
    }

    void OnDisable()
    {
        if (botao != null)
            botao.onClick.RemoveListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        if (conjuntos == null || conjuntos.Count == 0) return;

        currentIndex = (currentIndex + 1) % conjuntos.Count;
        ApplyCurrent();
    }

    public void ApplyCurrent()
    {
        if (conjuntos == null || conjuntos.Count == 0) return;

        var set = conjuntos[currentIndex];

        // Apply texts: prioridade para textTargets (componentes) definidos no próprio conjunto
        if (set.textTargets != null && set.textTargets.Length > 0)
        {
            for (int i = 0; i < set.textTargets.Length; i++)
            {
                var txtComp = set.textTargets[i];
                if (txtComp == null) continue;

                if (i < set.textos.Count)
                {
                    txtComp.text = set.textos[i];
                    txtComp.gameObject.SetActive(true);
                }
                else if (!string.IsNullOrEmpty(set.texto) && i == 0)
                {
                    txtComp.text = set.texto;
                    txtComp.gameObject.SetActive(true);
                }
                else
                {
                    txtComp.text = "";
                }
            }
        }
        // se não houver componentes, tenta usar GameObjects com TMP_Text
        else if (set.textTargetObjects != null && set.textTargetObjects.Length > 0)
        {
            for (int i = 0; i < set.textTargetObjects.Length; i++)
            {
                var go = set.textTargetObjects[i];
                if (go == null) continue;
                var txtComp = go.GetComponent<TMP_Text>();
                if (txtComp == null) continue;

                if (i < set.textos.Count)
                {
                    txtComp.text = set.textos[i];
                    txtComp.gameObject.SetActive(true);
                }
                else if (!string.IsNullOrEmpty(set.texto) && i == 0)
                {
                    txtComp.text = set.texto;
                    txtComp.gameObject.SetActive(true);
                }
                else
                {
                    txtComp.text = "";
                }
            }
        }
        // senão usa os targets globais (targetTexts / targetText)
        else if (targetTexts != null && targetTexts.Length > 0)
        {
            for (int i = 0; i < targetTexts.Length; i++)
            {
                if (i < set.textos.Count && targetTexts[i] != null)
                {
                    targetTexts[i].text = set.textos[i];
                    targetTexts[i].gameObject.SetActive(true);
                }
                else if (targetTexts[i] != null)
                {
                    targetTexts[i].text = "";
                }
            }
        }
        else if (targetText != null)
        {
            targetText.text = string.IsNullOrEmpty(set.texto) ? (set.textos.Count > 0 ? set.textos[0] : "") : set.texto;
        }

        // Apply images
        if (targetImages != null && set.sprites != null)
        {
            for (int i = 0; i < targetImages.Length; i++)
            {
                if (i < set.sprites.Length && set.sprites[i] != null)
                {
                    targetImages[i].sprite = set.sprites[i];
                    targetImages[i].enabled = true;
                }
                else if (targetImages[i] != null)
                {
                    // Se não há sprite definido, esconde a imagem
                    targetImages[i].enabled = false;
                }
            }
        }
    }

    // Método público para pular diretamente para um índice (útil via Inspector/other scripts)
    public void GoToIndex(int idx)
    {
        if (conjuntos == null || conjuntos.Count == 0) return;
        currentIndex = Mathf.Clamp(idx, 0, conjuntos.Count - 1);
        ApplyCurrent();
    }
}