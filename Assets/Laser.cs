using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float defaultdistanceRay = 100f;
    public Transform firepoint;
    public LineRenderer lineRenderer;
    KarakterController karakterController;

    public float LaseronTimer;
    public float LaserOffTimer;
    public float laserOffReq;
    public float laserOnReq;

    public bool laserOn;
    public bool laserOff;
    public bool laserTurnOn;
    public bool laserTurnOff;


    private void Awake()
    {
        LaserOffTimer = 0f ;
        LaseronTimer = 0f;
        laserTurnOff = true;
        laserTurnOn=false;
    }
    private void Update()
    {

        if (LaseronTimer < laserOnReq && laserTurnOn == true)
        {
            laserOn = true;
            LaserOffTimer = 0f;
            LaseronTimer += Time.deltaTime;
            laserOff = false;
        }
        if (LaseronTimer >= laserOnReq&&laserTurnOn==true)
        {
            laserTurnOff = true;
            LaseronTimer = 0;
            laserTurnOn = false;
        }

        if (LaserOffTimer < laserOffReq && laserTurnOff == true)
        {
            laserOff = true;
            LaseronTimer = 0;
            LaserOffTimer += Time.deltaTime;
            laserOn = false;

        }if (LaserOffTimer >= laserOffReq && laserTurnOff == true)
        {
            laserTurnOn = true;
            LaserOffTimer = 0f;
            laserTurnOff = false;

        }
        if (laserTurnOn)
        {
            shootLaser();
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }


      

    }
    public void shootLaser()
    {
        if (Physics2D.Raycast(transform.position, transform.right))
        {
            RaycastHit2D hit2D = Physics2D.Raycast(firepoint.position, transform.right);
            draw2Dray(firepoint.position, hit2D.point);

            if (hit2D.collider.CompareTag("Player"))
            {
                karakterController = hit2D.collider.GetComponent<KarakterController>();
                karakterController.DikeneCarptiFNC();
            }
        }
        else
        {
            draw2Dray(firepoint.position, firepoint.right * defaultdistanceRay);
        }
       ;
    }



    void draw2Dray(Vector2 startpos,  Vector2 endpos)
    {
        lineRenderer.SetPosition(0, startpos);
        lineRenderer.SetPosition(1, endpos);
    }
    
}
