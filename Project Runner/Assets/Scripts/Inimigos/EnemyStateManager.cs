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
    [SerializeField] private MovimentaçãoInimigosOtimizada moveseekplayer;

    [SerializeField] private GameObject player;
    [SerializeField] private float distanciadoplayer;
    [SerializeField] private float RangeMaximoparaatirar;
    [SerializeField] private float RangeMinimoparaatirar;

    [SerializeField] private EstadosdosInimigos estadoatual;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Gun = GetComponent<ArmaInimigo>();
        moveseekplayer = GetComponent< MovimentaçãoInimigosOtimizada> ();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

        Gun.DefinirPlayer(player.transform);
        moveseekplayer.DefinirPlayer(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        distanciadoplayer = Vector3.Distance(player.transform.position, transform.position);

        
        if(distanciadoplayer > moveseekplayer.rangeAtual && estadoatual != EstadosdosInimigos.GoingtoPlayer)
        {
            MudarEstado(EstadosdosInimigos.GoingtoPlayer);
        }
        else if (distanciadoplayer <= moveseekplayer.rangeAtual && estadoatual != EstadosdosInimigos.Ataque)
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
