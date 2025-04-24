using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel; // Le panneau du menu pause
    public BoolEventChannel OnTogglePauseEvent; // Référence au ScriptableObject BoolEventChannel

    private bool isPaused = false; // État actuel du jeu (en pause ou non)

    void Start()
    {
        // Désactiver le menu pause au démarrage
        PausePanel.SetActive(false);
    }

    void Update()
    {
        // "Echap" pour activer/désactiver le menu pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused; // Inverse l'état de pause
        PausePanel.SetActive(isPaused); // Active ou désactive le menu pause
        Time.timeScale = isPaused ? 0 : 1; // Met le temps en pause ou reprend

        // Émettre l'événement via le ScriptableObject
        if (OnTogglePauseEvent != null)
        {
            OnTogglePauseEvent.Raise(isPaused); // Émet l'état de pause (true/false)
        }
    }

    public void ReloadLevel()
    {
        // Reprendre le temps avant de recharger la scène
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        // Reprendre le temps avant de charger la scène du menu principal
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}