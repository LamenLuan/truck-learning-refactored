public class HighScore
{
    public string Nome { get; set; }
    public int Pontuacao { get; set; }
    public int ID { get; set; }

    public HighScore(int id, string nome, int pontuacao)
    {
        this.Nome = nome;
        this.Pontuacao = pontuacao;
        this.ID = id;

    }
}
