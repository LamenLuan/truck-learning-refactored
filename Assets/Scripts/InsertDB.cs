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
    [SerializeField] private Button registrarBtn;

    public void Insere() // Invocada pelo botao Registrar
    {
        int validacao = ConsultaUser();

        string connectionString =
            "URI=file:" + Application.dataPath + "/truck_learning.db";

        if(validacao == 0)
        {
            string query;

            connection = new SqliteConnection(connectionString);
            command = connection.CreateCommand();
            connection.Open();  

            query =
                "INSERT INTO usuario(nome, senha, pontuacao, nivel) VALUES('" + 
                nome.text +"', '"+ senha.text + "', " + 0 + ", " + 0 + ");";

            SetTextSucesso();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();
        }
        else if(validacao == -1) SetBotaoText("Preencha os campos");
        else SetBotaoText("Usuário já existente");
    }

    public int ConsultaUser()
    {
        string connectionString =
            "URI=file:" + Application.dataPath + "/truck_learning.db";
        int encontrou_id = 0;

        // Checando se campos estao preechidos
        if(nome.text.Trim().Length == 0 || senha.text.Trim().Length == 0)
            return -1;

        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        string querySelect =
            "SELECT id FROM usuario WHERE nome = '" + nome.text + "';";
        command.CommandText = querySelect;
        reader = command.ExecuteReader();

        if ( reader.Read() ) {
            encontrou_id = reader.GetInt32(0);
        }

        if (encontrou_id > 0) {
            reader.Close();
            reader = null;
            command.Dispose();
            connection.Close();
            return encontrou_id;
        } else {
            return 0;
        }
    }

    private void LoadMenu() // Invocada por SetTextSucesso()
    {
        SceneManager.LoadScene("MENU");
    }

    public void SetTextSucesso()
    {
        registrarBtn.enabled = false;
        registrarBtn.GetComponentInChildren<Text>().text = "Usuário registrado!";
        Invoke("LoadMenu", 1.5f);
    }

    private void ResetTextValidacao() // Invocada por SetTextValidacao()
    {
        registrarBtn.GetComponentInChildren<Text>().text = "Registrar";
        registrarBtn.enabled = true;
    }

    public void SetBotaoText(string mensagem)
    {
        registrarBtn.enabled = false;
        registrarBtn.GetComponentInChildren<Text>().text = mensagem;
        Invoke("ResetTextValidacao", 1f);
    }
}
