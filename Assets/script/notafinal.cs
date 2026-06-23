using UnityEngine;
using TMPro; // Necessário para usar o TextMeshPro
using System.Collections;

public class notaFinal : MonoBehaviour 
{
    private int idTema;

    public TMP_Text txtInfoTema;

    private int notaF;
    private int acertos;
    private int movimentos;
    private int tipoFinalizacao;

    // Use this for initialization
    void Start () 
    {
        idTema = PlayerPrefs.GetInt("idTema");
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosUltimaPartida");
        movimentos = PlayerPrefs.GetInt("movimentos");
        tipoFinalizacao = PlayerPrefs.GetInt("tipoFinalizacao", 0);

        if (tipoFinalizacao == 2)
        {
            txtInfoTema.text = "Puzzle finalizado!\nMovimentos: " + movimentos.ToString();
        }
        else
        {
            int totalQuestoes = PlayerPrefs.GetInt("totalQuestoesUltimaPartida", 0);
            if (totalQuestoes <= 0)
            {
                totalQuestoes = 4;
            }
            txtInfoTema.text = "Quiz finalizado!\nAcertos: " + acertos.ToString() + " de " + totalQuestoes.ToString();
        }
    }
}