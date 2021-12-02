using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;


public class IAPScr : MonoBehaviour
{
    //string AdsRemove = "com.fzenios.taboost.adsremoval";
    string NSFW = "com.fzenios.taboost.buynsfw";
    public ExtraDataHere extradatahere;
    public SaveManager saveManager;
    public AdsScr adsScr;
    public Text text;
    public Product nsfw;

  
    public void OnPurchaseComplete(Product product)
    {
        /*if(product.definition.id == AdsRemove)
        {
            extradatahere.dataForSaving.Ads = false;
            extradatahere.ButtonsCheck();
            saveManager.Save();
            adsScr.BannerDestroy();
            Debug.Log("efigan oi diafimiseis");
        }*/
        if(product.definition.id == NSFW)
        {
            extradatahere.dataForSaving.NSFW = true;
            extradatahere.dataForSaving.Ads = false;
            //adsScr.BannerDestroy();
            extradatahere.ButtonsCheck();
            saveManager.Save();
            Debug.Log("agorastike to nsfw");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("den egine h agora toy " + product.definition.id + " epeidi " + reason);
        text.text = "den egine h agora toy " + product.definition.id + " epeidi " + reason;
    }
    //public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)


}
