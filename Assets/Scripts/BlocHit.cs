using System.Collections;
using UnityEngine;

public class BlocHit : MonoBehaviour
{
    [Header("Animation & Visuels")]
    public Animator animator;
    public Sprite disabledSprite;       // sprite « cassé » fghgfhfghfg

    [Header("Gameplay")]
    public int numberHit = 2;           // nombre de pommes à donner
    private bool isDisabled = false;    // bloc vidé ?

    [Header("Composants")]
    public SpriteRenderer sr;           // affichage du bloc
    public Collider2D hitCollider;      // collider (isTrigger=true) pour détecter les coups
    // Le collider “normal” (non-trigger) et le PlatformEffector2D restent attachés
    // directement à ce GameObject et **ne sont pas** désactivés

    public GameObject itemPrefab;       // prefab de la pomme
    private ContactPoint2D[] contacts = new ContactPoint2D[1];

    private void Awake()
    {
        // état initial : actif
        isDisabled   = false;
        sr.enabled   = true;
        hitCollider.enabled = true;

        // reset des triggers
        animator.ResetTrigger("IsHit");
        animator.ResetTrigger("Disabled");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ignore si bloc déjà vidé
        if (isDisabled) return;

        // détection d’un coup par en-dessous
        collision.GetContacts(contacts);
        if (contacts[0].normal.y > 0.5f &&
            collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        // laisser une frame le temps à l’Animator de prendre en compte le trigger
        yield return null;

        // jouer l’animation de hit
        animator.SetTrigger("IsHit");

        // une pomme en moins
        numberHit--;

        // instancier la pomme
        if (itemPrefab != null)
        {
            GameObject item = Instantiate(
                itemPrefab,
                transform.position,
                Quaternion.identity
            );
            // empêcher le pickup immédiat
            var col = item.GetComponent<Collectible>();
            if (col != null) col.canBeDestroyedOnContact = false;

            // animation va‐et‐vient
            yield return item.transform.MoveBackAndForth(
                item.transform.localPosition + Vector3.up * 1.5f
            );

            // enfin, “pickup” pour désactiver la pomme
            if (col != null) col.Picked();
        }

        // si plus de pommes, passer en mode désactivé
        if (numberHit <= 0)
            SetDisabled();
    }

    private void SetDisabled()
    {
        isDisabled = true;

        // changer le sprite en “cassé”
        if (disabledSprite != null)
            sr.sprite = disabledSprite;

        // désactiver uniquement le hitCollider pour ne plus détecter de coups
        hitCollider.enabled = false;

        // déclencher l’animation “Disabled” dans l’Animator
        animator.SetTrigger("Disabled");
    }
}
