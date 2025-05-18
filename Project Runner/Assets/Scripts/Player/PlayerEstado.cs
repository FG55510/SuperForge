using UnityEngine;

public class PlayerEstado : MonoBehaviour
{
    [SerializeField] private PlayerMovement move;
    [SerializeField] private Katana attack;
    void Start()
    {
        move = GetComponent<PlayerMovement>();
        GameManager.INSTANCE.PlayerDefend.AddListener(Playerdefendendo);
        GameManager.INSTANCE.Playermorre.AddListener(PlayerMorre);
    }


    private void Playerdefendendo(bool ativo, EscudoPlayer a)
    {
        move.enabled = !ativo;
        attack.enabled = !ativo;
    }

    private void PlayerMorre()
    {
        move.enabled = false;
        attack.enabled = false;
    }
    private void OnDestroy()
    {

        GameManager.INSTANCE.PlayerDefend?.RemoveListener(Playerdefendendo);
        GameManager.INSTANCE.Playermorre?.RemoveListener(PlayerMorre);
    }
}
