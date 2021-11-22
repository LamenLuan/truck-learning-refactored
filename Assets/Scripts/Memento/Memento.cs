class Memento // Memento
{
    private int _state;
    public int State { get => _state; set => _state = value; }

    public Memento(int state)
    {
        _state = state;
    }
}