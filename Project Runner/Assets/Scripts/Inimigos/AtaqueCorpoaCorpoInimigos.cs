using UnityEngine;

public class AtaqueCorpoaCorpoInimigos : MonoBehaviour
{
    [SerializeField]  private Collider HitBox;


    [SerializeField] private float Duracaodoataque;
    [SerializeField] private float timer;
    [SerializeField] private int dano;
    [SerializeField] private bool timerativo;

    public Transform player;

    [SerializeField] Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitBox = GetComponent<Collider>();
        HitBox.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = (player.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Direction);
        transform.rotation = rotation;
        if (timerativo)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = Duracaodoataque;
                Debug.Log("Fim de Ataque inimigo");
                timerativo = false;
                HitBox.enabled = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIt");

        

        if (other.CompareTag("Player") )
        {
            GameManager.INSTANCE.PlayerTomaDano.Invoke(dano);
        }
    }

    public void IniciaAtaque()
    {
        timerativo = true;
        anim.SetTrigger("Attack");
        HitBox.enabled = true;
    } 

    public void DeterminaPlayer(Transform alvo)
    {
        player = alvo;
    }
}
