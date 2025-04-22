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

    public UnityEvent<int> IniciodaWave;
    public UnityEvent FimdaWave;
    [SerializeField] private int waveatual;


    public UnityEvent<int> PlayerTomaDano;
    public UnityEvent Playermorre;

    public UnityEvent<int> PlayerCuraVida;


    public UnityEvent<bool> PlayerDefend;
    
    enum Escudoplayer { EscudoAtivo, Escudoquebrado, EscudoInativo}
    Escudoplayer estadodoescudo;
    [SerializeField] private float duraçãocooldownescudo;
    private float cooldownescudo;

    public UnityEvent<bool> PlayerAttack;

    [SerializeField] private float Duracaodoataque;
    [SerializeField] private float timerataque;
    private bool timerataqueativo;

  
    private void Start()
    {
        waveatual = 1;


        timerataque = Duracaodoataque;
        timerataqueativo = false;
        estadodoescudo = Escudoplayer.EscudoInativo;
        cooldownescudo = duraçãocooldownescudo;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IniciodaWave.Invoke(waveatual);
        }

        

        if (Input.GetKeyDown(KeyCode.Mouse0) && !timerataqueativo)
        {
            PlayerAttack.Invoke(true);
            timerataqueativo = true;
        }

        if (timerataqueativo)
        {
            timerataque -= Time.deltaTime;
            if (timerataque <= 0)
            {
                timerataque = Duracaodoataque;
                Debug.Log("Fim de Ataque");
                timerataqueativo = false;
                PlayerAttack.Invoke(false);
            }
        }
        


        if (Input.GetKeyDown(KeyCode.Mouse1) && estadodoescudo == Escudoplayer.EscudoInativo)
        {
            Debug.Log("Defesa");
            PlayerDefend.Invoke(true);
            estadodoescudo = Escudoplayer.EscudoAtivo;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) && estadodoescudo == Escudoplayer.EscudoAtivo)
        {
            Debug.Log("DefesaStop");
            PlayerDefend.Invoke(false);
            estadodoescudo = Escudoplayer.EscudoInativo;
        }

        if(estadodoescudo == Escudoplayer.Escudoquebrado)
        {
            cooldownescudo -= Time.deltaTime;
            if(cooldownescudo <= 0)
            {
                estadodoescudo = Escudoplayer.EscudoInativo;
                cooldownescudo = duraçãocooldownescudo;
            }
        }
    }

    public void AtivaaWave()
    {
        IniciodaWave.Invoke(waveatual);
    }

    private void FinaldaWave()
    {
        FimdaWave.Invoke();
        waveatual++;
    }

    public void CheckInimigosRestantes()
    {
        EnemyLife inimigoativo = FindAnyObjectByType<EnemyLife>();
        if (inimigoativo == null)
        {
            FinaldaWave();
        }
    }

    public void EscudoQuebrado()
    {
        estadodoescudo = Escudoplayer.Escudoquebrado;

    }

}
