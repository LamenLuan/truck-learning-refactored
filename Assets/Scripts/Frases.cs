using UnityEngine;

// Responsável em gerar os balões de dicas que aparece encima do personagem,
// bem como tocar suas frases em áudio a cada intervalo de segundos;
public class Frases : MonoBehaviour
{
    const int PERGUNTAS_POR_QUESTAO = 8;
    const int INTERVALO = 6;
    
    public static Frases Instance;
    public bool Mudo { get; set; }
    public bool PopupAtivado { get; set; }
    private int _quantNiveis;
    public float Tempo { get; set; }
    public AudioSource AudioSource { get; set; }
    [SerializeField] private AudioClip[] _listaClips;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Instance = this;
        _quantNiveis = ImgRand.Instance.ListaSprites.Length;
    }
    
    void Update()
    {
        Tempo += Time.deltaTime;

        for(int nivel = 0; nivel < _quantNiveis; nivel++)
        {
            if( NivelAtual(nivel) ) {
                VerificaTempo( (int) Tempo, nivel );
                break;
            }
        }
    }

    private bool NivelAtual(int i)
    {
        return ImgRand.Instance.IndexIMG == i && PopupAtivado;
    }

    private void TocaClip(int indiceClip)
    {
        AudioSource.clip = _listaClips[indiceClip];
        if(!Mudo) AudioSource.Play();
    }

    private bool HoraResetTempo(int tempo)
    {
        return tempo >= PERGUNTAS_POR_QUESTAO * INTERVALO + 1;
    }

    private void VerificaTempo(int intTempo, int nivel)
    {
        for(int i = 0; i < PERGUNTAS_POR_QUESTAO; i++)
        {
            // Vendo se tempo == [1, 7, 13, ..., 43]
            if(intTempo == i * INTERVALO + 1) {
                int clipAtual = nivel * PERGUNTAS_POR_QUESTAO + i;
                TocaClip(clipAtual);
                DicasControl.Instance.setaFraseBalao(clipAtual);
                break;
            }
            else if( HoraResetTempo(intTempo) ) {
                Tempo = 0;
                break;
            }
        }
    }

}
