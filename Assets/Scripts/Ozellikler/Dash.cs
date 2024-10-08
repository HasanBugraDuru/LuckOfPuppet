using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash;
    public bool dashing;
    public float timeSincelastDash;
    public   int dashSayacý;
    public  float dashSpeed;
    public float dashsüresi;
    public float dashbitme;
    float defaultGravity;
    public float speed;

    Rigidbody2D rb;
    Animator animator;

    TrailRenderer trail;
   
    private void Awake()
    {
        dashbitme = 0.2f;
        animator = GetComponent<Animator>();
        dashSpeed = 50f;
        canDash = false;
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
        trail = GetComponent<TrailRenderer>();
    }
    public void DashFNC()
    {

        if (dashSayacý == 0 &&timeSincelastDash>0.5f&&canDash)
        {
            
            dashing = true;
            dashSayacý =+ 1;
           
        }
    }
   
    private void Update()
    {
         speed = rb.velocity.x;
        animator.SetBool("Dash", dashing);
        timeSincelastDash += Time.deltaTime;
        if (dashing)
        {
            dashsüresi += Time.deltaTime;
            trail.enabled = true;
        }
        else
        {
            trail.enabled = false;
        }

        if (UserInput.instance.controls.Dash.Dash.WasPressedThisFrame())
        {
            DashFNC();
        }
        if (dashsüresi > 0) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x*dashSpeed, 0);

        }
        if (dashsüresi > dashbitme)
        {
            dashsüresi = 0f;
            dashing = false;
            timeSincelastDash = 0f;
            rb.gravityScale = defaultGravity;
            dashSayacý = 0;
        }
    }


}
