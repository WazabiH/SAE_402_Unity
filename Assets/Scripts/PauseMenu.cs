using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import pour charger des scènes (menu principal)

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    // Update est utilisé pour détecter la touche "Escape"
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Vérifie si "Escape" est pressé
        {
            if (PausePanel != null) // Vérifie que le panel est configuré
            {
                if (PausePanel.activeSelf)
                {
                    Continue(); // Reprendre le jeu
                }
                else
                {
                    Pause(); // Mettre en pause
                }
            }
        }
    }

    public void Pause()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(true); // Affiche le menu pause
            Time.timeScale = 0; // Met le jeu en pause
        }
    }

    public void Continue()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false); // Cache le menu pause
            Time.timeScale = 1; // Reprend le jeu
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Reprend le temps avant de charger une nouvelle scène
        SceneManager.LoadScene("MainMenu"); // Charge la scène du menu principal
    }
}