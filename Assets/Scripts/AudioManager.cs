using UnityEngine;

// ESSA CLASSE GERENCIA O AUDIO DO JOGO (FUNDO E EFEITOS ESPECIAIS)
//   OBS: AS FRASES EM AUDIO SÃO GERENCIADAS POR OUTRA CLASSE.
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    //musicas
    public AudioClip[] clips;
    public AudioSource musicaBG;
  
    //sonsFX
    public AudioClip[] clipsFX;
    public AudioSource sonsFX;

    //private bool mudo = false;
   
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicaBG.clip = clips[0];
        musicaBG.volume = 1f;
        musicaBG.Play();
    }

    public void BGToca(int i)
    {
        bool somAtivo = musicaBG.isPlaying || sonsFX.isPlaying;
        musicaBG.clip = clips[i];
        if(somAtivo) musicaBG.Play();
    }

    public void SonsFXToca(int i)
    {
        sonsFX.clip = clipsFX[i];
        sonsFX.Play();
    }

    public void SonsBGToca(GameObject botaooff, GameObject botaoon)
    {
        if (musicaBG.isPlaying || sonsFX.isPlaying)
        {
            musicaBG.Pause();
            sonsFX.Stop();

            if(Frases.Instance == true)
            {
                Frases.Instance.mudo = true;
                Frases.Instance.audioSource.Stop();
            }

            
            botaooff.SetActive(true);
            botaoon.SetActive(false);

        }
        else if (!musicaBG.isPlaying || !sonsFX.isPlaying)
        {
            musicaBG.UnPause();
            
            if (Frases.Instance == true)
            {
                Frases.Instance.mudo = false;
                Frases.Instance.audioSource.UnPause();
            }

            botaooff.SetActive(false);
            botaoon.SetActive(true);
        }

    }

    public void Destruir()
    {
        Destroy(gameObject);
    }

}
