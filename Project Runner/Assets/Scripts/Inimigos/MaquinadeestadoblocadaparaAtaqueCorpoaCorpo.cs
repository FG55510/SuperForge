using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MaquinadeestadoparaAtaqueCorpoaCorpo : MonoBehaviour
{
    [SerializeField] private EstadosdosInimigos estadoatual;
    [SerializeField] private AtaqueCorpoaCorpoInimigos ataque;
    [SerializeField] private MovimentaçãoInimigosOtimizada move;
    [SerializeField] private float tempodemovimentoentreataques =3;
    [SerializeField] private float tempodoataque = 0.5f;

    [SerializeField] private GameObject player;
    [SerializeField] private float distanciadoplayer;

    [SerializeField] private float range;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ataque = GetComponentInChildren<AtaqueCorpoaCorpoInimigos>();
        move = GetComponent<MovimentaçãoInimigosOtimizada>();
        move.DefinirPlayer(player.transform);
        ataque.DeterminaPlayer(player.transform);
        move.range = range;
        MudaEstados(EstadosdosInimigos.GoingtoPlayer);
    }

    // Update is called once per frame
    void Update()
    {
      distanciadoplayer = Vector3.Distance(player.transform.position, transform.position);

        if (range >= distanciadoplayer && estadoatual == EstadosdosInimigos.GoingtoPlayer)
        {
            MudaEstados(EstadosdosInimigos.Ataque);
        }

    }

    private void MudaEstados(EstadosdosInimigos estado)
    {
        ResetEstados();

        switch (estado)
        {
            case EstadosdosInimigos.Ataque:
                ataque.enabled = true;
                ataque.IniciaAtaque();
                move.enabled = false;
                StartCoroutine(Movimentoaposataque(tempodemovimentoentreataques, tempodoataque));
                break;

            case EstadosdosInimigos.GoingtoPlayer:
                ataque.enabled = false;
                move.enabled = true;
                move.Desativarretirada();
                break;

            case EstadosdosInimigos.MovimentoEntreAtaques:
                ataque.enabled = false;
                move.enabled = true;
                move.Ativarretirada();
                break;

        }
        estadoatual = estado;
    }

    IEnumerator Movimentoaposataque(float tempoentreataques, float tempodoataque)
    {
        yield return new WaitForSeconds(tempodoataque);
        MudaEstados(EstadosdosInimigos.MovimentoEntreAtaques);
        yield return new WaitForSeconds(tempoentreataques);
        MudaEstados(EstadosdosInimigos.GoingtoPlayer);
    }
    private void ResetEstados()
    {
        ataque.enabled = false;
        move.enabled = false;

    }
}
