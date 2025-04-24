using UnityEngine;

public class ItemdeCuraManager : MonoBehaviour
{
    private ObjectPool Poolerdeitens;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Poolerdeitens = GetComponent<ObjectPool>();
        GameManager.INSTANCE.ItemdeCuraDropado.AddListener(SpawnItemdecura);
    }


    private void SpawnItemdecura(Vector3 position)
    {
        GameObject itemdecuraspawnado = Poolerdeitens.GetPooledObject();
        itemdecuraspawnado.transform.position = position;

        itemdecuraspawnado.SetActive(true);
    }


    private void OnDestroy()
    {
        GameManager.INSTANCE.ItemdeCuraDropado.RemoveListener(SpawnItemdecura);
    }
}
