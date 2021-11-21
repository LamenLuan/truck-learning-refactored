using UnityEngine;

class ControladorBotaoSom : MonoBehaviour // Client
{
    [SerializeField] private BGFundo _receiver;

    public void AlterarEstado()
    {
        if(_receiver == null) return;

        ICommand command = new LigaDesligaMusica(_receiver);
        Invoker invoker = new Invoker(command);
        invoker.ExecuteCommand();
    }
}