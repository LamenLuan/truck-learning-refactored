using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorPerguntas : MonoBehaviour
{
    private bool resolvendoErros = false;
    private int idTema, notaFinal;
    private float acertos, questoes, media;
    public Text infoRespostas;
    public Text pergunta, respostaA,  respostaB,  respostaC,  respostaD;
    private Text[] respostas;
    public string[] perguntas, corretas; //armazena todas as perguntas
    private string[][] alternativas;
    [SerializeField] private ButtonSubject[] buttonSubs;
    private HistoricoErros _historicoErros;
    private Originator _originator;

    public void Start()
    {
        respostas = new Text[] {respostaA, respostaB, respostaC, respostaD};
        alternativas = new string[buttonSubs.Length][];
        _historicoErros = new HistoricoErros();
        _originator = new Originator();

        for (int i = 0; i < alternativas.Length; i++)
            alternativas[i] = buttonSubs[i].Answers;

        idTema = PlayerPrefs.GetInt("idTema");
        questoes = perguntas.Length;
        proximaPergunta();
    }

    public bool verificaResposta(string[] alternativa)
    {
        int idPergunta = _originator.Index;
        Invoke(resolvendoErros ? "proximoErro" : "proximaPergunta", 1.5f);

        // Id da pergunta e incrementado para ir para a proxima
        if( corretas[idPergunta].Equals(alternativa[idPergunta]) ) {
            if(!resolvendoErros) acertos++;
            return true;
        }
        _historicoErros.Mementos.Add( _originator.CreateMemento() );
        print("Adicionando memento de id:" + idPergunta);
        return false;
    }

    private void guardaDadosPergunta()
    {
        PlayerPrefs.SetInt("notafinal" + idTema.ToString(), notaFinal);
        PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);
        PlayerPrefs.SetInt("nota", notaFinal);
        TXT.Instance.SalvaNota();
        UpdateScoreDB.Instance.AtualizaPontuacao();
    }

    private void proximaPergunta()
    {
        int idPergunta = ++_originator.Index;

        if (idPergunta < questoes) {
            pergunta.text = perguntas[idPergunta];
            for (int i = 0; i < respostas.Length; i++) {
                string[] perguntasAux = alternativas[i];
                respostas[i].text = perguntasAux[idPergunta];
            }
            infoRespostas.text = "Respondendo " + (idPergunta + 1) + " de " +
                questoes.ToString() + " perguntas";
        }
        else {
            resolvendoErros = true;
            print("Modo resolvendo erros ativado");
            proximoErro();
        }
    }

    private void proximoErro()
    {
        if(_historicoErros.Mementos.Count > 0) {
            _originator.SetMemento(_historicoErros.Mementos[0]);
            int idPergunta = _originator.Index;

            pergunta.text = perguntas[idPergunta];
            for (int i = 0; i < respostas.Length; i++) {
                string[] perguntasAux = alternativas[i];
                respostas[i].text = perguntasAux[idPergunta];
            }
            infoRespostas.text = "Resolva os " +
                _historicoErros.Mementos.Count + " erros para avançar";

            print("Removendo memento de id:" + idPergunta);
            _historicoErros.Mementos.RemoveAt(0);
        }
        else {
            media = 10 * (acertos / questoes); // Calcula a media com base no %
            notaFinal = Mathf.RoundToInt(media); // Arredonda para o próximo int
            guardaDadosPergunta();

            if (media > 6) {
                Usuario.Instancia.Nivel++;
                UpdateScoreDB.Instance.AtualizaNivel();
                SceneManager.LoadScene("CERTIFICACAO");
            }
            else SceneManager.LoadScene("FAIL");
        }
    }
}
