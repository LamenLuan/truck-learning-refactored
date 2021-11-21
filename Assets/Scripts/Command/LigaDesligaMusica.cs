class LigaDesligaMusica : ICommand // Concrete Command
{
    private BGFundo _receiver;

    public LigaDesligaMusica(BGFundo receiver)
    {
        _receiver = receiver;
    }
    
    public void Execute()
    {
        if(_receiver != null) _receiver.AlteraEstadoFXMusica();
    }
}