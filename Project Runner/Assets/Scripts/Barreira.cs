using UnityEngine;

public class Barreira : MonoBehaviour
{
    private Collider barreira;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.INSTANCE.IniciodaWave.AddListener(PrendePlayer);
        GameManager.INSTANCE.FimdaWave.AddListener(PlayerLiberto);
        barreira = GetComponent<Collider>();
    }


    private void PrendePlayer(int a)
    {
        barreira.isTrigger = false;
        print("player preso");
    }

    private void PlayerLiberto()
    {
        barreira.isTrigger = true;
        print("player liberado");
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.IniciodaWave.RemoveListener(PrendePlayer);
        GameManager.INSTANCE.FimdaWave.RemoveListener(PlayerLiberto);
    }
}
