using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 PAULO, ESSA CLASSE GERENCIA O AUDIO DO JOGO (FUNDO E EFEITOS ESPECIAIS)
    OBS: AS FRASES EM AUDIO SÃO GERENCIADAS POR OUTRA CLASSE.
 */
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
        musicaBG.clip = clips[i];
        musicaBG.Play();
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
                Frases.Instance.tocar.Stop();
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
                Frases.Instance.tocar.UnPause();
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
