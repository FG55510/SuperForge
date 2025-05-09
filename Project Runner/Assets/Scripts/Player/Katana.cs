using UnityEngine;

public class Katana : MonoBehaviour
{
    private Collider HitBox;
    
    [SerializeField] private int danoplayer;



    void Start()
    {
        GameManager.INSTANCE.PlayerAttack.AddListener(HitBoxAtivada);
        HitBox = GetComponent<Collider>();
        HitBox.enabled = false;

    }




    private void HitBoxAtivada(bool estado)
    {
        HitBox.enabled = estado;
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
        GameManager.INSTANCE.PlayerAttack?.RemoveListener(HitBoxAtivada);
    }


}
