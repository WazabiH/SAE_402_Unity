using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeed = 0.1f; // de 0 (aucun défilement) à 1 (rapide)

    void Start()
    {
        // Commencer en bas
        scrollRect.verticalNormalizedPosition = 0f;
    }

    void Update()
    {
        // Faire monter progressivement
        float newPos = scrollRect.verticalNormalizedPosition + scrollSpeed * Time.deltaTime;
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(newPos);
    }
}
