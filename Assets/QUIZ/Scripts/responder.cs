using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour
{
    private int idTema;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;

    public string[] perguntas; //armazena todas as perguntas
    public string[] alternativaA; //todas as alternativas A
    public string[] alternativaB; //todas as alternativas B
    public string[] alternativaC; //todas as alternativas C
    public string[] alternativaD; //todas as alternativas D
    public string[] corretas; //todas as respostas corretas

    private int idPergunta, notaFinal;
    private float acertos, questoes, media;

    public void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        
        questoes = perguntas.Length;
        
        proximaPergunta();

    }

    public void verificaResposta(string alternativa)
    {
        if (alternativa == "A")
        {
            if(alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos++;
            }
        }else if(alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos++;
            }
        }
        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos++;
            }
        }
        else if (alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos++;
            }
        }

        idPergunta++;
        proximaPergunta();
    }

    void proximaPergunta()
    {
        
        if (idPergunta < questoes)
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];
            infoRespostas.text = "Respondendo " + (idPergunta + 1) + " de " + questoes.ToString() + " perguntas.";
           
        }
        else
        {
            media = 10 * (acertos / questoes); //calcula a media com base no %
            notaFinal = Mathf.RoundToInt(media); //arredonda para o próximo inteiro

            
  
                PlayerPrefs.SetInt("notafinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);

            PlayerPrefs.SetInt("nota", notaFinal);
            TXT.Instance.SalvaNota();
            UpdateScoreDB.Instance.AtualizaPontuacao();

            if (media > 6)
            {
                PlayerPrefs.SetInt("nivel", PlayerPrefs.GetInt("nivel") + 1);
                SceneManager.LoadScene("CERTIFICACAO");
            }
            else
            {
                SceneManager.LoadScene("FAIL");
            }
        }
        

    }

}
