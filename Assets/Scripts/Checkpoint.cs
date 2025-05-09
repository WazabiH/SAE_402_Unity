using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Checkpoint : MonoBehaviour
{
    public BoxCollider2D bc2d;
    public Vector3Variable lastCheckpointPosition;

    private void Awake()
    {
        // Sécurise l’assignation du collider
        if (bc2d == null)
            bc2d = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        var playerSpawn = collision.GetComponent<PlayerSpawn>();
        if (playerSpawn == null)
            return;

        // Met à jour le point de spawn du joueur
        playerSpawn.currentSpawnPosition = transform.position;

        // Désactive ce checkpoint pour qu’il ne se déclenche plus
        bc2d.enabled = false;

        // Assure-toi que lastCheckpointPosition est bien référencé
        if (lastCheckpointPosition == null)
        {
            Debug.LogError($"[{name}] lastCheckpointPosition n'est pas assigné !");
            return;
        }

        lastCheckpointPosition.CurrentValue = transform.position;
    }
}
