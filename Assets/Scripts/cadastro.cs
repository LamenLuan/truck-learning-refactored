using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 Essa classe só é responsável em capturar o nome do usuário, deletar todos os registros do jogo e iniciar o game no nível 0
isso acontece toda vez que a gente iniciar um novo jogo.

Laertea/Rodrigo: Script modificado para receber o nome e a senha.
 */

public class cadastro : MonoBehaviour
{
    [SerializeField] private InputField nome;


    public void Salvar()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("nome", nome.text);
        PlayerPrefs.SetInt("nivel", 0);
        PlayerPrefs.SetInt("frase", 0);
        SceneManager.LoadScene("D_DIFICIL");
    }

}
