using UnityEngine;

public class PlayerActionsAnimated : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.INSTANCE.PlayerAttack.AddListener(AttackAnimation);
        GameManager.INSTANCE.PlayerDefend.AddListener(DefenceAnimation);
        GameManager.INSTANCE.Playermorre.AddListener(DeathAnimation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DefenceAnimation(bool estado)
    {
        anim.SetBool("Defence", estado);
    }

    private void AttackAnimation(bool estado)
    {
        anim.SetBool("Attack", estado);
    }

    private void DeathAnimation()
    {

    }
    private void OnDestroy()
    {
        GameManager.INSTANCE.PlayerAttack.RemoveListener(AttackAnimation);
        GameManager.INSTANCE.PlayerAttack.RemoveListener(DefenceAnimation);
        GameManager.INSTANCE.Playermorre.RemoveListener(DeathAnimation);
    }

}
