using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class temaJogo : MonoBehaviour
{
    [SerializeField] private Text quadroTxt;
    private int idTema;
    [SerializeField] private string[] dicas;

    public void Start()
    {
        idTema = Usuario.Instancia.Nivel;
        for (int i = idTema * 8; i < (idTema + 1) * 8; ++i)
            quadroTxt.text += dicas[i] + '\n';
    }

    public void selecioneTema() // Invoked by
    {
        PlayerPrefs.SetInt("idTema", idTema);
        int notaF = PlayerPrefs.GetInt( "notafinal" + idTema.ToString() );
        int acertos= PlayerPrefs.GetInt( "acertos" + idTema.ToString() );
        jogar();
    }

    public void jogar()
    {
        SceneManager.LoadScene( "T" + idTema.ToString() );
        //posso trabalhar tanto com o INDEX da cena
        //tanto com o nome da cena
       
    }
}
