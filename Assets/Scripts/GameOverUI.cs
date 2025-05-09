using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public string levelToRetry = "Level1";
    public string menuScene    = "MainMenu";

    void Awake()
    {
        gameOverCanvas.SetActive(false);
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelToRetry);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
