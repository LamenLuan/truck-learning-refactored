using UnityEngine;

public class NuvemScroll : MonoBehaviour
{
    [SerializeField] private float _velocidade = 0.05f;
    [SerializeField] private Renderer _renderer;
    
    void Update() // Update is called once per frame
    {
        Vector2 offset = new Vector2(_velocidade * Time.deltaTime, 0);
        _renderer.material.mainTextureOffset -= offset;
    }

}
