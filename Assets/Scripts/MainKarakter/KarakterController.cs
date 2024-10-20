using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Burst.Intrinsics.X86.Avx;

public class KarakterController : MonoBehaviour
{
    [SerializeField]
    public float ZiplamaGucu = 10f;
    [SerializeField]
    public float Harekethiz = 10f;
    [SerializeField]
    float YercekimiKatsayi = 8f;
    [SerializeField] float yavaslamaKatsayi;
    Animator anim;
    public SpriteRenderer eharfisp;

    [SerializeField]
    AudioSource walk,jump,die,ozellik,win,die_lazer;
    PowerUp pu;

    Rigidbody2D rb;
    Vector2 ilkKonum;
    BoxCollider2D collider2d;
    [SerializeField]
    SpriteRenderer sp;
    Dash dash;
    private float moveInput;

    float direction;
    public bool doubleJumpOn;
    public bool dikenresis;
    bool yerdemi;
    public Transform zeminkontrolnoktasý;
    public LayerMask zeminLayer;
    bool ikikezzýplayabilirmi;
    private void Awake()
    {
        UserInput.instance.moveInput.x = 0;
        pu = GetComponent<PowerUp>();
        anim = GetComponent<Animator>();
        collider2d = GetComponent<BoxCollider2D>();
        ilkKonum = transform.position;
        rb = GetComponent<Rigidbody2D>();
        yavaslamaKatsayi = Harekethiz *6/ 10;
        dash = GetComponent<Dash>();
        transform.position = new Vector2(-6f, -2f);
        pu.PowerUP1();
        DikeneCarptiFNC();
    }
    void Update()
    {
        pu.PowerUP1();
        if (dash.dashing==false)
        {
            HareketEttirFNC();
        }
        ZiplaFNC();
        YondegistirFNC();
        asagidustu();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ozellik")) 
        {
            eharfisp.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ozellik"))
        {
            eharfisp.enabled = false;
        }
    }

    public void KucultFNC()
    {

        sp.drawMode = SpriteDrawMode.Sliced;
        zeminkontrolnoktasý.position = new Vector2(transform.position.x,transform.position.y -0.30f); 
        sp.size /= 2;
        collider2d.size = sp.size;
        sp.drawMode = SpriteDrawMode.Simple;
       
    }
    public void GravityArttýrFNC()
    {
        
        
        rb.gravityScale = YercekimiKatsayi;
        Harekethiz = yavaslamaKatsayi;
        dikenresis = true;
        gameObject.layer = 10;
        
    }
    public void DikeneCarptiFNC()
    {
        rb.velocity = Vector2.zero;
        die.Play();
        anim.SetTrigger("Die");
        transform.position = ilkKonum;
        rb.velocity = Vector2.zero;
    }

    public void HareketEttirFNC()
    {
        moveInput = UserInput.instance.moveInput.x;
        rb.velocity = new Vector2(moveInput * Harekethiz, rb.velocity.y);
        anim.SetFloat("hiz", Mathf.Abs(rb.velocity.x));
        if (rb.velocity.x < 0 || rb.velocity.x > 0 && yerdemi)
        {
            if (walk.isPlaying == false)
            { walk.Play(); }
        }
        else
        {
            walk.Pause();
        }
    }

    public void ZiplaFNC()
    {
            yerdemi = Physics2D.OverlapCircle(zeminkontrolnoktasý.position, .2f, zeminLayer);
            if (yerdemi)
            {
                ikikezzýplayabilirmi = true;
                anim.SetBool("yerdemi", true);
              }
             else { anim.SetBool("yerdemi",false); }

            if (UserInput.instance.controls.Jump.Jump.WasPressedThisFrame())
            {
                if (yerdemi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ZiplamaGucu);
                    jump.Play();
           
                }
                else
                {
                    if (ikikezzýplayabilirmi&&doubleJumpOn)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, ZiplamaGucu);
                        jump.Play();
                        ikikezzýplayabilirmi = false;
                    }
                }

            }
        anim.SetFloat("hiz_y", rb.velocity.y);

    }
    void YondegistirFNC()
    {
        Vector2 geciciScale = transform.localScale;
        if (rb.velocity.x > 0)
        {
            geciciScale.x = 1f;
        }
        else if (rb.velocity.x < 0)
        {
            geciciScale.x = -1f;
        }
        transform.localScale = geciciScale;
    }
    void asagidustu()
    {
        if (transform.position.y < -50)
        {
            DikeneCarptiFNC();
        }
    }
}

