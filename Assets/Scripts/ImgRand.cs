using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ImgRand : MonoBehaviour
{
    public Sprite[] listaSprites = new Sprite[9];
    public static ImgRand Instance;
    SpriteRenderer renderer;
    public int indexIMG;
    
    void Awake()
    {
        Instance = this;
        renderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
      indexIMG = PlayerPrefs.GetInt("nivel"); //serve apenas para informar qual tabuleiro vai ser apresentado no mapa e também as frases
      renderer.sprite = listaSprites[indexIMG];
    }

    void Update()
    {
        // Debug.Log(index);
       //renderer.sprite = listaSprites[indexIMG]; //renderiza o tabuleiro certo
       //nao sei pq o renderer.sprite está no update, vou deixar ele no awake/start, pq funciona também e eu acho mais coerente. Caso dê alguem pau, posso tentar ativar o renderer.sprite daqui e desativar do awake/start
       
    }
}