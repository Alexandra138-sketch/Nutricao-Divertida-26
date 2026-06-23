using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SepararManager : MonoBehaviour
{
    public GameObject painelParabens;
    public DragFood[] todosOsAlimentos;

    void Update()
    {
        VerificarFim();
    }

    void VerificarFim()
    {
        foreach (DragFood food in todosOsAlimentos)
        {
            if (food.gameObject.activeSelf && !food.foiColocado)
                return;
        }
        painelParabens.SetActive(true);
    }

    public void Repetir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}