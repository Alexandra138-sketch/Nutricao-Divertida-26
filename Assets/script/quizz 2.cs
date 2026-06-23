using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    public GameObject[] paineis; // um painel por pergunta
    private int atual = 0;

    public void Correto()
    {
        ProximaPergunta();
    }

    public void Errado()
    {
        ProximaPergunta();
    }

    void ProximaPergunta()
    {
        paineis[atual].SetActive(false);
        atual++;
        if (atual < paineis.Length)
        {
            paineis[atual].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("notaFinal");
        }
    }
}