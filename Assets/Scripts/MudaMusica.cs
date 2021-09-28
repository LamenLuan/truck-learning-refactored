using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaMusica : MonoBehaviour
{
    public float volume;


    private void Start()
    {
       
       AudioManager.instance.musicaBG.volume = volume;

        if (SceneManager.GetActiveScene().name == "CONGRATS")
        {
            AudioManager.instance.BGToca(0);
        }
        else if(SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel")==0)
        {
            AudioManager.instance.BGToca(1);
        }
        else if (SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel") == 1)
        {
            AudioManager.instance.BGToca(4);
        }
        else if (SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel") == 2)
        {
            AudioManager.instance.BGToca(5);
        }
        else if (SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel") == 3)
        {
            AudioManager.instance.BGToca(6);
        }
        else if (SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel") == 4)
        {
            AudioManager.instance.BGToca(7);
        }
        else if (SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel") == 5)
        {
            AudioManager.instance.BGToca(8);
        }
        else if (SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel") == 6)
        {
            AudioManager.instance.BGToca(9);
        }
        else if (SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel") == 7)
        {
            AudioManager.instance.BGToca(10);
        }
        else if (SceneManager.GetActiveScene().name == "D_DIFICIL" && PlayerPrefs.GetInt("nivel") == 8)
        {
            AudioManager.instance.BGToca(11);
        }
        else if (SceneManager.GetActiveScene().name == "CERTIFICACAO")
        {
            AudioManager.instance.BGToca(0);
        }
        else if (SceneManager.GetActiveScene().name == "FAIL")
        {
            AudioManager.instance.BGToca(3);
        }
        else if (SceneManager.GetActiveScene().name == "T"+ PlayerPrefs.GetInt("nivel").ToString())
        {
            AudioManager.instance.BGToca(2);
        }
    }

 
}
