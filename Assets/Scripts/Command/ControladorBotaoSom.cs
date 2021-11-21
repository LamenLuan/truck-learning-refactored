using UnityEngine;

class ControladorBotaoSom : MonoBehaviour // Client
{
    [SerializeField] private BGFundo _receiver;

    public void alterarEstado()
    {
        if(_receiver == null) return;

        Invoker invoker = new Invoker();
        invoker.Command = new LigaDesligaMusica(_receiver);
        invoker.ExecuteCommand();
    }
}