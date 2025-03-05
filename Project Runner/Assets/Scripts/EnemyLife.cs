using UnityEngine;
enum Tipodeinimigo{
    InimigoGrande, InimigoMedio, Inimigopequeno
}
public class EnemyLife : MonoBehaviour
{
    [SerializeField] private Tipodeinimigo tipodesteinimigo;
    [SerializeField] private int vidamax;
    [SerializeField] private int vidaatual;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Checatipodeinimigo(tipodesteinimigo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tiravida(100);
            Debug.Log("vida inimigo: " + vidaatual + "/" + vidamax);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Checatipodeinimigo(tipodesteinimigo);
        }
    }

    public void Tiravida(int dano)
    {
        vidaatual = vidaatual - dano;
        Debug.Log("vida inimigo: " + vidaatual + "/" + vidamax);
        if (vidaatual <= 0)
        {
            vidaatual = 0;
            Debug.Log("inimigo morreu");
        }
    }

    private void Checatipodeinimigo(Tipodeinimigo tipo)
    {
        switch (tipo)
        {
            case Tipodeinimigo.InimigoGrande:
                vidamax = 1500;
                break;
            case Tipodeinimigo.InimigoMedio:
                vidamax = 1000;
                break;

            case Tipodeinimigo.Inimigopequeno:
                vidamax = 500;
                break;

        }

        vidaatual = vidamax;

        Debug.Log("vida inimigo: " + vidaatual + "/" + vidamax);

    }
}
