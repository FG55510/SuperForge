using UnityEngine;
using UnityEngine.AI;

public class MovimentaçãoInimigos : MonoBehaviour
{

    NavMeshAgent agent;
    public float rangeatual;
    
    [SerializeField] private Transform player;

    [SerializeField] private Animator anim;

    [SerializeField] private float velocity;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MudarRangeentrePlayer(rangeatual);

        anim = GetComponent<Animator>();
    }

    public void MudarRangeentrePlayer(float novoRange)
    {
        agent.stoppingDistance = novoRange;
        rangeatual = novoRange;
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);


        velocity = agent.velocity.magnitude;
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }


    public void DefinirPlayer(Transform target)
    {
        player = target;
    }
}
