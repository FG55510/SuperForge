using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SceneManagement;

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
    [Header("--- Controles de Wave ---")]
    public UnityEvent<int> IniciodaWave;
    public UnityEvent FimdaWave;
    [SerializeField] private int waveatual;

    [Header("--- Controles vida do Player ---")]
    public UnityEvent<int> PlayerTomaDano;
    public UnityEvent Playermorre;
    public UnityEvent<int> PlayerCuraVida;
    public UnityEvent<Vector3> ItemdeCuraDropado;

    [Header("--- Controles escudo do Player ---")]
    public UnityEvent<bool> PlayerDefend; 
    enum Escudoplayer { EscudoAtivo, Escudoquebrado, EscudoInativo}
    Escudoplayer estadodoescudo;
    [SerializeField] private float dura��ocooldownescudo;
    private float cooldownescudo;


    [Header("--- Controles ataque do Player ---")]
    public UnityEvent<bool> PlayerAttack;
    [SerializeField] private float Duracaodoataque;
    [SerializeField] private float timerataque;
    private bool timerataqueativo;

    [Header("--- Controles combo do Player ---")]
    [SerializeField] private int comboamount;
    [SerializeField] private float dura��ocombo;

    [Header("--- Controles da fase ---")]
    public UnityEvent PlayerWin;

    private void Start()
    {
        waveatual = 1;


        timerataque = Duracaodoataque;
        timerataqueativo = false;
        estadodoescudo = Escudoplayer.EscudoInativo;
        cooldownescudo = dura��ocooldownescudo;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerCuraVida.Invoke(100);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerTomaDano.Invoke(100);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            VoltaMenu();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !timerataqueativo)
        {
            PlayerAttack.Invoke(true);
            timerataqueativo = true;
            SoundManager.INSTANCE.PlayAtack();
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
                cooldownescudo = dura��ocooldownescudo;
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

    private void VoltaMenu()
    {
        SceneManager.LoadScene( "MenuPrincipal");
    }

}
