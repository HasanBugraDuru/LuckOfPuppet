using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DikenManager : MonoBehaviour
{
    KarakterController karaketController;

    private void Awake()
    {
        karaketController = Object.FindObjectOfType<KarakterController>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && karaketController.dikenresis == false)
        {
            karaketController.DikeneCarptiFNC();
        }
        
    }
}
