// Created by Luan Leme
class Usuario // Singleton
{
    private static Usuario _instancia;
    public string Nome { get; set; }
    public string Senha { get; set; }
    public int Pontuacao { get; set; }
    public int Nivel { get; set; }

    public static Usuario Instancia {
        get {
            if (_instancia == null) _instancia = new Usuario();
            return _instancia;
        }
    }
    
    private Usuario() {
        Nome = "";
        Senha = "";
        Pontuacao = -1;
        Nivel = -1;
    }
}