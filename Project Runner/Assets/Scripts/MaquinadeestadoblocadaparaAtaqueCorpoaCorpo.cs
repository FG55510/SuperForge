using UnityEngine;

public class MaquinadeestadoblocadaparaAtaqueCorpoaCorpo : MonoBehaviour
{
    [SerializeField] private AtaqueCorpoaCorpoInimigos ataque;
    [SerializeField] private Movimenta��oInimigos move;
    
    [SerializeField] private Transform player;
    [SerializeField] private float distanciadoplayer;

    public float range;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ataque = GetComponentInChildren<AtaqueCorpoaCorpoInimigos>();
        move = GetComponent<Movimenta��oInimigos>();
    }

    // Update is called once per frame
    void Update()
    {
      distanciadoplayer = Vector3.Distance(player.position, transform.position);

        if (ataque.enabled && range< distanciadoplayer)
        {
            ataque.enabled = false;
            move.enabled = true;
        }
        else if (range >= distanciadoplayer && !ataque.enabled)
        {
            ataque.enabled = true;
            ataque.IniciaAtaque();
            move.enabled = false;
        }

    }
}
