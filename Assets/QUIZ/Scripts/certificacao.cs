using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class certificacao : MonoBehaviour
{
    public Sprite[] certificacoes;
    public Image imagem;


    /*Esse script vai ser para colocar a certificação certa*/

    private void Awake()
    {
        if(PlayerPrefs.GetInt("nivel") == 1)
        {
           imagem.sprite = certificacoes[0];
        }
        else if (PlayerPrefs.GetInt("nivel") == 2)
        {
            imagem.sprite = certificacoes[1];
        }
        else if (PlayerPrefs.GetInt("nivel") == 3)
        {
            imagem.sprite = certificacoes[2];
        }
        else if (PlayerPrefs.GetInt("nivel") == 4)
        {
            imagem.sprite = certificacoes[3];
        }
        else if (PlayerPrefs.GetInt("nivel") == 5)
        {
            imagem.sprite = certificacoes[4];
        }
        else if (PlayerPrefs.GetInt("nivel") == 6)
        {
            imagem.sprite = certificacoes[5];
        }
        else if (PlayerPrefs.GetInt("nivel") == 7)
        {
            imagem.sprite = certificacoes[6];
        }
        else if (PlayerPrefs.GetInt("nivel") == 8)
        {
            imagem.sprite = certificacoes[7];
        }
        else if (PlayerPrefs.GetInt("nivel") == 9)
        {
            imagem.sprite = certificacoes[8];
        }

    }


}
