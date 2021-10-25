using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

/*
 Essa classe está responsável em controlar o quebra cabeça, o encaixe das peças, verificar se o jogador ganhou
 e chamar a tela de popup de dicas após o jogador montar 2 peças
 */



public class peças : MonoBehaviour
{
    public Vector2 posicao_certa; //criando uma variavel para o lugar certo da peça
    public bool encaixada; //var bool para o status de encaixada
    public bool selecionada; //var bool para o status de selecionada
    static int vitoria; //var que verifica o status de vitoria
    public Vector2 posicao_inicial;
    static int contador;
    static float tempoAUX; //vou uasr pra pegar o tempo exato de quando abro a popup com a dica, para poder retornar depois


    void Start()
    {
        //panel.enabled = false;
        contador = 0;
        vitoria = 0;
        posicao_certa = transform.position;//pega a posição inicial de cada peça do tabuleiro
        transform.position = posicao_inicial = new Vector2(Random.Range(10f, 18f), Random.Range(-5f, 6f));//Criando o lugar aonde as peças irão ficar randomicamente    
    }
    void Update()
    {
        string nome;
        nome = SceneManager.GetActiveScene().name;


        if (nome == "D_DIFICIL" && vitoria == 5) //16 é o número que calcula para vitória, mas do jeito que estava a última dica não aparece na popup, pq já carrega a cena da vitória. Por isso a última dica aparece na tela, e ela é responsável em incrementar para 17 o valor e aparecer a tela final.
        {           
            SceneManager.LoadScene("CONGRATS");
            vitoria = 0;
        }
        if (nome == "D_MEDIO" && vitoria == 9)
        {
            SceneManager.LoadScene("CONGRATS");
            vitoria = 0;
        }
        if (nome == "D_FACIL" && vitoria == 4)
        {
            SceneManager.LoadScene("CONGRATS");
            vitoria = 0;
        }
        if (Vector2.Distance(transform.position, posicao_certa) < 1f)//Compara uma posicao com a outra 
        //e ve se a diferença das 2 é menor que 1 para assim encaixar a peça no lugar certo
        //esse 1f é o limite de próximo que uma peça possa estar da posição correta pra eu encaixar, caso eu aumente esse limite, o jogo fica mais fácil.
        {
            
            if (!selecionada) //selecionda
            {
                
                if (encaixada == false)
                {
                    contador++;

                    if(contador == 2) //se montou 2 peças, apresento o popup
                    {
                    ativa();
                    contador = 0;
                    }
                    
                    vitoria++;
                    transform.position = posicao_certa;//Coloca ele no encaixe
                    encaixada = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;//Deixa na layer 0
                 
                }
                GetComponent<SortingGroup>().sortingOrder = 0;//Deixa na layer 0
            }
        }
        else 
        {
            transform.position = posicao_inicial;
        }

    }

    public void desativa() //desativo a popup com as dicas
    {
        if ( vitoria == 16)
        {
            vitoria++;
        }
       DicasControl.Instance.desativaFrase();
       DicasControl.Instance.ativaBalao();
       Frases.Instance.popup = true; //utilizo a variavel auxiliar popup na classe Frases, uso essa variavel pra pausar a fala das frases com a popup aberta
       Frases.Instance.tempo = tempoAUX;
    }

    public void ativa()
    {
        DicasControl.Instance.setaFrase();
        DicasControl.Instance.desativaBalao();
        Frases.Instance.popup = false; //utilizo a variavel auxiliar popup na classe Frases, uso essa variavel pra pausar a fala das frases com a popup aberta
        tempoAUX = Frases.Instance.tempo; //uso a variavel tempAUX para pegar o tempo exato que parei na reproducao das frases, pra continuar depois
    }

}