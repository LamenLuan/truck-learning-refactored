using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSubject : MonoBehaviour, ISubject  // Concrete Subject
{
    public BtnColor ColorState { get; set; }
    public Image BtnImage { get; set; }
    public List<IObserver> _observers;
    [SerializeField] private string[] _answers;
    [SerializeField] private ControladorPerguntas _answerController;

    public string[] Answers { get => _answers; set => _answers = value; }

    void Start()
    {
        _observers = new List<IObserver>();
        BtnImage = GetComponentInParent<Image>();
        Attach( new ButtonObserver(this) );
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Dettach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        _observers.ForEach( observer => observer.Update() );
    }

    public void DischangeColor()
    {
        ColorState = BtnColor.Normal;
        Notify();
    }

    public void ChangeColor()
    {
        ColorState = _answerController.VerificaResposta(_answers)
            ? BtnColor.Green
            : BtnColor.Red;

        Invoke("DischangeColor", 1.5f);
        Notify();
    }
}