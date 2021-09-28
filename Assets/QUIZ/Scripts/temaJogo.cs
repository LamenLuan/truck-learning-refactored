using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class temaJogo : MonoBehaviour
{
    public string[] nomeTema;
    private int idTema;

    public void Start()
    {
        idTema = 0;
    }

    public void selecioneTema()
    {
        idTema = PlayerPrefs.GetInt("nivel");
        PlayerPrefs.SetInt("idTema", idTema);
        int notaF = PlayerPrefs.GetInt("notafinal" + idTema.ToString());
        int acertos= PlayerPrefs.GetInt("acertos" + idTema.ToString()); ;
        jogar();
    }

    public void jogar()
    {

        SceneManager.LoadScene("T"+idTema.ToString());
        //posso trabalhar tanto com o INDEX da cena
        //tanto com o nome da cena
       
    }
}
