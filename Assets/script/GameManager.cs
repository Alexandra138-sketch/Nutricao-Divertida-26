using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    public int totalPecasNecessarias = 4;
    private int pecasColocadas = 0;
    public int movimentos = 0;
    public string nomeDaProximaCena;

    private void Awake()
    {
        if (string.IsNullOrWhiteSpace(nomeDaProximaCena))
        {
            nomeDaProximaCena = "notaFinal";
            Debug.Log("GameManeger: nomeDaProximaCena não estava definido, usando notaFinal como padrão.");
        }
    }

    public void RegistrarMovimento()
    {
        movimentos++;
        Debug.Log("GameManeger: movimento registrado. Total = " + movimentos);
    }

    public void RegistrarPecaCorreta()
    {
        pecasColocadas++;
        Debug.Log("GameManeger: peça correta registrada. Total = " + pecasColocadas + "/" + totalPecasNecessarias);
        if (pecasColocadas >= totalPecasNecessarias)
        {
            PlayerPrefs.SetInt("tipoFinalizacao", 2); // Puzzle finalizado
            PlayerPrefs.SetInt("movimentos", movimentos);
            PlayerPrefs.Save();
            Debug.Log("GameManeger: total concluído. Carregando cena " + nomeDaProximaCena + " com " + movimentos + " movimentos.");
            SceneManager.LoadScene(nomeDaProximaCena);
        }
    }
}