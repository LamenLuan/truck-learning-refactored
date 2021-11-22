class Originator // Originator
{
    private int _index = -1;
    public int Index { get => _index; set => _index = value; }

    public Memento CreateMemento()
    {
        return new Memento(_index);
    }

    public void SetMemento(Memento memento)
    {
        _index = memento.State;
    }
}