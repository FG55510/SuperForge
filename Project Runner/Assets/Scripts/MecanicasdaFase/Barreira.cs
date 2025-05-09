using UnityEngine;

public class Barreira : MonoBehaviour
{
    private Collider barreira;
    private MeshRenderer mesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.INSTANCE.IniciodaWave.AddListener(PrendePlayer);
        GameManager.INSTANCE.FimdaWave.AddListener(PlayerLiberto);
        barreira = GetComponent<Collider>();
        mesh = GetComponent<MeshRenderer>();
    }


    private void PrendePlayer(int a)
    { 
        mesh.enabled = true;
        barreira.isTrigger = false;
        print("player preso");
    }

    private void PlayerLiberto()
    {
        barreira.isTrigger = true;
        mesh.enabled = false;
        print("player liberado");
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.IniciodaWave?.RemoveListener(PrendePlayer);
        GameManager.INSTANCE.FimdaWave?.RemoveListener(PlayerLiberto);
    }
}
