using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcikKapi : MonoBehaviour
{
     public AudioSource kazanmasesi;
    public string sahneAdi;
    private void Awake()
    {
         sahneAdi = SceneManager.GetActiveScene().name;
        kazanmasesi = GetComponent<AudioSource>();
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            kazanmasesi.Play();
            Invoke("gonder", 1f);
        }
    }
    void gonder()
    {
        UserInput.instance.moveInput.x = 0;
     if (DataTransfer.Instance.Oyunbittimi())
        {
            SceneManager.LoadScene("BitisAnimasyon");
        }
        else
        {
            if(sahneAdi == "Level1")
            {
                DataTransfer.Instance.PlayedLevelSET(0);
            }else if(sahneAdi == "Level3")
            {
                DataTransfer.Instance.PlayedLevelSET(1);
            }
            else if (sahneAdi == "Level4")
            {
                DataTransfer.Instance.PlayedLevelSET(2);
            }
            else if (sahneAdi == "Level6_dst")
            {
                DataTransfer.Instance.PlayedLevelSET(3);
            }
            else if (sahneAdi == "tunnel")
            {
                DataTransfer.Instance.PlayedLevelSET(4);
            }
            else if (sahneAdi == "Level5")
            {
                DataTransfer.Instance.PlayedLevelSET(5);
            }
            else if (sahneAdi == "Level6")
            {
                DataTransfer.Instance.PlayedLevelSET(6);
            }

            DataTransfer.Instance.OzellikleriSifirla();
            SceneManager.LoadScene("LevelGiris");
        }
    }
}
