using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Arasahne : MonoBehaviour
{
    float beklemesursi = 6f;
    SpriteRenderer spriteRenderer;
    RawImage ri;
    Animator animator;
   
    private void Update()
    {
        
        beklemesursi -= Time.deltaTime;
        if(beklemesursi <=0)
        {
            SceneManager.LoadScene("LevelGiris");
        }
    }
}
