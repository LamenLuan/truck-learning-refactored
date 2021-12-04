using UnityEngine;

// Responsável em gerar os balões de dicas que aparece encima do personagem,
// bem como tocar suas frases em áudio a cada 6 segundos;
public class Frases : MonoBehaviour
{
    public static Frases Instance;
    public AudioClip[] listaClips;
    public AudioSource audioSource;
    public float tempo;
    public bool popupAtivado;
    public bool mudo;
    private int quantNiveis;
         
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Instance = this;
        quantNiveis = ImgRand.Instance.listaSprites.Length;
    }
    
    void Update()
    {
        tempo += Time.deltaTime;

        for(int nivel = 0; nivel < quantNiveis; nivel++)
        {
            if( nivelAtual(nivel) ) {
                verificaTempo( (int) tempo, nivel );
                break;
            }
        }
    }

    private bool nivelAtual(int i)
    {
        return ImgRand.Instance.indexIMG == i && popupAtivado;
    }

    private void tocaClip(int indiceClip)
    {
        audioSource.clip = listaClips[indiceClip];
        if(!mudo) audioSource.Play();
    }

    private void verificaTempo(int intTempo, int nivel)
    {
        for(int i = 0; i < 8; i++)
        {
            // Vendo se tempo == [1, 7, 13, ..., 43]
            if(intTempo == i * 6 + 1) {
                int clipAtual = nivel * 8 + i;
                tocaClip(clipAtual);
                DicasControl.Instance.setaFraseBalao(clipAtual);
                break;
            }
            else if(intTempo >= 49) {
                tempo = 0;
                break;
            }
        }
    }

}
