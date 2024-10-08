using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KapaliKapi : MonoBehaviour
{
    [SerializeField]
    public string[] sahneadlari;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataTransfer.Instance.Oyunbittimi())
        {
            SceneManager.LoadScene("BitisAnimasyon");
        }
        else
        {
            int gidileceksahne = DataTransfer.Instance.UnplayedLevelGET();
            SceneManager.LoadScene(sahneadlari[gidileceksahne]);
        }
        
    }
}
