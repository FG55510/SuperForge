using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EstadosdosInimigos
{
    Ataque,
    GoingtoPlayer
}
public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private ArmaInimigo Gun;
    [SerializeField] private Movimenta��oInimigos moveseekplayer;

    [SerializeField] private Transform player;
    [SerializeField] private float distanciadoplayer;
    [SerializeField] private float RangeMaximoparaatirar;
    [SerializeField] private float RangeMinimoparaatirar;

    [SerializeField] private EstadosdosInimigos estadoatual;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Gun = GetComponent<ArmaInimigo>();
        moveseekplayer = GetComponent< Movimenta��oInimigos > ();
        anim = GetComponent<Animator>();

        Gun.DefinirPlayer(player);
        moveseekplayer.DefinirPlayer(player);
    }

    // Update is called once per frame
    void Update()
    {
        distanciadoplayer = Vector3.Distance(player.position, transform.position);
        if(distanciadoplayer > moveseekplayer.rangeatual && estadoatual != EstadosdosInimigos.GoingtoPlayer)
        {
            MudarEstado(EstadosdosInimigos.GoingtoPlayer);
        }
        else if (distanciadoplayer <= moveseekplayer.rangeatual && estadoatual != EstadosdosInimigos.Ataque)
        {
            MudarEstado(EstadosdosInimigos.Ataque);
        }
    }

    private void MudarEstado(EstadosdosInimigos estado)
    {
        ResetEstados();

        switch (estado)
        {
            case EstadosdosInimigos.Ataque:
                Gun.enabled = true;
                anim.SetFloat("Speed", 0);
                break;

            case EstadosdosInimigos.GoingtoPlayer:
                MudarRangeentrePlayer();
                moveseekplayer.enabled = true;
                break;
        }

        estadoatual = estado;
            
    }

    private void ResetEstados()
    {
        Gun.enabled = false;
        moveseekplayer.enabled = false;

    }
    public void MudarRangeentrePlayer()
    {
        float novoRangeparaatirar = Random.Range(RangeMinimoparaatirar, RangeMaximoparaatirar);
        moveseekplayer.MudarRangeentrePlayer(novoRangeparaatirar);

    }


}
