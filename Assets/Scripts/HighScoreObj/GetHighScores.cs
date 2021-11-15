using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class GetHighScores : MonoBehaviour
{
    private IDbConnection connection; // Para fazer a conexao com o banco
    private IDbCommand command; // Vai dar o comando para o banco
    private IDataReader reader; // Leitor
    private HighScoreRepository highScores;
    public GameObject scorePrefab;
    public Transform scoreParent;

    void Start()
    {
        ShowScores();
    }

    public void GetScores()
    {
        highScores = new HighScoreRepository();

        string connectionString = 
            "URI=file:" + Application.dataPath + "/truck_learning.db";

        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        const string query = "SELECT * FROM usuario ORDER BY pontuacao DESC;";
        command.CommandText = query;
        reader = command.ExecuteReader();

        while ( reader.Read() ) {
            highScores.Add(
                new HighScore(
                    reader.GetInt32(0), reader.GetString(1), reader.GetInt32(3)
                )
            );
        }

        reader.Close();
        connection.Close();
    }

    private void ShowScores()
    {
        GetScores();

        IIterator iter = highScores.CreateIterator();
        for (int i = 1; iter.HasNext(); i++)
        {
            GameObject tmpObj = Instantiate(scorePrefab);

            HighScore tmpScore = iter.Next();

            tmpObj.GetComponent<HighScoreScript>().SetScore(
                tmpScore.Nome, tmpScore.Pontuacao.ToString(), "#" + i
            );

            tmpObj.transform.SetParent(scoreParent);

            tmpObj.GetComponent<RectTransform>().localScale = new Vector3(
                1, 1, 1
            );

            tmpObj.GetComponent<RectTransform>().localPosition = new Vector3(
                transform.position.x, transform.position.y, 0
            );
        }
    }
}
