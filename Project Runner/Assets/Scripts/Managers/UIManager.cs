using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Image> Barradevida;

    [SerializeField] private int vidaatualplayer;
    [SerializeField] private int vidamaxplayer = 10;
    [SerializeField] private Sprite CapsuladeDesativada;
    [SerializeField] private Sprite CapsuladeAtivada;
    [SerializeField] private TextMeshProUGUI txtwinlose;

    [SerializeField] private Image Escudomain;
    [SerializeField] private Sprite EscudoAtivo;
    [SerializeField] private Sprite EscudoInativo;
    [SerializeField] private Sprite EscudoQuebrado;
    
    void Start()
    {
        vidaatualplayer = vidamaxplayer;
        GameManager.INSTANCE.PlayerTomaDano.AddListener(TiravidaUI);
        GameManager.INSTANCE.PlayerCuraVida.AddListener(SomaVidaUI);
        GameManager.INSTANCE.PlayerDefend.AddListener(AtualizaEscudo);


        GameManager.INSTANCE.Playermorre.AddListener(Lose);
        GameManager.INSTANCE.PlayerWin.AddListener(Win);
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

    private void AtualizaEscudo(bool a, EscudoPlayer estado){
        switch(estado){
            case EscudoPlayer.EscudoAtivo:
                Escudomain.sprite =EscudoAtivo;
                break;

            
            case EscudoPlayer.EscudoInativo:
                Escudomain.sprite =EscudoInativo;
                break;

            
            case EscudoPlayer.EscudoQuebrado:
                Escudomain.sprite =EscudoQuebrado;
                break;
        
        }
        
    }

    private void Win()
    {
        txtwinlose.text = "You Win";
    }

    private void Lose()
    {
        txtwinlose.text = "Game Over";
    }
    private void OnDestroy()
    {
        GameManager.INSTANCE.PlayerTomaDano.RemoveListener(TiravidaUI);
        GameManager.INSTANCE.PlayerCuraVida.RemoveListener(SomaVidaUI);

        GameManager.INSTANCE.Playermorre.RemoveListener(Lose);
        GameManager.INSTANCE.PlayerWin.RemoveListener(Win);
    }
}
