using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInimigos : MonoBehaviour
{
    [SerializeField] private List<Transform> Positionspawnerswave1;
    [SerializeField] private int numerodeagentesparainvocar1;
    [SerializeField] private int numeroderobosparainvocar1;

    [SerializeField] private List<Transform> Positionspawnerswave2;
    [SerializeField] private int numerodeagentesparainvocar2;
    [SerializeField] private int numeroderobosparainvocar2;

    [SerializeField] private List<Transform> Positionspawnerswave3;
    [SerializeField] private int numerodeagentesparainvocar3;
    [SerializeField] private int numeroderobosparainvocar3;
    // [SerializeField] private int waveatual;

    [SerializeField] private ObjectPool pooldeinimigos;

    [SerializeField] private GameObject inimigospawnado;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pooldeinimigos = GetComponent<ObjectPool>();
        GameManager.INSTANCE.IniciodaWave.AddListener(SpawnInimigos);
    }


    public void SpawnInimigos(int waveatual)
    {
        switch (waveatual)
        {
            case 1:
                for (int i = 0; i < numerodeagentesparainvocar1; i++)
                {
                    int randomspawner = Random.Range(0, Positionspawnerswave1.Count);
                    Transform p = Positionspawnerswave1[randomspawner];

                    inimigospawnado = pooldeinimigos.GetPooledObject();
                    inimigospawnado.transform.position = p.position;

                    inimigospawnado.SetActive(true);
                    EnemyTypeSelection tipodeinimigo = inimigospawnado.GetComponent<EnemyTypeSelection>();
                    tipodeinimigo.SelecionatipoAgente();
                }

                for (int i = 0; i < numeroderobosparainvocar1; i++)
                {
                    int randomspawner = Random.Range(0, Positionspawnerswave1.Count);
                    Transform p = Positionspawnerswave1[randomspawner];

                    inimigospawnado = pooldeinimigos.GetPooledObject();
                    inimigospawnado.transform.position = p.position;

                    inimigospawnado.SetActive(true);
                    EnemyTypeSelection tipodeinimigo = inimigospawnado.GetComponent<EnemyTypeSelection>();
                    tipodeinimigo.SelecionatipoRobo();
                }

                break;


            case 2:
                for (int i = 0; i < numerodeagentesparainvocar2; i++)
                {
                    int randomspawner = Random.Range(0, Positionspawnerswave2.Count);
                    Transform p = Positionspawnerswave2[randomspawner];

                    inimigospawnado = pooldeinimigos.GetPooledObject();
                    inimigospawnado.transform.position = p.position;

                    inimigospawnado.SetActive(true);
                    EnemyTypeSelection tipodeinimigo = inimigospawnado.GetComponent<EnemyTypeSelection>();
                    tipodeinimigo.SelecionatipoAgente();
                }

                for (int i = 0; i < numeroderobosparainvocar2; i++)
                {
                    int randomspawner = Random.Range(0, Positionspawnerswave2.Count);
                    Transform p = Positionspawnerswave2[randomspawner];

                    inimigospawnado = pooldeinimigos.GetPooledObject();
                    inimigospawnado.transform.position = p.position;

                    inimigospawnado.SetActive(true);
                    EnemyTypeSelection tipodeinimigo = inimigospawnado.GetComponent<EnemyTypeSelection>();
                    tipodeinimigo.SelecionatipoRobo();
                }
                break;


            case 3:
                for (int i = 0; i < numerodeagentesparainvocar3; i++)
                {
                    int randomspawner = Random.Range(0, Positionspawnerswave3.Count);
                    Transform p = Positionspawnerswave3[randomspawner];

                    inimigospawnado = pooldeinimigos.GetPooledObject();
                    inimigospawnado.transform.position = p.position;

                    inimigospawnado.SetActive(true);
                    EnemyTypeSelection tipodeinimigo = inimigospawnado.GetComponent<EnemyTypeSelection>();
                    tipodeinimigo.SelecionatipoAgente();
                }

                for (int i = 0; i < numeroderobosparainvocar3; i++)
                {
                    int randomspawner = Random.Range(0, Positionspawnerswave3.Count);
                    Transform p = Positionspawnerswave3[randomspawner];

                    inimigospawnado = pooldeinimigos.GetPooledObject();
                    inimigospawnado.transform.position = p.position;

                    inimigospawnado.SetActive(true);
                    EnemyTypeSelection tipodeinimigo = inimigospawnado.GetComponent<EnemyTypeSelection>();
                    tipodeinimigo.SelecionatipoRobo();
                }
                break;



        }
    }

    private void OnDestroy()
    {
        GameManager.INSTANCE.IniciodaWave?.RemoveListener(SpawnInimigos);
    }
}
