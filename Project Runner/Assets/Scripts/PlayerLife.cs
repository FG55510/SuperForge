using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private int vidamax;
    [SerializeField] private int vidaatual;

    [SerializeField] private bool Escudo = false;
    [SerializeField] private int Protecaodoescudo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.INSTANCE.PlayerDefend.AddListener(EstacomEscudo);
        GameManager.INSTANCE.PlayerTomaDano.AddListener(Tiravida);
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
            dano = dano - Protecaodoescudo;

        }
        vidaatual = vidaatual - dano;
        Debug.Log("vida Player: " + vidaatual + "/" + vidamax);
        if (vidaatual <= 0)
        {
            vidaatual = 0;
            
        }
    }

    private void EstacomEscudo (bool estado)
    {
        Escudo = estado;
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.PlayerAttack.RemoveListener(EstacomEscudo);
       // GameManager.INSTANCE.PlayerAttack.RemoveListener(Tiravida);
    }
}
