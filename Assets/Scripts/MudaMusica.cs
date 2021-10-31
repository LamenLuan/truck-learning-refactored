using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaMusica : MonoBehaviour
{
    [SerializeField] private float volume;

    private void Start()
    {
       AudioManager.instance.musicaBG.volume = volume;
       string nomeCena = SceneManager.GetActiveScene().name;
       int nivel = Usuario.Instancia.Nivel;

        if (nomeCena == "CONGRATS") {
            AudioManager.instance.BGToca(0);
        }
        else if(nomeCena == "QUEBRA_CABECA" && nivel < 9) {
            int index = nivel == 0 ? 1 : nivel + 3;
            AudioManager.instance.BGToca(index);
        }
        else if (nomeCena == "CERTIFICACAO") {
            AudioManager.instance.BGToca(0);
        }
        else if (nomeCena == "FAIL") {
            AudioManager.instance.BGToca(3);
        }
        else if (nomeCena == "T"+ nivel) {
            AudioManager.instance.BGToca(2);
        }
    }

}
