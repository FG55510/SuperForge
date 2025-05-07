using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MaquinadeestadoparaAtaqueCorpoaCorpo : MonoBehaviour
{
    [SerializeField] private EstadosdosInimigos estadoatual;
    [SerializeField] private AtaqueCorpoaCorpoInimigos ataque;
    [SerializeField] private MovimentaçãoInimigosOtimizada move;
    
    [SerializeField] private GameObject player;
    [SerializeField] private float distanciadoplayer;

    public float range;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ataque = GetComponentInChildren<AtaqueCorpoaCorpoInimigos>();
        move = GetComponent<MovimentaçãoInimigosOtimizada>();
        move.DefinirPlayer(player.transform);
        ataque.DeterminaPlayer(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
      distanciadoplayer = Vector3.Distance(player.transform.position, transform.position);

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
            SoundManager.INSTANCE.PlayEnemyRoboAtack();
        }

    }

    private void MudaEstados(EstadosdosInimigos estado)
    {
        ResetEstados();

        switch (estado)
        {
            case EstadosdosInimigos.Ataque:
                ataque.enabled = true;

                break;

            case EstadosdosInimigos.GoingtoPlayer:
                ataque.enabled = false;
                move.enabled = true;
                break;

        }
    }

    IEnumerator Movimentoaposataque(float tempo)
    {
        yield return null;
    }
    private void ResetEstados()
    {
        ataque.enabled = false;
        move.enabled = false;

    }
}
