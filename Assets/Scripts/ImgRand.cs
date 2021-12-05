using UnityEngine;

public class ImgRand : MonoBehaviour
{
    public int IndexIMG { get; set; }
    [SerializeField] private Sprite[] _listaSprites;
    private SpriteRenderer _spriteRenderer;
    public static ImgRand Instance;

    public Sprite[] ListaSprites {
        get => _listaSprites; set => _listaSprites = value;
    }

    void Awake()
    {
        Instance = this;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        IndexIMG = Usuario.Instancia.Nivel;
        _spriteRenderer.sprite = _listaSprites[IndexIMG];
    }
}