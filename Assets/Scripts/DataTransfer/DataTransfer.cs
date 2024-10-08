using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTransfer : MonoBehaviour
{
    [SerializeField] bool[] AlinanOzellikler;
    [SerializeField] bool[]    GecilenSeviye;
    [SerializeField] int SeviyeNo = 7;

    public static DataTransfer Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(Instance !=this)
        {
            Destroy(this.gameObject);
        }
    }

    public bool SeviyeGet(int index)
    {
        return GecilenSeviye[index];
    }
    
    public bool Oyunbittimi()
    {
        int sayac=0;
        for (int i = 0;i<GecilenSeviye.Length;i++) 
        {
            if (GecilenSeviye[i]==true) 
            {
                sayac++; 
            }
        }
        if(sayac == SeviyeNo)
        {
            return true;
        }else 
        { 
            return false;
        }
    }
    public void OzellikleriSifirla()
    {
        for (int i = 0;i<AlinanOzellikler.Length;i++)
        {
            AlinanOzellikler[i]= false;
        }
    }

    public int UnplayedLevelGET()
    {
        int seviyeindex = Random.Range(0, SeviyeNo);
        while (GecilenSeviye[seviyeindex] == true)
        {
            seviyeindex = Random.Range(0, SeviyeNo);
        }
        return seviyeindex;
    }
    public void PlayedLevelSET(int level)
    {
        GecilenSeviye[level] = true;
    }
    public bool Ozellikyok()
    {
        int sayac = 0;
        for (int i = 0; i < AlinanOzellikler.Length; i++)
        {
            if (AlinanOzellikler[i] == false)
            {
                sayac++;
            }
        }
        if (sayac == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int SkillGet()
    {
        
        int skillindex = Random.Range(0, 6);
        while (AlinanOzellikler[skillindex] == false)
        {
            if (Ozellikyok())
            {
                return 6;
            }
            skillindex = Random.Range(0, 6);
        }
        return skillindex;
    }
    public void SkillSet(int skill)
    {
        AlinanOzellikler[skill] = true;
    }
    
}
