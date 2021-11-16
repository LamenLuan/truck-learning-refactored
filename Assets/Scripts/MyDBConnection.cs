using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

// Laertes-Rodrigo: essa classe é responsável pela conexão com o banco e 
// criação da tabela dos usuários
public class MyDBConnection : MonoBehaviour
{
    private IDbConnection connection; // Para fazer a conexão com o banco
    private IDbCommand command; // Vai dar o comando para o banco
    private IDataReader reader; // Leitor

    void Start()
    {
        Connection();
    }

    private void Connection()
    {
        string connectionString =
            "URI=file:" + Application.dataPath + "/truck_learning.db";

        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        command.CommandText = "CREATE TABLE IF NOT EXISTS usuario(" + 
            "id INTEGER PRIMARY KEY AUTOINCREMENT, nome VARCHAR(50), " + 
            "senha VARCHAR(15), pontuacao INTEGER, nivel INTEGER" + 
        ");";

        command.ExecuteNonQuery();
        connection.Close();
    }
}
