using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class BotaoConteudo
{
    public string[] textosVisiveis = new string[3];
    public string[] textosInvisiveis = new string[3];
    public Sprite[] imagensVisiveis = new Sprite[1];
    public Sprite[] imagensInvisiveis = new Sprite[3];
}

public class botaoroda : MonoBehaviour
{
    [Header("Referências de UI")]
    public TMP_Text[] textosVisiveis = new TMP_Text[3];
    public TMP_Text[] textosInvisiveis = new TMP_Text[3];
    public Image[] imagensVisiveis = new Image[1];
    public Image[] imagensInvisiveis = new Image[3];

    [Header("Fatias")]
    public Button[] botoesFatias;
    public bool buscarBotoesAutomaticamente = true;

    [Header("Conteúdo dos botões")]
    public BotaoConteudo[] conteudos;

    [Header("Botão de continuar")]
    public Button botaoContinuar;
    public string cenaDestino;
    public int fatiasNecessarias = 8;

    [Header("Configuração inicial")]
    public bool aplicarAoIniciar = false;
    public int conteudoInicial = 0;

    private bool[] fatiasVisitadas;
    private int fatiasUnicas;

    void Start()
    {
        RegistrarBotoes();
        InicializarContagem();

        if (!aplicarAoIniciar)
        {
            OcultarInvisiveis();
            return;
        }

        AplicarConteudo(conteudoInicial);
        AtualizarBotaoContinuar();
    }

    private void RegistrarBotoes()
    {
        if ((botoesFatias == null || botoesFatias.Length == 0) && buscarBotoesAutomaticamente)
        {
            Button[] todos = GetComponentsInChildren<Button>(true);
            var lista = new System.Collections.Generic.List<Button>();
            foreach (var botao in todos)
            {
                if (botao == null)
                    continue;

                if (botaoContinuar != null && botao.gameObject == botaoContinuar.gameObject)
                    continue;

                lista.Add(botao);
            }

            botoesFatias = lista.ToArray();
            Debug.Log($"botaoroda: encontrou {botoesFatias.Length} botões de fatia como filhos do GameObject.");
        }

        if (botoesFatias == null || botoesFatias.Length == 0)
        {
            Debug.LogWarning("botaoroda: nenhum botão de fatia atribuído. Use o Inspector para preencher 'botoesFatias' ou chame AplicarConteudo(int) manualmente no OnClick do botão.");
            return;
        }

        int maxRegistro = conteudos != null ? Mathf.Min(botoesFatias.Length, conteudos.Length) : botoesFatias.Length;
        if (conteudos == null || botoesFatias.Length != conteudos.Length)
        {
            Debug.LogWarning($"botaoroda: número de botões de fatia ({botoesFatias.Length}) não bate com número de conteúdos ({(conteudos != null ? conteudos.Length : 0)}). Registrando apenas {maxRegistro}.");
        }

        for (int i = 0; i < maxRegistro; i++)
        {
            int indice = i;
            if (botoesFatias[i] == null)
            {
                Debug.LogWarning($"botaoroda: o botão na posição {i} está nulo.");
                continue;
            }

            botoesFatias[i].onClick.RemoveAllListeners();
            botoesFatias[i].onClick.AddListener(() => AplicarConteudo(indice));
        }
    }

    private void InicializarContagem()
    {
        int total = conteudos != null ? conteudos.Length : 0;
        fatiasVisitadas = new bool[total];
        fatiasUnicas = 0;

        if (botaoContinuar != null)
            botaoContinuar.gameObject.SetActive(false);
    }

    public void AplicarConteudo(int indice)
    {
        Debug.Log($"botaoroda: AplicarConteudo chamado com indice {indice}.");

        if (conteudos == null || conteudos.Length == 0)
        {
            Debug.LogWarning("botaoroda: nenhum conteúdo configurado.");
            return;
        }

        if (indice < 0 || indice >= conteudos.Length)
        {
            Debug.LogWarning($"botaoroda: índice fora do intervalo ({indice}). Conteúdos disponíveis: {conteudos.Length}.");
            return;
        }

        BotaoConteudo item = conteudos[indice];

        AplicarTextos(textosVisiveis, item.textosVisiveis);
        AplicarTextos(textosInvisiveis, item.textosInvisiveis, true);
        AplicarImagens(imagensVisiveis, item.imagensVisiveis, false);
        AplicarImagens(imagensInvisiveis, item.imagensInvisiveis, true);
        RegistrarCliqueUnico(indice);
        AtualizarBotaoContinuar();
    }

    private void RegistrarCliqueUnico(int indice)
    {
        if (fatiasVisitadas == null || indice < 0 || indice >= fatiasVisitadas.Length)
            return;

        if (!fatiasVisitadas[indice])
        {
            fatiasVisitadas[indice] = true;
            fatiasUnicas++;
            Debug.Log($"botaoroda: fatia única registrada. Total único: {fatiasUnicas}.");
        }
    }

    private void AtualizarBotaoContinuar()
    {
        if (botaoContinuar == null)
            return;

        botaoContinuar.gameObject.SetActive(fatiasUnicas >= 8);
    }

    public void IrParaCena()
    {
        if (string.IsNullOrEmpty(cenaDestino))
        {
            Debug.LogWarning("botaoroda: cenaDestino não foi configurada.");
            return;
        }

        SceneManager.LoadScene(cenaDestino);
    }

    private void AplicarTextos(TMP_Text[] campos, string[] valores, bool ativarAoExibir = false)
    {
        if (campos == null || valores == null)
            return;

        for (int i = 0; i < campos.Length; i++)
        {
            if (campos[i] == null)
                continue;

            string texto = i < valores.Length ? valores[i] : string.Empty;
            campos[i].text = texto;

            if (ativarAoExibir)
                campos[i].gameObject.SetActive(!string.IsNullOrEmpty(texto));
        }
    }

    private void AplicarImagens(Image[] campos, Sprite[] sprites, bool ativarAoExibir)
    {
        if (campos == null || sprites == null)
            return;

        for (int i = 0; i < campos.Length; i++)
        {
            if (campos[i] == null)
                continue;

            Sprite sprite = i < sprites.Length ? sprites[i] : null;
            campos[i].sprite = sprite;
            campos[i].preserveAspect = true;

            if (sprite != null)
            {
                if (ativarAoExibir)
                    campos[i].gameObject.SetActive(true);
            }
            else if (ativarAoExibir)
            {
                campos[i].gameObject.SetActive(false);
            }
        }
    }

    private void OcultarInvisiveis()
    {
        if (textosInvisiveis != null)
        {
            foreach (var texto in textosInvisiveis)
            {
                if (texto != null)
                    texto.gameObject.SetActive(false);
            }
        }

        if (imagensInvisiveis != null)
        {
            foreach (var img in imagensInvisiveis)
            {
                if (img != null)
                    img.gameObject.SetActive(false);
            }
        }
    }
}
