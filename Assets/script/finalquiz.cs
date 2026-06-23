using UnityEngine;
using TMPro;

public class finalquiz : MonoBehaviour
{
    public TMP_Text textoResultado;
    public int totalPerguntas = 4;

    void Start()
    {
        int score = PlayerPrefs.GetInt("score", 0);
        textoResultado.text = "Acertaste " + score + " de " + totalPerguntas + " perguntas!";
        PlayerPrefs.SetInt("score", 0); // reset para próxima vez
    }
}