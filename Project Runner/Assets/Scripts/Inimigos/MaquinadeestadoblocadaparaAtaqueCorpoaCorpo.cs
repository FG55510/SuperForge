using UnityEngine;

public class MaquinadeestadoblocadaparaAtaqueCorpoaCorpo : MonoBehaviour
{
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
}
