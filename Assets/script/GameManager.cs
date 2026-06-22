using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public int totalPecasNecessarias = 4;
    private int pecasColocadas = 0;
    public string nomeDaProximaCena;

    public void RegistrarPecaCorreta()
    {
        pecasColocadas++;
        if (pecasColocadas >= totalPecasNecessarias)
        {
            SceneManager.LoadScene(nomeDaProximaCena);
        }
    }
}