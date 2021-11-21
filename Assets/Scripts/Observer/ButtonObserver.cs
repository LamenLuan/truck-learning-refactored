using UnityEngine;
using UnityEngine.UI;

public class ButtonObserver : IObserver // Concrete Subject
{
    public ButtonSubject btnSub;

    public ButtonObserver(ButtonSubject subject)
    {
        btnSub = subject;
    }

    public void Update()
    {
        if(btnSub == null) return;

        Image image = btnSub.BtnImage;
        Color color = new Color(1, 1, 1);

        if(btnSub.ColorState == BtnColor.Green) {
            color = new Color(0, 1, 0);
            AudioManager.instance.SonsFXToca(3);
        }
        else if(btnSub.ColorState == BtnColor.Red) {
            color = new Color(1, 0, 0);
            AudioManager.instance.SonsFXToca(4);
        }

        image.color = color;
    }
}