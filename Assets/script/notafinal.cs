using UnityEngine;
using TMPro; // Necessário para usar o TextMeshPro
using System.Collections;

public class notaFinal : MonoBehaviour 
{
    private int idTema;

    public TMP_Text txtInfoTema;

    private int notaF;
    private int acertos;

    // Use this for initialization
    void Start () 
    {
        idTema = PlayerPrefs.GetInt("idTema");
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosUltimaPartida");

        // A propriedade correta para acessar o texto no TMP é .text
        txtInfoTema.text = "Acertou " + acertos.ToString() + " de 4 perguntas";
    }
}