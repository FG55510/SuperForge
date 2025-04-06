using UnityEngine;
using UnityEngine.SceneManagement;


public class Menuprincipal : MonoBehaviour
{

    [SerializeField] private string cenadojogo;

    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject configurações;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ConfiguraçõesDesativadas();
    }


    public void Jogar()
    {
        print("jogar");
        SceneManager.LoadScene(cenadojogo);
    }

    public void ConfiguraçõesAtivadas()
    {
        configurações.SetActive(true);
        menu.SetActive(false);
    }

    public void ConfiguraçõesDesativadas()
    {
        configurações.SetActive(false);
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
