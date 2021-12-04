using UnityEngine;

public class ImgRand : MonoBehaviour
{
    private int indexIMG;
    private Sprite[] _listaSprites = new Sprite[9];
    private SpriteRenderer _spriteRenderer;
    public static ImgRand Instance;

    public int IndexIMG { get => indexIMG; set => indexIMG = value; }
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
        indexIMG = Usuario.Instancia.Nivel;
        _spriteRenderer.sprite = _listaSprites[indexIMG];
    }
}