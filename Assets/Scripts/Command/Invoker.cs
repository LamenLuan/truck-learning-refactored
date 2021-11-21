class Invoker // Invoker
{
    private ICommand _command;
    internal ICommand Command { get => _command; set => _command = value; }

    public Invoker(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        if(_command != null) _command.Execute();
    }
}