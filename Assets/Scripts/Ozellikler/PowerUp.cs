using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    KarakterController karakter;
    Dash dash;

    public bool SuperJump;
    public bool SuperSpeed;
    public bool GravityArttýr;
    public float jumpx2;
    public bool GetSmall;
    public bool getDash;
    public bool doubleJump;
    float küçülmesayýsý;
    float newSpeed;
    int ozellik = 6;

    private void Awake()
    {
        SuperJump = false;
        karakter = GetComponent<KarakterController>();
        dash = GetComponent<Dash>();
        jumpx2 = karakter.ZiplamaGucu * 2;
         newSpeed = karakter.Harekethiz * 2.5f;
         ozellik = DataTransfer.Instance.SkillGet();
    }
    private void Update()
    {
        PowerUP1();
    }
    
    public void PowerUP1()
    {
        if (ozellik == 5||SuperJump)
        {
            karakter.ZiplamaGucu = jumpx2;

        }
        if (ozellik == 2 ||GravityArttýr)
        {
            karakter.GravityArttýrFNC();
        }

        if (ozellik == 4 ||GetSmall)
        {
            if (küçülmesayýsý == 0)
            {
                karakter.KucultFNC();
                GetSmall = false;
                küçülmesayýsý += 1;
            }
        }

        if (ozellik == 3 ||SuperSpeed)
        {
            karakter.Harekethiz = newSpeed;

        }

        if (ozellik == 0 ||getDash)
        {
            dash.canDash = true;
        }

        if (ozellik == 1 ||doubleJump)
        {
            karakter.doubleJumpOn = true;
        }
    }


}
