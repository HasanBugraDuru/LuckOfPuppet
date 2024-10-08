using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Büyütme : MonoBehaviour
{
    PowerUp power;
    public float zamanlayıcı;
    float gerekenZaman;
    private void Awake()
    {
        gerekenZaman = 2f;
        zamanlayıcı = 0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            power = collision.GetComponent<PowerUp>();
        }
    }
   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (UserInput.instance.controls.Ability.Ability.WasPressedThisFrame())
        {
            
            Debug.Log("Küçültme");
        }

    }
}
