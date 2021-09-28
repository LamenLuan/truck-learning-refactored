using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicasControlQuizz : MonoBehaviour
{
    public static DicasControlQuizz Instance;

    public Text fraseBalaoQuizz;
    public string[] dicasQuizz;
    
    public Canvas panel;

    void Start()
    {
        Instance = this;
        panel.transform.GetChild(0).gameObject.SetActive(true);
        //panel.enabled = false;
    }

    public void setaFraseBalao(int index)
    {
        //Frase balão segue a ordem do vetor ordenado, pra estar em equilibrio com o audio, pelo menos por hora
        // Debug.Log("index da frase do balao: " + index);
        fraseBalaoQuizz.text = dicasQuizz[index];
        panel.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void desativaFrase()
    {
        panel.transform.GetChild(0).gameObject.SetActive(false);
    }


    public void desativaBalao()
    {
        panel.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void ativaBalao()
    {
        panel.transform.GetChild(1).gameObject.SetActive(true);

    }
}
