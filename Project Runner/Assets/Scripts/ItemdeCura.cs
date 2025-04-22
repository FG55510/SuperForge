using UnityEngine;

public class ItemdeCura : MonoBehaviour
{
    [SerializeField] private int cura;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.INSTANCE.PlayerCuraVida.Invoke(cura);
            gameObject.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
