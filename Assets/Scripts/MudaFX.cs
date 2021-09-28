using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaFX : MonoBehaviour
{

    public int fx;

    private void Start()
    {
        AudioManager.instance.SonsFXToca(fx);
    }
}
