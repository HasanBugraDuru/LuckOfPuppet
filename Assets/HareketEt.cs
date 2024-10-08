using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketEt : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    public float moveSpeed;
    [SerializeField] bool startMoving;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        startMoving = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
           transform.position= Vector2.MoveTowards(transform.position, pointB.transform.position, moveSpeed);
        }
    }
}
