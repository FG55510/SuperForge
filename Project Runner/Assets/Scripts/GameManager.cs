using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
    }


    public UnityEvent<bool> PlayerDefend;

    public UnityEvent<bool> PlayerAttack;
    [SerializeField] private float Duracaodoataque;
    [SerializeField] private float timer;
    private bool timerativo;

  
    private void Start()
    {
        timer = Duracaodoataque;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack.Invoke(true);
            timerativo = true;
        }

        if (timerativo)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = Duracaodoataque;
                Debug.Log("Fim de Ataque");
                timerativo = false;
                PlayerAttack.Invoke(false);
            }
        }


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Defesa");
            PlayerDefend.Invoke(true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Debug.Log("DefesaStop");
            PlayerDefend.Invoke(false);
        }
    }
}
