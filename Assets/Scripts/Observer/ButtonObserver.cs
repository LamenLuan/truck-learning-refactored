using UnityEngine;
using UnityEngine.UI;

public class ButtonObserver : IObserver // Concrete Subject
{
    private static ButtonObserver _instancia;
    private ButtonSubject btnSub;

    public static ButtonObserver Instancia {
        get {
            if (_instancia == null) _instancia = new ButtonObserver();
            return _instancia;
        }
    }
    
    private ButtonObserver() {}

    public void Update(ISubject subject)
    {
        ButtonSubject buttonSubject = (ButtonSubject) subject;
        Image image = buttonSubject.BtnImage;
        Color color = new Color(1, 1, 1);

        if(buttonSubject.ColorState == BtnColor.Green) {
            color = new Color(0, 1, 0);
            AudioManager.instance.SonsFXToca(3);
        }
        else if(buttonSubject.ColorState == BtnColor.Red) {
            color = new Color(1, 0, 0);
            AudioManager.instance.SonsFXToca(4);
        }

        image.color = color;
    }
}