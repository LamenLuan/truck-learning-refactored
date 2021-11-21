class Invoker // Invoker
{
    private ICommand _command;
    internal ICommand Command { get => _command; set => _command = value; }

    public void ExecuteCommand()
    {
        if(_command != null) _command.Execute();
    }
}