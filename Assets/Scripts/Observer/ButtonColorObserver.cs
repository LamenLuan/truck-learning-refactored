using UnityEngine;
using UnityEngine.UI;

public class ButtonColorObserver : IObserver // Concrete Subject
{
    private static ButtonColorObserver _instancia;
    private ButtonSubject btnSub;

    public static ButtonColorObserver Instancia {
        get {
            if (_instancia == null) _instancia = new ButtonColorObserver();
            return _instancia;
        }
    }
    
    private ButtonColorObserver() {}

    public void Update(ISubject subject)
    {
        ButtonSubject buttonSubject = (ButtonSubject) subject;
        Image image = buttonSubject.BtnImage;
        Color color = new Color(1, 1, 1);

        if(buttonSubject.ColorState == BtnColor.Green)
            color = new Color(0, 1, 0);
        else if(buttonSubject.ColorState == BtnColor.Red)
            color = new Color(1, 0, 0);

        image.color = color;
    }
}