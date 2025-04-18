using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    
    public void StartGame() 
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        // Ajoutez ici le code pour gérer les paramètres
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}