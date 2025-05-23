using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private int vidamax;
    [SerializeField] private int vidaatual;

    [SerializeField] private bool Escudo = false;
    [SerializeField] private int Vidaescudoatual;
    [SerializeField] private int Vidaescudomax=3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.INSTANCE.PlayerDefend.AddListener(EstacomEscudo);
        GameManager.INSTANCE.PlayerTomaDano.AddListener(Tiravida);
        GameManager.INSTANCE.PlayerCuraVida.AddListener(CuraPlayer);
        Vidaescudoatual = Vidaescudomax;

        vidaatual = vidamax;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            Tiravida(100);
            Debug.Log("vida Player: " + vidaatual + "/" + vidamax);
        }
    }

    public void Tiravida(int dano)
    {
        if (Escudo)
        {
            dano = 0;
            Vidaescudoatual--;
            if(Vidaescudoatual <= 0)
            {
                GameManager.INSTANCE.EscudoFoiQuebrado();
                Vidaescudoatual = Vidaescudomax;
            }

        }
        vidaatual = vidaatual - dano;
        Debug.Log("vida Player: " + vidaatual + "/" + vidamax);
        if (vidaatual <= 0)
        {
            vidaatual = 0;
            //anima��o de morte
            GameManager.INSTANCE.Playermorre.Invoke();
            
        }
    }

    private void EstacomEscudo (bool estado, EscudoPlayer a)
    {
        Escudo = estado;
    }

    private void CuraPlayer (int cura)
    {
        vidaatual = vidaatual + cura;
        if(vidaatual > vidamax)
        {
            vidaatual = vidamax;
        }
        Debug.Log("vida Player: " + vidaatual + "/" + vidamax);
    }
    private void OnDestroy()
    {
        GameManager.INSTANCE.PlayerDefend?.RemoveListener(EstacomEscudo);
        GameManager.INSTANCE.PlayerCuraVida?.RemoveListener(CuraPlayer);
        GameManager.INSTANCE.PlayerTomaDano?.RemoveListener(Tiravida);
    }
}
