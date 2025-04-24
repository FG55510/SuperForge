using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ArmaInimigo : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private int dano = 200;

    [SerializeField] private LayerMask LayerPlayer;

    private LineRenderer laserline;

    public float timertoshoot;

    public float timer;

    [SerializeField] private Transform arma;

    public float distancia;

    [SerializeField] private Animator anim;


// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        anim = GetComponent<Animator>();
        laserline = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        Vector3 Direction = (player.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Direction);
        transform.rotation = rotation;
        if (timer <= 0)
        {
            

            RaycastHit hit;
            if (Physics.Raycast(arma.position, Direction, out hit, 1000f, LayerPlayer))
            {
                Debug.DrawRay(arma.position, Direction * 1000f, Color.red);
                  GameManager.INSTANCE.PlayerTomaDano.Invoke(dano);
                anim.SetTrigger("Shoot");

            }
            else
            {
                Debug.Log("Raycast did not hit any target.");
            }
            timer = timertoshoot;
        }
        

        
    }


    public void DefinirPlayer(Transform target)
    {
        player = target;
    }

}
