using System.Collections;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float damage = 10f;
    public float invincibilityDuration = 2f; // Durasi i-frame
    private bool isInvincible = false; // Apakah objek sedang dalam kondisi i-frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kunti") && !isInvincible)
        {
            collision.SendMessage("TakeDamage", damage);
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}
