using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class notaFinal : MonoBehaviour
{
    //script que controla a tela quando termino uma partida, apresentado para o usuario a nota final
    public int idTema;
    public Text txtNota;
    public Text txtInfoTema;
    public Text nomeJogador;


    private int notaF, acertos;


    public void Start()
    {
        nomeJogador.text = PlayerPrefs.GetString("nome");
        idTema = PlayerPrefs.GetInt("idTema");
        notaF = PlayerPrefs.GetInt("notafinal" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertos" + idTema.ToString());

        txtNota.text = notaF.ToString();
        txtInfoTema.text = "Você Acertou " + acertos.ToString() + " de 8 perguntas";
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene("T" + idTema.ToString());
    }

}
