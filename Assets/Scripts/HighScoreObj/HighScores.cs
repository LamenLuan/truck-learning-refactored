using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class HighScores
{
    public string Nome { get; set; }
    public int Pontuacao { get; set; }
    public int ID { get; set; }

    public HighScores(int id, string nome, int pontuacao)
    {
        this.Nome = nome;
        this.Pontuacao = pontuacao;
        this.ID = id;

    }
}
