using UnityEngine;

public class BGFundo : MonoBehaviour
{
    [SerializeField] private GameObject botaooff, botaoon;

    void Start()
    {
        if (AudioManager.instance.musicaBG.isPlaying) {
            botaooff.SetActive(false);
            botaoon.SetActive(true);

        } else {
            botaooff.SetActive(true);
            botaoon.SetActive(false);
        }
    }

    public void PauseSound()
    {
       AudioManager.instance.SonsBGToca(botaooff, botaoon);
    }

    public void Destruir()
    {
        AudioManager.instance.Destruir();
    }

}
