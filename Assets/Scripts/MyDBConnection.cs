using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Necessary imports
using System;
using System.IO;
using System.Data;
using Mono.Data.Sqlite;

// Laertes-Rodrigo: essa classe é responsável pela conexão com o banco e criação da tabela dos usuários

public class MyDBConnection : MonoBehaviour
{
    private IDbConnection connection; // variável para fazer a conexão com o banco
    private IDbCommand command; // variável que vai dar o comando para o banco
    private IDataReader reader; // leitor

    void Start()
    {
        Connection();
    }

    private void Connection()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/truck_learning.db";

        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        //string deletar_tabela_usuario = "DROP TABLE IF EXISTS usuario;";
        string tabela_usuario = "CREATE TABLE IF NOT EXISTS usuario(id INTEGER PRIMARY KEY AUTOINCREMENT, nome VARCHAR(50), senha VARCHAR(15), pontuacao INTEGER);";
        command.CommandText = tabela_usuario;
        command.ExecuteNonQuery();
        connection.Close();
    }
}
