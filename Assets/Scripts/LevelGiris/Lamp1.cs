using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp1 : MonoBehaviour
{
    DataTransfer dataTransfer;
    SpriteRenderer sp;
    [SerializeField]
    Sprite aciklamba;
    bool flag;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        yapilicaklarFNC();
    }
    void yapilicaklarFNC()
    {
        if (gameObject.name == "lamp1" && DataTransfer.Instance.SeviyeGet(0))
        {
            sp.sprite = aciklamba;
        }
        if (gameObject.name == "lamp2" && DataTransfer.Instance.SeviyeGet(1))
        {
            sp.sprite = aciklamba;
        }
        if (gameObject.name == "lamp3" && DataTransfer.Instance.SeviyeGet(2))
        {
            sp.sprite = aciklamba;
        }
        if (gameObject.name == "lamp4" && DataTransfer.Instance.SeviyeGet(3))
        {
            sp.sprite = aciklamba;
        }
        if (gameObject.name == "lamp5" && DataTransfer.Instance.SeviyeGet(4))
        {
            sp.sprite = aciklamba;
        }
        if (gameObject.name == "lamp5" && DataTransfer.Instance.SeviyeGet(5))
        {
            sp.sprite = aciklamba;
        }
        if (gameObject.name == "lamp5" && DataTransfer.Instance.SeviyeGet(6))
        {
            sp.sprite = aciklamba;
        }
        if (gameObject.name == "oluadam" && DataTransfer.Instance.SeviyeGet(4))
        {
            sp.enabled = true;
        }
        if (gameObject.name == "panel" && DataTransfer.Instance.SeviyeGet(1))
        {
            sp.enabled = true;
        }

    }
}
