using System.Collections.Generic;

class HistoricoErros // Caretaker
{   
    public List<Memento> Mementos { get; set; }

    public HistoricoErros()
    {
        Mementos = new List<Memento>();
    }
}