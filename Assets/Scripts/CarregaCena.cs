using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregaCena : MonoBehaviour
{
    public void carregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void carregaCenaFinal()
    {
        if (Usuario.Instancia.Nivel == 9)
        {
            SceneManager.LoadScene("CERTIFICACAOFINAL");
        }
        else
        {
            SceneManager.LoadScene("QUEBRA_CABECA");
        }
    }

    public void carregaPerguntas() // Invoked by CONGRATS
    {
        SceneManager.LoadScene("T" + Usuario.Instancia.Nivel);
    }

}
