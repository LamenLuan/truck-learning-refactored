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

// Laertes-Rodrigo: essa classe é responsável pelo cadastro dos usuários

public class InsertDB : MonoBehaviour
{
    private IDbConnection connection; // variável para fazer a conexão com o banco
    private IDbCommand command; // variável que vai dar o comando para o banco
    private IDataReader reader; // leitor
    [SerializeField] private InputField nome;
    [SerializeField] private InputField senha;
    public Text buttonText;

    void Start()
    {
        Insere();
    }

    public void Insere()
    {
        int validacao = ConsultaUser();

        string connectionString = "URI=file:" + Application.dataPath + "/truck_learning.db";

        if(validacao == 0)
        {
            string query;

            connection = new SqliteConnection(connectionString);
            command = connection.CreateCommand();
            connection.Open();  

            query = "INSERT INTO usuario(nome, senha, pontuacao) VALUES('"+ nome.text +"', '"+ senha.text +"', "+ 0 +");";

            SetTextSucesso();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();
        } else 
        {
            SetTextValidacao();
        }
    }

    public int ConsultaUser()
    {
        string connectionString = "URI=file:" + Application.dataPath + "/truck_learning.db";
        int encontrou_id = 0;
        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        string querySelect = "SELECT id FROM usuario WHERE nome = '"+ nome.text +"';";
        command.CommandText = querySelect;
        reader = command.ExecuteReader();

        if (reader.Read())
        {
            encontrou_id = reader.GetInt32(0);
        }

        if (encontrou_id > 0)
        {
            reader.Close();
            reader = null;
            command.Dispose();
            connection.Close();
            return encontrou_id;
        } else
        {
            return 0;
        }
    }

    public void SetTextSucesso()
    {
        buttonText.text = "Usuário Registrado!";
    }

    public void SetTextValidacao()
    {
        buttonText.text = "Usuário já existente";
    }
}
