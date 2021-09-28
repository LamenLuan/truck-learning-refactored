using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class GetHighScores : MonoBehaviour
{
    private IDbConnection connection; // variável para fazer a conexão com o banco
    private IDbCommand command; // variável que vai dar o comando para o banco
    private IDataReader reader; // leitor
    
    private List<HighScores> highScores = new List<HighScores>();

    public GameObject scorePrefab;
    public Transform scoreParent;

    void Start()
    {
        ShowScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetScores()
    {

        highScores.Clear();

        string connectionString = "URI=file:" + Application.dataPath + "/truck_learning.db";

        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        string query = "SELECT * FROM usuario ORDER BY pontuacao DESC;";
        command.CommandText = query;
        reader = command.ExecuteReader();

        while (reader.Read())
        {
            highScores.Add(new HighScores(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(3)));
        }
    }

    private void ShowScores()
    {
        GetScores();
        for(int i= 0; i < highScores.Count; i++)
        {
            GameObject tmpObject = Instantiate(scorePrefab);

            HighScores tmpScore = highScores[i];

            tmpObject.GetComponent<HighScoreScript>().SetScore(tmpScore.Nome, tmpScore.Pontuacao.ToString(), "#" + (i + 1).ToString());

            tmpObject.transform.SetParent(scoreParent);

            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            tmpObject.GetComponent<RectTransform>().localPosition = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
