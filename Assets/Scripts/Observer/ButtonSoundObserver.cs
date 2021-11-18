using UnityEngine.UI;

public class ButtonSoundObserver : IObserver // Concrete Subject
{
    private static ButtonSoundObserver _instancia;

    public static ButtonSoundObserver Instancia {
        get {
            if (_instancia == null) _instancia = new ButtonSoundObserver();
            return _instancia;
        }
    }

    private ButtonSoundObserver() {}

    public void Update(ISubject subject)
    {
        ButtonSubject buttonSubject = (ButtonSubject) subject;
        Image image = buttonSubject.BtnImage;

        if(buttonSubject.ColorState == BtnColor.Green)
            AudioManager.instance.SonsFXToca(3);
        else if(buttonSubject.ColorState == BtnColor.Red)
            AudioManager.instance.SonsFXToca(4);
    }
}