using UnityEngine;
using UnityEngine.SceneManagement;


public class Menuprincipal : MonoBehaviour
{

    [SerializeField] private string cenadojogo;

    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject configura��es;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Configura��esDesativadas();
    }


    public void Jogar()
    {
        print("jogar");
        SceneManager.LoadScene(cenadojogo);
    }

    public void Configura��esAtivadas()
    {
        configura��es.SetActive(true);
        menu.SetActive(false);
    }

    public void Configura��esDesativadas()
    {
        configura��es.SetActive(false);
        menu.SetActive(true);
    }



    public void Sair()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#endif
    }
}
