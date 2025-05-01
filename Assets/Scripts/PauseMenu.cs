using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel; // Le panneau du menu pause
    public BoolEventChannel OnTogglePauseEvent; // Référence au ScriptableObject BoolEventChannel

    private bool isPaused = false; // État actuel du jeu (en pause ou non)

    void Start()
    {
        // Assure que le jeu commence avec le menu pause désactivé et le temps actif
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    void Update()
    {
        // Gestion de la touche "Escape" pour activer/désactiver le menu pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // Inverse l'état de pause
        isPaused = !isPaused;

        // Synchronise l'état du panneau et du temps
        PausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;

        // Émettre l'événement via le ScriptableObject
        if (OnTogglePauseEvent != null)
        {
            OnTogglePauseEvent.Raise(isPaused);
        }

        // Debug pour vérifier l'état
        Debug.Log($"Pause toggled: isPaused = {isPaused}, Time.timeScale = {Time.timeScale}");
    }

    public void ResumeGame()
    {
        // Assure que le jeu reprend directement
        isPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        // Émettre l'événement via le ScriptableObject
        if (OnTogglePauseEvent != null)
        {
            OnTogglePauseEvent.Raise(isPaused);
        }

        Debug.Log("Game resumed");
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