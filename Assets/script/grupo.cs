using UnityEngine;

public class FatiaRoda : MonoBehaviour
{
    [SerializeField] private GrupoAlimentar meusDados;
    [SerializeField] private PainelInfoController painel;

    public void OnClickFatia()
    {
        painel.ExibirDados(meusDados);
    }
}