using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip slashSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Fungsi yang akan dipanggil oleh animasi event
    public void PlaySlashSound()
    {
        audioSource.PlayOneShot(slashSound);
    }
}
