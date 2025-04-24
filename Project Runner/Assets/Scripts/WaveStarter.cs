using UnityEngine;

public class WaveStarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.AtivaaWave();
        }
    }
}
