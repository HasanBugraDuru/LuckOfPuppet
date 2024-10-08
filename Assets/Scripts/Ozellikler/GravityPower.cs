using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPower : MonoBehaviour
{
    PowerUp power;
    public float zamanlayýcý;
    float gerekenZaman;
    private void Awake()
    {
        gerekenZaman = 2f;
        zamanlayýcý = 0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            power = collision.GetComponent<PowerUp>();
        }
    }
    private void Update()
    {
        if (DataTransfer.Instance.Ozellikyok() == false)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (UserInput.instance.controls.Ability.Ability.WasPressedThisFrame())
        {
            DataTransfer.Instance.SkillSet(2);
            power.GravityArttýr = true;
            Debug.Log("Yerçekimi");
        }

    }
}
