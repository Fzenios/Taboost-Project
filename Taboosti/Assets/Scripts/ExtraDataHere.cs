using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDataHere : MonoBehaviour
{
    public DataForSaving dataForSaving;
    public SaveManager saveManager;  
    public bool Sound = true;
    public bool Ads = true;
    public bool NSFW = true;
    private void Start() 
    {
        Sound = saveManager.data.Sound;        
    }
}
