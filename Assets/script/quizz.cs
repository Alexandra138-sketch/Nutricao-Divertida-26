using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour
{
    public int idTema;

    public TMP_Text pergunta;
    public TMP_Text respostaA;
    public TMP_Text respostaB;
    public TMP_Text respostaC;
    public TMP_Text respostaD;
    public TMP_Text infoRespostas;

    public string[] perguntas;       // armazena todas as perguntas
    public string[] alternativaA;     // armazena todas as alternativas A
    public string[] alternativaB;     // armazena todas as alternativas B
    public string[] alternativaC;     // armazena todas as alternativas C
    public string[] alternativaD;     // armazena todas as alternativas D
    public string[] corretas;        // armazena as alternativas corretas

    private int idPergunta;

    private float acertos;
    private float questoes;
    private float media;

    
    void Start()
    {
        idPergunta = 0;
        questoes = perguntas.Length;

        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];

        infoRespostas.text = "Pergunta " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + ".";
    }
    public void resposta(string alternativa)
    {
        if (alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        else if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        else if (alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        proximaPergunta();
    }

    void proximaPergunta()
    {
    idPergunta += 1;

    if (idPergunta <= (questoes - 1))
    {
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];

        infoRespostas.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";
    }
    else
    {

        SceneManager.LoadScene("notaFinal");

    }

    }
}

    
