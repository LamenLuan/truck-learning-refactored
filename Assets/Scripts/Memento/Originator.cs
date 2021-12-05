class Originator // Originator
{
    public int Index { get; set; }

    public Originator()
    {
        Index = -1;
    }

    public Memento CreateMemento()
    {
        return new Memento(Index);
    }

    public void SetMemento(Memento memento)
    {
        Index = memento.State;
    }
}