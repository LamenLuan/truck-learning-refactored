using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour
{
    private int idTema;
    public Text infoRespostas;
    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    private Text[] respostas;

    public string[] perguntas; //armazena todas as perguntas
    public string[] corretas; //todas as respostas corretas
    public string[] alternativaA; //todas as alternativas A
    public string[] alternativaB; //todas as alternativas B
    public string[] alternativaC; //todas as alternativas C
    public string[] alternativaD; //todas as alternativas D
    private string[][] alternativas;

    private int idPergunta, notaFinal;
    private float acertos, questoes, media;

    public void Start()
    {
        respostas = new Text[] {respostaA, respostaB, respostaC, respostaD};
        alternativas = new string[][] {
            alternativaA, alternativaB, alternativaC, alternativaD
        };

        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;
        proximaPergunta();
    }

    private void resetaCorBotoes()
    {
        Text[] respostas = {respostaA, respostaB, respostaC, respostaD};

        for (int i = 0; i < respostas.Length; i++) {
            Image btnImg = respostas[i].GetComponentInParent<Image>();
            btnImg.color = new Color(1, 1, 1);
        }
    }

    private void encontraRespostaCorreta(string[] incorreta)
    {
        List<string[]> alternativasList = new List<string[]>(this.alternativas);
        List<Text> respostasList = new List<Text>(this.respostas);
        
        int index = alternativasList.IndexOf(incorreta);
        alternativasList.RemoveAt(index);
        respostasList.RemoveAt(index);

        for (int i = 0; i < alternativasList.Count; i++)
        {
            var alternativa = alternativas[i];
            if(alternativa[idPergunta] == corretas[idPergunta]) {
                Image btnImg = respostasList[i].GetComponentInParent<Image>();
                btnImg.color = new Color(0, 1, 0);
            }
        }
    }

    public void verificaResposta(string alternativa)
    {
        Text resposta;
        string[] alternativaEscolhida;

        if (alternativa == "A") {
            alternativaEscolhida = alternativaA;
            resposta = respostaA;
        } else if (alternativa == "B") {
            alternativaEscolhida = alternativaB;
            resposta = respostaB;
        } else if (alternativa == "C") {
            alternativaEscolhida = alternativaC;
            resposta = respostaC;
        } else {
            alternativaEscolhida = alternativaD;
            resposta = respostaD;
        }

        if(alternativaEscolhida[idPergunta] == corretas[idPergunta]) {
            acertos++;
            AudioManager.instance.SonsFXToca(3);
            resposta.GetComponentInParent<Image>().color = new Color(0, 1, 0);

        } else {
            AudioManager.instance.SonsFXToca(4);
            resposta.GetComponentInParent<Image>().color = new Color(1, 0, 0);
            encontraRespostaCorreta(alternativaEscolhida);
        }

        idPergunta++;
        Invoke("proximaPergunta", 1.5f);
    }

    void proximaPergunta()
    {
        resetaCorBotoes();
        if (idPergunta < questoes) {
            pergunta.text = perguntas[idPergunta];
            for (int i = 0; i < respostas.Length; i++) {
                string[] perguntasAux = alternativas[i];
                respostas[i].text = perguntasAux[idPergunta];
            }
            infoRespostas.text = "Respondendo " + (idPergunta + 1) + " de " +
                questoes.ToString() + " perguntas.";
        } else {
            media = 10 * (acertos / questoes); // Calcula a media com base no %
            notaFinal = Mathf.RoundToInt(media); // Arredonda para o próximo int

            PlayerPrefs.SetInt("notafinal" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);
            PlayerPrefs.SetInt("nota", notaFinal);
            TXT.Instance.SalvaNota();
            UpdateScoreDB.Instance.AtualizaPontuacao();

            if (media > 6) {
                Usuario.Instancia.Nivel++;
                UpdateScoreDB.Instance.AtualizaNivel();
                SceneManager.LoadScene("CERTIFICACAO");
            }
            else SceneManager.LoadScene("FAIL");
        }
    }

}
