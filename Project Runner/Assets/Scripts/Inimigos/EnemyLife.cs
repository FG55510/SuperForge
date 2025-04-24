using UnityEngine;
enum Tipodeinimigo{
    InimigoGrande, InimigoMedio, Inimigopequeno
}
public class EnemyLife : MonoBehaviour
{
    [SerializeField] private Tipodeinimigo tipodesteinimigo;
    [SerializeField] private int vidamax;
    [SerializeField] private int vidaatual;
    [SerializeField] private EnemyTypeSelection fontedoinimigo;

    [SerializeField] private int chanceemumdedroparitemdecura;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Checatipodeinimigo(tipodesteinimigo);
    }


    public void Tiravida(int dano)
    {
        vidaatual = vidaatual - dano;
        Debug.Log("vida inimigo: " + vidaatual + "/" + vidamax);
        if (vidaatual <= 0)
        {
            vidaatual = 0;
            //death animation
            vidaatual = vidamax;
            fontedoinimigo.ResetdeInimigos();
            int chance = Random.Range(1, chanceemumdedroparitemdecura);
            if(chance == 1)
            {
                GameManager.INSTANCE.ItemdeCuraDropado.Invoke(transform.position);
            }
            GameManager.INSTANCE.CheckInimigosRestantes();
        }
    }

    private void Checatipodeinimigo(Tipodeinimigo tipo)
    {
        switch (tipo)
        {
            case Tipodeinimigo.InimigoGrande:
                vidamax = 4500;
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
