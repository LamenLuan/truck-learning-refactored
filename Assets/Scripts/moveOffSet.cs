using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffSet : MonoBehaviour
{
    public Material materialAtual;
    public float velocidade, offset;
    public bool direcao;
       
    void Start()
    {
        materialAtual = GetComponent<Renderer>().material;

    }

  
    void FixedUpdate() //Defino um fps padrão
    {
        if (direcao)
        {
            offset += 0.01f;
        }
        else {
            offset -= 0.01f;
        }
        
        materialAtual.SetTextureOffset("_MainTex", new Vector2(offset * velocidade, 0));
    }
}
