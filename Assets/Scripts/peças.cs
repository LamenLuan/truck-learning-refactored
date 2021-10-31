using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

// Essa classe está responsável em controlar o quebra cabeça, o encaixe das
// peças, verificar se o jogador ganhou e chamar a tela de popup de dicas após
// o jogador montar 2 peças
public class peças : MonoBehaviour
{
    public Vector2 posicao_certa; // Lugar certo da peça
    public bool encaixada; // Status de encaixada
    public bool selecionada; // Status de selecionada
    static int vitoria; // Verifica o status de vitoria
    public Vector2 posicao_inicial;
    static int contador;
    // Vou usar pra pegar o tempo exato de quando abro a popup com a dica, para
    // poder retornar depois
    static float tempoAUX; 

    void Start()
    {
        contador = 0;
        vitoria = 0;
        // Pega a posição inicial de cada peça do tabuleiro
        posicao_certa = transform.position;
        // Criando o lugar aonde as peças irão ficar randomicamente
        transform.position = posicao_inicial = new Vector2(
            Random.Range(10f, 18f), Random.Range(-5f, 6f)
        );
    }
    
    void Update()
    {
        if(vitoria == 9) {
            SceneManager.LoadScene("CONGRATS");
            vitoria = 0;
        }
        // Compara uma posicao com a outra
        // E ve se a diferença das 2 é menor que 1 para assim encaixar a peça
        // no lugar certo
        // Esse 1f é o limite de próximo que uma peça possa estar da posição
        // Caso eu aumente esse limite, o jogo fica mais fácil.
        if(Vector2.Distance(transform.position, posicao_certa) < 1f) {
            if(!selecionada) {
                if(encaixada == false) {
                    contador++;
                    // Se montou 2 peças, apresento o popup
                    if(contador == 2) {
                        ativa();
                        contador = 0;
                    }
                    vitoria++;
                    transform.position = posicao_certa; // Coloca ele no encaixe
                    encaixada = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
                GetComponent<SortingGroup>().sortingOrder = 0;
            }
        } else transform.position = posicao_inicial;
    }

    public void desativa() // Desativo a popup com as dicas
    {
        if( vitoria == 16) vitoria++;
        DicasControl.Instance.desativaFrase();
        DicasControl.Instance.ativaBalao();
        // Utilizo a variavel auxiliar popup na classe Frases, uso essa variavel
        // pra pausar a fala das frases com a popup aberta
        Frases.Instance.popup = true;
        Frases.Instance.tempo = tempoAUX;
    }

    public void ativa()
    {
        DicasControl.Instance.setaFrase();
        DicasControl.Instance.desativaBalao();
        // Utilizo a variavel auxiliar popup na classe Frases, uso essa variavel
        // pra pausar a fala das frases com a popup aberta
        Frases.Instance.popup = false;
        // Uso a variavel tempAUX para pegar o tempo exato que parei na 
        // reproducao das frases, pra continuar depois
        tempoAUX = Frases.Instance.tempo;
    }

}