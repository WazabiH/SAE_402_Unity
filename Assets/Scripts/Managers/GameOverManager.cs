using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("Listen to event channels")]
    public VoidEventChannel onPlayerDeath;    // l’event channel déclenché quand le joueur meurt

    [Header("UI")]
    public GameOverUI gameOverUI;             // ton composant GameOverUI pour afficher le canvas

    [Header("Disable on Death")]
    public MonoBehaviour[] disableOnDeath;    // liste des scripts à désactiver (ex. PlayerMovement, PlayerHealth, PlayerInvulnerable)

    private void OnEnable()
    {
        onPlayerDeath.OnEventRaised += HandleGameOver;
    }

    private void OnDisable()
    {
        onPlayerDeath.OnEventRaised -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        // 1) désactive tous les scripts listés
        foreach (var comp in disableOnDeath)
        {
            if (comp != null)
                comp.enabled = false;
        }

        // 2) affiche l'écran Game Over
        if (gameOverUI != null)
            gameOverUI.ShowGameOver();
        else
            Debug.LogError("GameOverManager: gameOverUI n'est pas assigné !");
    }
}
