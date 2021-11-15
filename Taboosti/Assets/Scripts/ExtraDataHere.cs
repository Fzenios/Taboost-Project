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

    private void Start() 
    {
        dataForSaving.Sound = true;
        dataForSaving.Ads = true;
        dataForSaving.NSFW = true;

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
            SoundBtn.isOn = true;
        else
            SoundBtn.isOn = false;
        if(dataForSaving.Ads)
            AdsBtn.interactable = false;
        if(dataForSaving.NSFW)
            NSFWBtn.interactable = false;
    }
}
