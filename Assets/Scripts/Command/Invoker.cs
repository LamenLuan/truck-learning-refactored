class Invoker // Invoker
{
    public ICommand Command { get; set; }

    public Invoker(ICommand command)
    {
        Command = command;
    }

    public void ExecuteCommand()
    {
        if(Command != null) Command.Execute();
    }
}