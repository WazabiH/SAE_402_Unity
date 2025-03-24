using System.Collections;
using UnityEngine;

public class BlockIt : MonoBehaviour
{
    public Animator animator;
    public int numberHit = 1; // négatif = pas interactif
    private ContactPoint2D[] listContacts = new ContactPoint2D [1];

    public GameObject itemPrefab;
    public SpriteRenderer sr; 
    public PlatformEffector2D platformEffector2D; // Correction ici
    public bool isHidden = false;

    private void Awake()
    {
        sr.enabled = !isHidden;
        platformEffector2D.enabled = !isHidden; 
        animator.ResetTrigger("IsHit");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.GetContacts(listContacts);
        if (
            listContacts[0].normal.y > 0.5f &&
            collision.gameObject.CompareTag("Player") && 
            numberHit > 0
            )
        {
           StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        yield return null; 
        sr.enabled = true; 
        platformEffector2D.enabled=false;
        animator.SetTrigger("IsHit");
        numberHit--;
        if (itemPrefab != null) 
        {
            GameObject item = Instantiate(
                itemPrefab,
                transform.position,
                Quaternion.identity
            ); 
            item.GetComponent<Collectible>().canBeDestroyedOnContact = false; 
            Vector3 enPosition = (item.transform.localPosition + Vector3.up * 1.5f);
            yield return item.transform.MoveBackAndForth(enPosition);
            item.GetComponent<Collectible>().Picked(); 
        }
    }
}
