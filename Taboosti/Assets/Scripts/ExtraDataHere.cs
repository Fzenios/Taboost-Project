using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraDataHere : MonoBehaviour
{
    public DataForSaving dataForSaving;
    public SaveManager saveManager;
    public Button AdsBtn, NSFWBtn;
    public Toggle SoundBtn;
    public GameObject SoundOn, SoundOff;

    private void Awake() 
    {
        dataForSaving.Sound = true;
        dataForSaving.Ads = true;
        dataForSaving.NSFW = false;

        saveManager.Load();     

        ButtonsCheck();

    }
    [System.Serializable]
    public class DataForSaving
    {
        public bool Sound;
        public bool Ads;
        public bool NSFW;

        public DataForSaving(ExtraDataHere extraDataHere)
        {
           // Sound = extraDataHere.Sound;
           // Ads = extraDataHere.Ads;
           // NSFW = extraDataHere.NSFW;
        }
    }

    public void ButtonsCheck()
    {
        if(dataForSaving.Sound)
            {
                SoundOn.SetActive(true);
                SoundOff.SetActive(false);
            }
        else
            {
                SoundOn.SetActive(false);
                SoundOff.SetActive(true);
            }
        if(dataForSaving.Ads)
            AdsBtn.interactable = true;
        else
            AdsBtn.interactable = false;
        if(dataForSaving.NSFW)
            NSFWBtn.interactable = false;
        else
            NSFWBtn.interactable = true;
    }
}
