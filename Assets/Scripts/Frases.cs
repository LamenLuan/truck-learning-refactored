using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Essa classe está responsável em gerar os balões de dicas que aparece encima do personagem, bem como suas frases em áudio a cada 6 segundos;
 */


public class Frases : MonoBehaviour
{
    public static Frases Instance;
    //public Sprite[] ListaFrases = new Sprite[13];
    public AudioClip[] Lista;
    public AudioSource tocar;
    public float tempo;
    public bool popup; //estou criando essa variavel para quando no script pecas eu ativar o popup, eu não deixo o som tocara aqui
    public bool mudo;
         
    void Start()
    {
        popup = true;
        mudo = false;
        tocar = GetComponent<AudioSource>();
        Instance = this;

    }
    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime; // faz uma variavel float receber o tempo de execução de cada update (1 segundo)
                                 //o swtich embaixo está rodando de 10 em 10 segundos

        if (ImgRand.Instance.indexIMG == 0 && popup)
        {
            
            switch((int)tempo)
            {
                case 1:
                   tocar.clip = Lista[0];
                   if (!mudo) {tocar.Play();}
                             
                   DicasControl.Instance.setaFraseBalao(0);
                   break;
                case 7:
                    tocar.clip = Lista[1];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(1);
                    break;
                case 13:
                    tocar.clip = Lista[2];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(2);
                    break;
                case 19:
                    tocar.clip = Lista[3];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(3);
                    break;
                case 25:
                    tocar.clip = Lista[4];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(4);
                    break;
                case 31:
                    tocar.clip = Lista[5];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(5);
                    break;
                case 37:
                    tocar.clip = Lista[6];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(6);
                    break;
                case 43:
                    tocar.clip = Lista[7];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(7);
                    break;
                case 49:
                    tempo = 0;
                    break;
            }

        }
        if (ImgRand.Instance.indexIMG == 1 && popup)
        {
            switch((int)tempo)
            {
                case 1:
                    tocar.clip = Lista[8];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(8);
                    break;
                case 7:
                    tocar.clip = Lista[9];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(9);
                    break;
                case 13:
                    tocar.clip = Lista[10];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(10);
                    break;
                case 19:
                    tocar.clip = Lista[11];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(11);
                    break;
                case 25:
                    tocar.clip = Lista[12];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(12);
                    break;
                case 31:
                    tocar.clip = Lista[13];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(13);
                    break;
                case 37:
                    tocar.clip = Lista[14];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(14);
                    break;
                case 43:
                    tocar.clip = Lista[15];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(15);
                    break;
                case 49:
                    tempo = 0;
                    break;
            }

        }
        if (ImgRand.Instance.indexIMG == 2 && popup)
        {
            switch((int)tempo)
            {

                case 1:
                    tocar.clip = Lista[16];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(16);
                    break;
                case 7:
                    tocar.clip = Lista[17];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(17);
                    break;
                case 13:
                    tocar.clip = Lista[18];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(18);
                    break;
                case 19:
                    tocar.clip = Lista[19];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(19);
                    break;
                case 25:
                    tocar.clip = Lista[20];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(20);
                    break;
                case 31:
                    tocar.clip = Lista[21];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(21);
                    break;
                case 37:
                    tocar.clip = Lista[22];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(22);
                    break;
                case 43:
                    tocar.clip = Lista[23];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(23);
                    break;
                case 49:
                    tempo = 0;
                    break;
            }
        }
        if (ImgRand.Instance.indexIMG == 3 && popup)
        {
            switch ((int)tempo)
            {

                case 1:
                    tocar.clip = Lista[24];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(24);
                    break;
                case 7:
                    tocar.clip = Lista[25];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(25);
                    break;
                case 13:
                    tocar.clip = Lista[26];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(26);
                    break;
                case 19:
                    tocar.clip = Lista[27];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(27);
                    break;
                case 25:
                    tocar.clip = Lista[28];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(28);
                    break;
                case 31:
                    tocar.clip = Lista[29];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(29);
                    break;
                case 37:
                    tocar.clip = Lista[30];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(30);
                    break;
                case 43:
                    tocar.clip = Lista[31];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(31);
                    break;
                case 49:
                    tempo = 0;
                    break;
            }
        }
        if (ImgRand.Instance.indexIMG == 4 && popup)
        {
            switch ((int)tempo)
            {
                case 1:
                    tocar.clip = Lista[32];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(32);
                    break;
                case 7:
                    tocar.clip = Lista[33];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(33);
                    break;
                case 13:
                    tocar.clip = Lista[34];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(34);
                    break;
                case 19:
                    tocar.clip = Lista[35];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(35);
                    break;
                case 25:
                    tocar.clip = Lista[36];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(36);
                    break;
                case 31:
                    tocar.clip = Lista[37];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(37);
                    break;
                case 37:
                    tocar.clip = Lista[38];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(38);
                    break;
                case 43:
                    tocar.clip = Lista[39];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(39);
                    break;
                case 49:
                    tempo = 0;
                    break;

            }
        }
        if (ImgRand.Instance.indexIMG == 5 && popup)
        {
            switch ((int)tempo)
            {
                case 1:
                    tocar.clip = Lista[40];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(40);
                    break;
                case 7:
                    tocar.clip = Lista[41];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(41);
                    break;
                case 13:
                    tocar.clip = Lista[42];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(42);
                    break;
                case 19:
                    tocar.clip = Lista[43];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(43);
                    break;
                case 25:
                    tocar.clip = Lista[44];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(44);
                    break;
                case 31:
                    tocar.clip = Lista[45];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(45);
                    break;
                case 37:
                    tocar.clip = Lista[46];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(46);
                    break;
                case 43:
                    tocar.clip = Lista[47];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(47);
                    break;
                case 49:
                    tempo = 0;
                    break;

            }
        }
        if (ImgRand.Instance.indexIMG == 6 && popup)
        {
            switch ((int)tempo)
            {
                case 1:
                    tocar.clip = Lista[48];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(48);
                    break;
                case 7:
                    tocar.clip = Lista[49];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(49);
                    break;
                case 13:
                    tocar.clip = Lista[50];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(50);
                    break;
                case 19:
                    tocar.clip = Lista[51];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(51);
                    break;
                case 25:
                    tocar.clip = Lista[52];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(52);
                    break;
                case 31:
                    tocar.clip = Lista[53];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(53);
                    break;
                case 37:
                    tocar.clip = Lista[54];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(54);
                    break;
                case 43:
                    tocar.clip = Lista[55];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(55);
                    break;
                case 49:
                    tempo = 0;
                    break;

            }
        }
        if (ImgRand.Instance.indexIMG == 7 && popup)
        {
            switch ((int)tempo)
            {
                case 1:
                    tocar.clip = Lista[56];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(56);
                    break;
                case 7:
                    tocar.clip = Lista[57];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(57);
                    break;
                case 13:
                    tocar.clip = Lista[58];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(58);
                    break;
                case 19:
                    tocar.clip = Lista[59];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(59);
                    break;
                case 25:
                    tocar.clip = Lista[60];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(60);
                    break;
                case 31:
                    tocar.clip = Lista[61];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(61);
                    break;
                case 37:
                    tocar.clip = Lista[62];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(62);
                    break;
                case 43:
                    tocar.clip = Lista[63];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(63);
                    break;
                case 49:
                    tempo = 0;
                    break;

            }
        }
        if (ImgRand.Instance.indexIMG == 8 && popup)
        {
            switch ((int)tempo)
            {
                case 1:
                    tocar.clip = Lista[64];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(64);
                    break;
                case 7:
                    tocar.clip = Lista[65];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(65);
                    break;
                case 13:
                    tocar.clip = Lista[66];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(66);
                    break;
                case 19:
                    tocar.clip = Lista[67];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(67);
                    break;
                case 25:
                    tocar.clip = Lista[68];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(68);
                    break;
                case 31:
                    tocar.clip = Lista[69];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(69);
                    break;
                case 37:
                    tocar.clip = Lista[70];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(70);
                    break;
                case 43:
                    tocar.clip = Lista[71];
                    if (!mudo) { tocar.Play(); }
                    DicasControl.Instance.setaFraseBalao(71);
                    break;
                case 49:
                    tempo = 0;
                    break;

            }
        }



    }

    
}
