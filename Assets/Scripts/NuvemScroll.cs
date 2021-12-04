using UnityEngine;

public class NuvemScroll : MonoBehaviour
{
    [SerializeField] private float _velocidade = 0.05f;
    private Renderer _renderer;
    
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2(_velocidade * Time.deltaTime, 0);
        _renderer.material.mainTextureOffset -= offset;
    }

}
