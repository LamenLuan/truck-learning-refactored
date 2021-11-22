using System.Collections.Generic;

class HistoricoErros // Caretaker
{
    private List<Memento> _mementos = new List<Memento>();
    internal List<Memento> Mementos {
        get => _mementos; set => _mementos = value;
    }
}