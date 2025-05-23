using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ArmaInimigo : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private int dano = 200;

    [SerializeField] private LayerMask LayerPlayer;

    private LineRenderer laserline;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);

    public float timertoshootquick;

    public float timertoshootslow;

    private float timertoshoot;

    public float timer;

    [SerializeField] private Transform arma;

    public float distancia;

    [SerializeField] private Animator anim;


void Start()
    {
        anim = GetComponent<Animator>();
        laserline = GetComponent<LineRenderer>();
        timertoshoot = timertoshootquick;
        timer = timertoshoot;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        Vector3 Direction = (player.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Direction);
        transform.rotation = rotation;

        Vector3 Directionshoot = arma.forward;
        if (timer <= 0)
        {
            

            

            
            RaycastHit hit;

            StartCoroutine(ShotEffect());


            laserline.SetPosition(0, arma.position);
            if (Physics.Raycast(arma.position, Directionshoot, out hit, 1000f, LayerPlayer))
            {
                laserline.SetPosition(1, hit.point);
                Debug.DrawRay(arma.position, Directionshoot * 1000f, Color.red);
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

    private IEnumerator ShotEffect()
    {
        SoundManager.INSTANCE.PlayEnemyRoboAtack();

        laserline.enabled = true;

        yield return shotDuration;


        laserline.enabled = false;
    }

    private void shoot()
    {

    }


    
    public void DefinirPlayer(Transform target)
    {
        player = target;
    }

    public void AtiraLento()
    {
        timertoshoot = timertoshootslow;
    }

    public void AtiraRapido()
    {
        timertoshoot = timertoshootquick;
    }

}
