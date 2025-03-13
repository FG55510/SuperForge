using UnityEngine;
using UnityEngine.AI;

public class MovimentaçãoInimigos : MonoBehaviour
{

    NavMeshAgent agent;
    public float rangeatual;
    

    [SerializeField] private Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MudarRangeentrePlayer(rangeatual);
    }

    public void MudarRangeentrePlayer(float novoRange)
    {
        agent.stoppingDistance = novoRange;
        rangeatual = novoRange;
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
