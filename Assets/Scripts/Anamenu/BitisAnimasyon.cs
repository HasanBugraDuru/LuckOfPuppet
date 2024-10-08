using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BitisAnimasyon : MonoBehaviour
{
    float beklemesursi = 6f;
    SpriteRenderer spriteRenderer;
    RawImage ri;
    Animator animator;
   
    private void Update()
    {

        beklemesursi -= Time.deltaTime;
        if (beklemesursi <= 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
