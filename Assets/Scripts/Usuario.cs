// Created by Luan Leme
class Usuario // Singleton
{
    private static Usuario _instancia;
    private string _nome, _senha;
    private int _pontuacao, _nivel;

    private Usuario() {
        _nome = "";
        _senha = "";
        _pontuacao = -1;
        _nivel = -1;
    }

    public static Usuario Instancia {
        get {
            if (_instancia == null) _instancia = new Usuario();
            return _instancia;
        }
    }

    public string Nome {
        get { return _nome; }
        set { _nome = value; }
    }

    public string Senha {
        get { return _senha; }
        set { _senha = value; }
    }

    public int Pontuacao {
        get { return _pontuacao; }
        set { _pontuacao = value; }
    }

    public int Nivel {
        get { return _nivel; }
        set { _nivel = value; }
    }
}