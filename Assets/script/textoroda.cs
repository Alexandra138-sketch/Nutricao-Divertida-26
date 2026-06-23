using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PainelInfoController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tituloText;
    [SerializeField] private TextMeshProUGUI descricaoText;
    [SerializeField] private Image iconePrincipal;

    public void ExibirDados(GrupoAlimentar data)
    {
        tituloText.text = data.nomeGrupo;
        descricaoText.text = data.descricao;
        iconePrincipal.sprite = data.iconeGrande;
        
        // Aqui você pode adicionar lógica para ativar/desativar 
        // os "cardzinhos" de benefícios (pontos chave)
    }
}