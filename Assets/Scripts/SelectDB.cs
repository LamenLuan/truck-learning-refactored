using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.Sqlite;

// Laertes-Rodrigo essa classe é responsável por realizar o select para o Login no jogo

public class SelectDB : MonoBehaviour
{
    private IDbConnection connection; // variável para fazer a conexão com o banco
    private IDbCommand command; // variável que vai dar o comando para o banco
    private IDataReader reader; // leitor
    [SerializeField] private InputField nome;
    [SerializeField] private InputField senha;
    [SerializeField] private Button iniciarBtn;

    public void Logar() // Invocada pelo botao Iniciar
    {
        string connectionString = "URI=file:" + Application.dataPath + "/truck_learning.db";
        int id_encontrado = 0;

        connection = new SqliteConnection(connectionString);
        command = connection.CreateCommand();
        connection.Open();

        string query =
            "SELECT id, pontuacao, nivel FROM usuario WHERE nome = '" +
            nome.text + "' AND senha = '" + senha.text + "';";

        command.CommandText = query;
        reader = command.ExecuteReader();

        if ( reader.Read() ) {
            id_encontrado = reader.GetInt32(0);
        }

        if (id_encontrado > 0) {
            PlayerPrefs.DeleteAll();
            RecebeDadosUsuario();
            // Depende da RecebeDadosUsuario()
            PlayerPrefs.SetInt("frase", Usuario.Instancia.Nivel * 8); 
            SceneManager.LoadScene("QUEBRA_CABECA");
        } else {
            SetTextValidacao();
        }

        reader.Close();
        command.Dispose();
        connection.Close();
    }

    private void RecebeDadosUsuario()
    {
        Usuario usuario = Usuario.Instancia;
        usuario.Nome = nome.text;
        usuario.Senha = senha.text;
        usuario.Pontuacao = reader.GetInt32(1);
        usuario.Nivel = reader.GetInt32(2);
    }

    private void ResetTextValidacao() // Invocada por SetTextValidacao()
    {
        iniciarBtn.GetComponentInChildren<Text>().text = "Iniciar";
        iniciarBtn.enabled = true;
    }

    public void SetTextValidacao()
    {
        iniciarBtn.enabled = false;
        iniciarBtn.GetComponentInChildren<Text>().text =
            "Usuário não encontrado";
        Invoke("ResetTextValidacao", 1f);
    }
}
