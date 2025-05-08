using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Cette méthode sera appelée par ton bouton
    public void Quit()
    {
#if UNITY_EDITOR
        // En mode Éditeur, stoppe le Play Mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // En Build final, ferme l’application
        Application.Quit();
#endif
    }
}
