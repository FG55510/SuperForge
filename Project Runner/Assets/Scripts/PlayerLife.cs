using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private int vidamax;
    [SerializeField] private int vidaatual;

    [SerializeField] private bool Escudo = false;
    [SerializeField] private int Protecaodoescudo;
    [SerializeField] private int Vidaescudoatual;
    [SerializeField] private int Vidaescudomax=3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.INSTANCE.PlayerDefend.AddListener(EstacomEscudo);
        GameManager.INSTANCE.PlayerTomaDano.AddListener(Tiravida);
        GameManager.INSTANCE.PlayerCuraVida.AddListener(CuraPlayer);
        Vidaescudoatual = Vidaescudomax;
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
                GameManager.INSTANCE.EscudoQuebrado();
                Vidaescudoatual = Vidaescudomax;
            }

        }
        vidaatual = vidaatual - dano;
        Debug.Log("vida Player: " + vidaatual + "/" + vidamax);
        if (vidaatual <= 0)
        {
            vidaatual = 0;
            //animação de morte
            
            
        }
    }

    private void EstacomEscudo (bool estado)
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
        GameManager.INSTANCE.PlayerAttack.RemoveListener(EstacomEscudo);
        GameManager.INSTANCE.PlayerCuraVida.RemoveListener(CuraPlayer);
        // GameManager.INSTANCE.PlayerAttack.RemoveListener(Tiravida);
    }
}
