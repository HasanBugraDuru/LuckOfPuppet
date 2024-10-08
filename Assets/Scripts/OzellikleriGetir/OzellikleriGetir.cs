using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzellikleriGetir : MonoBehaviour
{
    public GameObject[] Ozellikler;
    public bool[] getirilmis= {false, false , false , false , false , false };
    public GameObject konum1, konum2, konum3;


    private void Start()
    {
        GameObject ozelli1 = Instantiate(Ozellikler[rastgelegetir()],konum1.transform.position,Quaternion.identity);
        GameObject ozelli2 = Instantiate(Ozellikler[rastgelegetir()], konum2.transform.position,Quaternion.identity);
        GameObject ozelli3 = Instantiate(Ozellikler[rastgelegetir()], konum3.transform.position,Quaternion.identity);
    }

    private void Update()
    {
        
    }

    int rastgelegetir()
{
    int random = Random.Range(0, Ozellikler.Length);
    
    if (getirilmis[random] == false)
    {
        getirilmis[random] = true;
        return random;
    }
    else
    {
        // Rastgele yeniden çaðýrarak baþka bir deðeri deneyin
        return rastgelegetir();
    }
}
}
