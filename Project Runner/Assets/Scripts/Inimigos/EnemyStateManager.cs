using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EstadosdosInimigos
{
    Ataque,
    GoingtoPlayer,
    Playerperto,
    MovimentoEntreAtaques
}
public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private ArmaInimigo Gun;
    [SerializeField] private MovimentaçãoInimigosOtimizada moveseekplayer;

    [SerializeField] private GameObject player;
    [SerializeField] private float distanciadoplayer;
    [SerializeField] private float Rangetiro;
    [SerializeField] private float RangeDangerZone;

    [SerializeField] private EstadosdosInimigos estadoatual;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Gun = GetComponent<ArmaInimigo>();
        moveseekplayer = GetComponent< MovimentaçãoInimigosOtimizada> ();
        moveseekplayer.range = Rangetiro;

        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

        Gun.DefinirPlayer(player.transform);
        moveseekplayer.DefinirPlayer(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        distanciadoplayer = Vector3.Distance(player.transform.position, transform.position);

        
        if(distanciadoplayer > Rangetiro  && estadoatual != EstadosdosInimigos.GoingtoPlayer)
        {
            MudarEstado(EstadosdosInimigos.GoingtoPlayer );
        }
        if(distanciadoplayer < RangeDangerZone && estadoatual != EstadosdosInimigos.Playerperto)
        {
            MudarEstado(EstadosdosInimigos.Playerperto);
        }
        else if (distanciadoplayer <= Rangetiro  && estadoatual != EstadosdosInimigos.Ataque)
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
                Gun.AtiraRapido();

                break;

            case EstadosdosInimigos.GoingtoPlayer:
                moveseekplayer.enabled = true;
                break;

            case EstadosdosInimigos.Playerperto:
                moveseekplayer.enabled = true;
                moveseekplayer.Ativarretirada();
                Gun.enabled = true;
                Gun.AtiraLento();
                break;

        }

        estadoatual = estado;
            
    }

    IEnumerator PlayerPerto()
    {
        yield return null;
    }

    private void ResetEstados()
    {
        Gun.enabled = false;
        moveseekplayer.enabled = false;

    }

}
