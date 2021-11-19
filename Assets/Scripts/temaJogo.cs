using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class temaJogo : MonoBehaviour
{
    [SerializeField] private Text quadroTxt;
    [SerializeField] private string[] dicas;

    public void Start()
    {
        int nivel = Usuario.Instancia.Nivel;
        for (int i = nivel * 8; i < (nivel + 1) * 8; ++i)
            quadroTxt.text += dicas[i] + '\n';
    }

    public void selecioneTema() // Invoked by
    {
        int nivel = Usuario.Instancia.Nivel;
        PlayerPrefs.SetInt("idTema", nivel);
        int notaF = PlayerPrefs.GetInt("notafinal" + nivel);
        int acertos= PlayerPrefs.GetInt("acertos" + nivel);
        SceneManager.LoadScene("T" + nivel);
    }

}
