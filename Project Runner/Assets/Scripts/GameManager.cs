using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent PlayerAttack;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack.Invoke();
        }
    }
}
