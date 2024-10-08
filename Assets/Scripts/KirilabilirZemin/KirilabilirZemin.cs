using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KirilabilirZemin : MonoBehaviour
{
    [SerializeField]
    float kzSayac = 2f;
    bool ustunde = false;
    float gerigelmesayac = 3;
    BoxCollider2D BoxCollider2D;
    SpriteRenderer spriteRenderer;
    bool aktifmi = true;

    Animator animator;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();        
    }
    private void Update()
    {
        gerigelmesayac -= Time.deltaTime;
      
        if (aktifmi == false && gerigelmesayac <0)
        {
            aktifmi = true;
            kzSayac = 2f;
            BoxCollider2D.enabled = true;
            spriteRenderer.enabled = true;
        }
        if (ustunde)
        {
            KirilabiliriKirFNC();
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            ustunde = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ustunde= false;
    }
    void KirilabiliriKirFNC()
    {
            kzSayac -= Time.deltaTime;
            if (kzSayac <= 0)
            {
                animator.SetTrigger("Kir");
                BoxCollider2D.enabled= false;
                
            }
            
    }
    void kirilabiliryokolsun()
    {
        BoxCollider2D.enabled = false;
        spriteRenderer.enabled = false;
        aktifmi = false;
        gerigelmesayac = 3;
       
    }
}
