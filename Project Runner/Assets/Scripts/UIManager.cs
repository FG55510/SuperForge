using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Image> Barradevida;

    [SerializeField] private int vidaatualplayer;
    [SerializeField] private int vidamaxplayer = 10;
    [SerializeField] private Sprite CapsuladeDesativada;
    [SerializeField] private Sprite CapsuladeAtivada;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaatualplayer = vidamaxplayer;
        GameManager.INSTANCE.PlayerTomaDano.AddListener(TiravidaUI);
        GameManager.INSTANCE.PlayerCuraVida.AddListener(SomaVidaUI);
    }

    public void TiravidaUI(int dano)
    {
        dano = dano / 100;
        vidaatualplayer = vidaatualplayer - dano;
        if (vidaatualplayer < 0)
        {
            vidaatualplayer = 0;
        }
        for(int i =0; i < vidamaxplayer-vidaatualplayer; i++)
        {
            Barradevida[i].sprite = CapsuladeDesativada;
        }
    }

    public void SomaVidaUI(int vida)
    {
        vida = vida / 100;
        vidaatualplayer = vidaatualplayer + vida;
        if (vidaatualplayer > vidamaxplayer)
        {
            vidaatualplayer = vidamaxplayer;
        }
        for (int i = vidamaxplayer-1; i >= vidamaxplayer - vidaatualplayer; i--)
        {
            Barradevida[i].sprite = CapsuladeAtivada;
        }
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.PlayerTomaDano.RemoveListener(TiravidaUI);
        GameManager.INSTANCE.PlayerCuraVida.RemoveListener(SomaVidaUI);
    }
}
