using UnityEngine;
using UnityEngine.UI;

public class certificacao : MonoBehaviour
{
    public Sprite[] certificacoes;
    public Image imagem;
    
    private void Awake()
    {
        if(Usuario.Instancia.Nivel <= certificacoes.Length)
            imagem.sprite = certificacoes[Usuario.Instancia.Nivel - 1];
    }

}
