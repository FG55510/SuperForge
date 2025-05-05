using UnityEngine;

public class MovimentaçãoInimigosOtimizada : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Animator anim;
    [SerializeField] private float velocidade = 3.0f;
    [SerializeField] private float distancia;
    
    public float rangeminpertodoplayer;
    public float rangemaxlongedoplayer;
    
    public bool playernorangemin;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (player == null) return;

        

        if(!playernorangemin){
            Vector3 direcao = player.position - transform.position;
        
            distancia = direcao.magnitude;
            if (distancia > rangemaxlongedoplayer)
            {
    
                
                
                Vector3 movimento = direcao.normalized * velocidade;
                rb.linearVelocity = new Vector3(movimento.x, rb.linearVelocity.y, movimento.z); 
                direcao.y = 0f;
    
               
                Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotacaoAlvo, 10f * Time.fixedDeltaTime));
    
                anim.SetFloat("Speed", movimento.magnitude);
            }
            else
            {
                rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f); 
                anim.SetFloat("Speed", 0f);
            }
            }
        else{
            Vector3 direcao = transform.position - player.position;
        
            distancia = direcao.magnitude;
            Vector3 movimento = direcao.normalized * velocidade;
            rb.linearVelocity = new Vector3(movimento.x, rb.linearVelocity.y, movimento.z); 
            direcao.y = 0f;

           
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotacaoAlvo, 10f * Time.fixedDeltaTime));
        
        }
        
    }


    public void DefinirPlayer(Transform alvo)
    {
        player = alvo;
    }
}
