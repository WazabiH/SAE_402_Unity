using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel; // Le panneau du menu pause
    public BoolEventChannel OnTogglePauseEvent; // Référence au ScriptableObject BoolEventChannel

    private bool isPaused = false; // État actuel du jeu (en pause ou non)

    void Start()
    {
        // Assure que le jeu commence sans être en pause
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    void Update()
    {
        // Vérifie si la touche "Escape" a été pressée
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed, toggling pause...");
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // Synchronise l'état de pause
        isPaused = !isPaused;

        // Met à jour l'état du panneau pause et du temps
        PausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;

        // Émet l'événement via le ScriptableObject
        if (OnTogglePauseEvent != null)
        {
            OnTogglePauseEvent.Raise(isPaused);
        }

        // Debug pour suivre l'état
        Debug.Log($"Pause Toggled: isPaused = {isPaused}, Time.timeScale = {Time.timeScale}");
    }

    public void ResumeGame()
    {
        // Assure que tout est désactivé correctement
        isPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        // Émet l'événement via le ScriptableObject
        if (OnTogglePauseEvent != null)
        {
            OnTogglePauseEvent.Raise(isPaused);
        }

        Debug.Log("Game resumed");
    }

    public void ReloadLevel()
    {
        // Reprend le temps avant de recharger la scène
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        // Reprend le temps avant de charger le menu principal
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}