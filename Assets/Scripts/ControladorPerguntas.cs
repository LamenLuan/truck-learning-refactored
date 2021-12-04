using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorPerguntas : MonoBehaviour
{
    private bool resolvendoErros;
    private int idTema, notaFinal;
    private float acertos, questoes, media;
    [SerializeField] private string[] perguntas, corretas;
    private string[][] alternativas;
    [SerializeField] private Text infoRespostas, pergunta, respostaA, respostaB,
        respostaC, respostaD;
    private Text[] respostas;
    [SerializeField] private ButtonSubject[] buttonSubs;
    private HistoricoErros historicoErros;
    private Originator originator;

    public void Start()
    {
        respostas = new Text[] {respostaA, respostaB, respostaC, respostaD};
        alternativas = new string[buttonSubs.Length][];
        historicoErros = new HistoricoErros();
        originator = new Originator();

        for (int i = 0; i < alternativas.Length; i++)
            alternativas[i] = buttonSubs[i].Answers;

        idTema = PlayerPrefs.GetInt("idTema");
        questoes = perguntas.Length;
        ProximaPergunta();
    }

    public bool VerificaResposta(string[] alternativa)
    {
        int idPergunta = originator.Index;
        Invoke(resolvendoErros ? "ProximoErro" : "ProximaPergunta", 1.5f);

        // Id da pergunta e incrementado para ir para a proxima
        if( corretas[idPergunta].Equals(alternativa[idPergunta]) ) {
            if(!resolvendoErros) acertos++;
            return true;
        }
        historicoErros.Mementos.Add( originator.CreateMemento() );
        return false;
    }

    private void GuardaDadosPergunta()
    {
        PlayerPrefs.SetInt("notafinal" + idTema.ToString(), notaFinal);
        PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);
        PlayerPrefs.SetInt("nota", notaFinal);
        TXT.Instance.SalvaNota();
        UpdateScoreDB.Instance.AtualizaPontuacao();
    }

    private void PreencheTextosPergunta(int idPergunta)
    {
        pergunta.text = perguntas[idPergunta];
        for (int i = 0; i < respostas.Length; i++) {
            string[] perguntasAux = alternativas[i];
            respostas[i].text = perguntasAux[idPergunta];
        }
    }

    private void ProximaPergunta() // Invocada por VerificaResposta()
    {
        int idPergunta = ++originator.Index;

        if (idPergunta < questoes) {
            PreencheTextosPergunta(idPergunta);
            infoRespostas.text = "Respondendo " + (idPergunta + 1) + " de " +
                questoes.ToString() + " perguntas";
        }
        else {
            resolvendoErros = true;
            ProximoErro();
        }
    }

    private void ProximoErro() // Invocada por VerificaResposta()
    {
        if(historicoErros.Mementos.Count > 0) {
            originator.SetMemento(historicoErros.Mementos[0]);
            int idPergunta = originator.Index;
            
            PreencheTextosPergunta(idPergunta);
            infoRespostas.text = "Resolva os " +
                historicoErros.Mementos.Count + " erros para avançar";

            historicoErros.Mementos.RemoveAt(0);
        }
        else {
            media = 10 * (acertos / questoes); // Calcula a media com base no %
            notaFinal = Mathf.RoundToInt(media); // Arredonda para o próximo int
            GuardaDadosPergunta();

            if (media > 6) {
                Usuario.Instancia.Nivel++;
                UpdateScoreDB.Instance.AtualizaNivel();
                SceneManager.LoadScene("CERTIFICACAO");
            }
            else SceneManager.LoadScene("FAIL");
        }
    }
}
