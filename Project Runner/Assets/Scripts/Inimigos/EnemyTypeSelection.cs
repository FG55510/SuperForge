using UnityEngine;
 enum TiposdeInimigos{
    Robos, Agentes
}
public class EnemyTypeSelection : MonoBehaviour
{

    [SerializeField] private GameObject ModeloRobo;
    [SerializeField] private GameObject ModeloAgente;

    [SerializeField] private Tipodeinimigo tipoatualdesteinimigo; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void TipodeInimigoSelecionado(Tipodeinimigo tipo)
    {
        ResetdeInimigos();

        switch (tipo)
        {
            case Tipodeinimigo.InimigoMedio:
                ModeloAgente.SetActive(true);
                break;

            case Tipodeinimigo.Inimigopequeno:
                ModeloRobo.SetActive(true);
                break;
        }
    }

    public void SelecionatipoAgente()
    {
        tipoatualdesteinimigo = Tipodeinimigo.InimigoMedio;
        TipodeInimigoSelecionado(tipoatualdesteinimigo);
    }

    public void SelecionatipoRobo()
    {
        tipoatualdesteinimigo = Tipodeinimigo.Inimigopequeno;
        TipodeInimigoSelecionado(tipoatualdesteinimigo);
    }

    public void ResetdeInimigos()
    {
        ModeloAgente.transform.position = transform.position;
        ModeloRobo.transform.position = transform.position;
        ModeloAgente.SetActive(false);
        ModeloRobo.SetActive(false);
        //gameObject.SetActive(false);
    }
}
