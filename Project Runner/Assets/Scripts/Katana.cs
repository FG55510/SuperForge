using UnityEngine;

public class Katana : MonoBehaviour
{
    private Collider HitBox;
    [SerializeField] private float Duracaodoataque;
    [SerializeField] private float timer;
    [SerializeField] private bool ataque;
    [SerializeField] private int danoplayer;



    void Start()
    {
        GameManager.INSTANCE.PlayerAttack.AddListener(HitBoxAtivada);
        HitBox = GetComponent<Collider>();
        HitBox.enabled = false;
        timer = Duracaodoataque;
        ataque = false;
    }

    void Update()
    {
        if (ataque)
        {
            timer -= Time.deltaTime;
            if (timer <= 0){
                HitBox.enabled = false;
                timer = Duracaodoataque;
                ataque = false;
                Debug.Log("Fim de Ataque");
            }
        }
    }


    private void HitBoxAtivada()
    {
        HitBox.enabled = true;
        ataque = true;
        Debug.Log("Ataque");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIt");
        if(other.CompareTag("Inimigo"))
        {
            EnemyLife inimigoacertado = other.GetComponent<EnemyLife>();
            inimigoacertado.Tiravida(danoplayer);
        }
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.PlayerAttack.RemoveListener(HitBoxAtivada);
    }


}
