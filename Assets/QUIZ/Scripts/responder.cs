using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour
{
    private int idTema, idPergunta, notaFinal;
    private float acertos, questoes, media;
    public Text infoRespostas;
    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    private Text[] respostas;

    public string[] perguntas; //armazena todas as perguntas
    public string[] corretas; //todas as respostas corretas
    private string[][] alternativas;

    [SerializeField] private ButtonSubject[] buttonSubs;

    public void Start()
    {
        respostas = new Text[] {respostaA, respostaB, respostaC, respostaD};
        alternativas = new string[buttonSubs.Length][];

        for (int i = 0; i < alternativas.Length; i++)
            alternativas[i] = buttonSubs[i].Answers;

        idTema = PlayerPrefs.GetInt("idTema");
        questoes = perguntas.Length;
        proximaPergunta();
    }

    public void encontraRespostaCorreta(string[] incorreta)
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

    public bool verificaResposta(string[] alternativa)
    {
        Invoke("proximaPergunta", 1.5f);

        // Id da pergunta e incrementado para ir para a proxima
        if( corretas[idPergunta].Equals(alternativa[idPergunta++]) ) {
            acertos++;
            return true;
        }
        return false;
    }

    void proximaPergunta()
    {
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
