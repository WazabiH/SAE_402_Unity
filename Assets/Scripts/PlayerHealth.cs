using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sr;
    public PlayerInvulnerable playerInvulnerable;

    [Tooltip("Please uncheck it on production")]
    public bool needResetHP = true;

    [Header("ScriptableObjects")]
    public PlayerData playerData;

    [Header("Debug")]
    public VoidEventChannel onDebugDeathEvent;

    [Header("Broadcast event channels")]
    public VoidEventChannel onPlayerDeath;

    [Header("UI")]
    public HealthBar healthBar;   // ← ajout

    private void Awake()
    {
        if (needResetHP || playerData.currentHealth <= 0)
            playerData.currentHealth = playerData.maxHealth;

        // Initialise la barre au max
        healthBar.SetMathHealth((int)playerData.maxHealth);
    }

    private void OnEnable()
    {
        onDebugDeathEvent.OnEventRaised += Die;
    }

    public void TakeDamage(float damage)
    {
        if (playerInvulnerable.isInvulnerable && damage < float.MaxValue) 
            return;

        // Applique les dégâts
        playerData.currentHealth -= damage;

        // ← Mets à jour la barre après les dégâts
        healthBar.SetHealth((int)playerData.currentHealth);

        if (playerData.currentHealth <= 0)
            Die();
        else
            StartCoroutine(playerInvulnerable.Invulnerable());
    }

    private void Die()
    {
        onPlayerDeath?.Raise();
        GetComponent<Rigidbody2D>().simulated = false;
        transform.Rotate(0f, 0f, 45f);
        animator.SetTrigger("Death");
    }

    public void OnPlayerDeathAnimationCallback()
    {
        sr.enabled = false;
    }

    private void OnDisable()
    {
        onDebugDeathEvent.OnEventRaised -= Die;
    }
}
