using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ArmaInimigo : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private int dano;

    [SerializeField] private LayerMask LayerPlayer;


    public float timertoshoot;

    public float timer;

    public int offset;

    public float distancia;

    [SerializeField] private Animator anim;


// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test");
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 Direction = (player.position - transform.position + Vector3.up * offset).normalized;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Direction, out hit, 1000f, LayerPlayer))
            {
                Debug.DrawRay(transform.position, Direction * 1000f, Color.red);
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
