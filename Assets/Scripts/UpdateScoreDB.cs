using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.Sqlite;

public class UpdateScoreDB : MonoBehaviour
{
    private IDbConnection connection; // variável para fazer a conexão com o banco
    private IDbCommand command; // variável que vai dar o comando para o banco
    private IDataReader reader; // leitor
    
    public static UpdateScoreDB Instance; // variável que vai pegar o valor da nota e atualizar no banco

    void Start()
    {
        Instance = this;
    }

    public void AtualizaPontuacao()
    {
        int notaAtual = ConsultaNota();
        int notaAtt = 0;
        int nota_player = PlayerPrefs.GetInt("nota");
        string nome_player = PlayerPrefs.GetString("nome");

        notaAtt = notaAtual + nota_player;   

        string connectionString = "URI=file:" + Application.dataPath + "/truck_learning.db";

        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        string query = "UPDATE usuario SET pontuacao = "+ notaAtt +" WHERE nome = '"+ nome_player +"';";

        command.CommandText = query;
        command.ExecuteNonQuery();
        connection.Close();
    }

    public int ConsultaNota()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/truck_learning.db";
        int notaAtt = 0;
        string nome_player = PlayerPrefs.GetString("nome");

        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        string querySelect = "SELECT pontuacao FROM usuario WHERE nome = '"+ nome_player +"';";
        command.CommandText = querySelect;
        reader = command.ExecuteReader();

        if (reader.Read())
        {
            notaAtt = reader.GetInt32(0);
        }

        reader.Close();
        reader = null;
        command.Dispose();
        connection.Close();
        return notaAtt;
    }
}
