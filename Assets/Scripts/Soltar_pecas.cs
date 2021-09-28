using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

/*
 Essa classe Faz a função do arraste e solte do tabuleiro
 */


public class Soltar_pecas : MonoBehaviour
{
    public AudioSource tocar;
    
    public GameObject peca_selecionada;//criando uma variavel do tipo GameObject para instanciar uma peça do quebra cabeça
    //private Vector3 posicao_certa; //criando uma variavel para o lugar certo da peça
    public int camada_peca=1;
    public LayerMask camadaPeca;
    void Start()
    {
        gameObject.GetComponent<Soltar_pecas>().enabled = false;
        tocar = GetComponent<AudioSource>();
        gameObject.GetComponent<Soltar_pecas>().enabled = true;
    }



    void Update()//O metodo update do unity roda durante toda a execução do game
    {
        if (Input.GetMouseButtonDown(0))//se a entrada for = ao botão esquerdo do mouse sendo pressionado
        {

            // RaycastHit2D clique = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0)), Vector2.zero, 10f, camadaPeca); > Mudei de Vector 3 para VEctor2
            RaycastHit2D clique = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)), Vector2.zero, 10f, camadaPeca);
            
            
            if (clique.transform != null)
            {
                if (clique.transform.CompareTag("PEÇA")) //verifica se o clique do mouse esta sob um objeto com tag PEÇA
                {                    
                    if (!clique.transform.GetComponent<peças>().encaixada)//verifica se a peça esta encaixada
                    {
                        peca_selecionada = clique.transform.gameObject;
                        peca_selecionada.GetComponent<peças>().selecionada = true;
                        peca_selecionada.GetComponent<SortingGroup>().sortingOrder = camada_peca;
                        camada_peca++;                        
                    }
                }
            }
        }
        if(Input.GetMouseButtonUp(0))//se a entrada for = ao botão esquerdo do mouse sendo solto
        {
            if (peca_selecionada != null)
            {
                tocar.Play(); //toca o som quando solta a peçca
                peca_selecionada.GetComponent<peças>().selecionada = false;
                peca_selecionada = null;//faz a peça ser solta 
            }
        }

        if (peca_selecionada != null)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Variavel que recebe as cordenadas x y z do mouse > Rafael: comentei essa linha e criei um Vector2 pra testar, já que meu jogo é 2D, e não precisa de profundidado. Aparentemente ficou bom. O mesmo ocorre com a linha debaixo, onde está Vector2, era Vector3, com um valor de 0 para z

            peca_selecionada.transform.position = new Vector2(mouse.x, mouse.y);//Faz a peça receber 2 cordenadas, sendo 2 delas as cordenadas x e y
        }        
    }        
}