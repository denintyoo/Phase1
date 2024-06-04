using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination; // Menyimpan lokasi tujuan teleportasi
    public float delayTime = 1f; // Waktu penundaan dalam detik

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Memastikan hanya pemain yang dapat teleport
        {
            TeleportPlayer(other.gameObject); // Memanggil fungsi untuk teleportasi pemain
        }
    }

    void TeleportPlayer(GameObject player)
    {
        player.transform.position = destination.position; // Memindahkan pemain ke lokasi tujuan teleportasi
        player.GetComponent<PlayerMovement>().canMove = false; // Menonaktifkan skrip pergerakan pemain
        Invoke("EnablePlayerMovement", delayTime); // Memanggil fungsi untuk mengaktifkan kembali pergerakan pemain setelah penundaan
    }

    void EnablePlayerMovement()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().canMove = true; // Mengaktifkan kembali skrip pergerakan pemain setelah penundaan
    }
}
