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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Escudo = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Escudo = false;
        }

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
        if (vidaatual <= 0)
        {
            vidaatual = 0;
            Debug.Log("inimigo morreu");
        }
    }
}
