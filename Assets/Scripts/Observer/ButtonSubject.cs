using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSubject : MonoBehaviour, ISubject  // Concrete Subject
{
    private BtnColor _colorState = BtnColor.Normal;
    private Image _btnImage;
    public List<IObserver> _observers;
    [SerializeField] private string[] _answers;
    [SerializeField] private ControladorPerguntas _answerController;

    public Image BtnImage { get => _btnImage; set => _btnImage = value; }
    internal BtnColor ColorState {
        get => _colorState; set => _colorState = value;
    }
    public string[] Answers { get => _answers; set => _answers = value; }

    void Start()
    {
        _observers = new List<IObserver>();
        _btnImage = GetComponentInParent<Image>();
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
        _colorState = BtnColor.Normal;
        Notify();
    }

    public void ChangeColor()
    {
        _colorState = _answerController.VerificaResposta(_answers)
            ? BtnColor.Green
            : BtnColor.Red;

        Invoke("DischangeColor", 1.5f);
        Notify();
    }
}