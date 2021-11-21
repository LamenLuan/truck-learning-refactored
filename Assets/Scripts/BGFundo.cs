using UnityEngine;

public class BGFundo : MonoBehaviour
{
    [SerializeField] private GameObject botaooff, botaoon;

    void Start()
    {
        bool isPlaying = AudioManager.instance.musicaBG.isPlaying;
        botaooff.SetActive(!isPlaying);
        botaoon.SetActive(isPlaying);
    }

    public void AlteraEstadoFXMusica()
    {
       AudioManager.instance.SonsBGToca(botaooff, botaoon);
    }
}
