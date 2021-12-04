using UnityEngine;

// Responsável em gerar os balões de dicas que aparece encima do personagem,
// bem como tocar suas frases em áudio a cada INTERVALO segundos;
public class Frases : MonoBehaviour
{
    const int PERGUNTAS_POR_QUESTAO = 8;
    const int INTERVALO = 6;
    
    public static Frases Instance;
    private int _quantNiveis;
    private bool _mudo;
    private float _tempo;
    private bool _popupAtivado;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _listaClips;

    public bool Mudo { get => _mudo; set => _mudo = value; }
    public float Tempo { get => _tempo; set => _tempo = value; }
    public bool PopupAtivado {
        get => _popupAtivado; set => _popupAtivado = value;
    }
    public AudioSource AudioSource {
        get => _audioSource; set => _audioSource = value;
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Instance = this;
        _quantNiveis = ImgRand.Instance.listaSprites.Length;
    }
    
    void Update()
    {
        _tempo += Time.deltaTime;

        for(int nivel = 0; nivel < _quantNiveis; nivel++)
        {
            if( NivelAtual(nivel) ) {
                VerificaTempo( (int) _tempo, nivel );
                break;
            }
        }
    }

    private bool NivelAtual(int i)
    {
        return ImgRand.Instance.indexIMG == i && _popupAtivado;
    }

    private void TocaClip(int indiceClip)
    {
        _audioSource.clip = _listaClips[indiceClip];
        if(!_mudo) _audioSource.Play();
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
                _tempo = 0;
                break;
            }
        }
    }

}
