using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Classe que tem a função de iniciar qualquer outra cena
Utilizamos para tranzitar de uma cena para a outra 
O método carregaCenaFinal só é chamado quando terminamos o questionário, ali eu verifico se o cara já jogou todos os níveis 
(dai apresento a tela final) ou se tem níveis pra ele continuar
 */
public class CarregaCena : MonoBehaviour
{
    public void carregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);

    }

    public void carregaCenaFinal()
    {
        int idTema = PlayerPrefs.GetInt("nivel");
        if (idTema == 9)
        {
            SceneManager.LoadScene("CERTIFICACAOFINAL");
        }
        else
        {
            SceneManager.LoadScene("D_DIFICIL");
        }
        
    }

}
