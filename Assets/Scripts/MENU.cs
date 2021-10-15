using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  



public class MENU : MonoBehaviour
{

    public void AbreMenu(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void FechaMenu(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void Sair()
    {
        Debug.Log("Sair");
        Application.Quit();
        SceneManager.LoadScene("MENU"); // modificado para que retorne a tela de Menu ao clicar no botão 'Sair'
    }

}
