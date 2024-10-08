using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HizlandiranZemin : MonoBehaviour
{
    KarakterController karakterController;
    float yenihiz, sabithiz;

    private void Awake()
    {
        karakterController = Object.FindObjectOfType<KarakterController>();
        sabithiz = karakterController.Harekethiz;
        yenihiz = karakterController.Harekethiz * 2;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            karakterController.Harekethiz = yenihiz;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        karakterController.Harekethiz = sabithiz;
    }
}
