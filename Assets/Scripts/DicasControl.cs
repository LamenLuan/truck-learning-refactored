using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 Essa classe é responsável em gerenciar o balão popup com a dica que aparece a cada 2 peças montadas
 */

public class DicasControl : MonoBehaviour
{
    public static DicasControl Instance;
    public Text frase;
    public Text fraseBalao;
    public string[] dicas;
    public Canvas panel;
    


    public void Start()
    {
        Instance = this;
        //desativando o painel e as mensagens do popup pra ele iniciar desligado
        panel.transform.GetChild(0).gameObject.SetActive(true);
        panel.transform.GetChild(1).gameObject.SetActive(true);
        //panel.enabled = false;
    
    }



    public void setaFrase()
    {
        //Seto Frase na popup de dicas
        panel.transform.GetChild(0).gameObject.SetActive(true); //pego o filho no indice 0, se eu mudar as ordens da layer pode dar bosta aqui

        //Debug.Log("dentro do metodo setafrase "+controlefrases);
        frase.text = dicas[PlayerPrefs.GetInt("frase")];
        int aux = PlayerPrefs.GetInt("frase");
        aux++;
        PlayerPrefs.SetInt("frase", aux);
        //Debug.Log("dentro do metodo setafrase depois de incrementar" + controlefrases);
    }

    public void setaFraseBalao(int index)
    {
        //Frase balão segue a ordem do vetor ordenado, pra estar em equilibrio com o audio, pelo menos por hora
        // Debug.Log("index da frase do balao: " + index);
        fraseBalao.text = dicas[index];
        panel.transform.GetChild(1).gameObject.SetActive(true);
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

