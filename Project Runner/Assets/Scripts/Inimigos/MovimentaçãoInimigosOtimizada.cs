using UnityEngine;

public class MovimentaçãoInimigosOtimizada : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Animator anim;
    [SerializeField] private float velocidade = 3.0f;
    public float rangeAtual = 2.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void MudarRangeentrePlayer(float novoRange)
    {
        rangeAtual = novoRange;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector3 direcao = player.position - transform.position;
        
        float distancia = direcao.magnitude;

        if (distancia > rangeAtual)
        {
            Vector3 movimento = direcao.normalized * velocidade;
            rb.linearVelocity = new Vector3(movimento.x, rb.linearVelocity.y, movimento.z); // mantém a gravidade no eixo Y
            direcao.y = 0f;

            // Rotaciona suavemente em direção ao jogador
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotacaoAlvo, 10f * Time.fixedDeltaTime));

            anim.SetFloat("Speed", movimento.magnitude);
        }
        else
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f); // para movimento horizontal, mantém Y
            anim.SetFloat("Speed", 0f);
        }
    }


    public void DefinirPlayer(Transform alvo)
    {
        player = alvo;
    }
}
