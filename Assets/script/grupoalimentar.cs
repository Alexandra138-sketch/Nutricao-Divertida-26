using UnityEngine;

[CreateAssetMenu(fileName = "NovoGrupo", menuName = "RodaAlimentos/GrupoAlimentar")]
public class GrupoAlimentar : ScriptableObject
{
    public string nomeGrupo;
    [TextArea] public string descricao;
    public Sprite iconeGrande;
    public string[] beneficios; // Lista de pontos chave (Ex: Hidrata o corpo, etc)
}