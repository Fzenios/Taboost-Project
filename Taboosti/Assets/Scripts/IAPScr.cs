using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPScr : MonoBehaviour
{
    string AdsRemove = "com.Fzenios.Taboost.AdsRemoval";
    string NSFW = "com.Fzenios.Taboost.BuyNSFW";
    public AllDataHere AllDataHere;
    public ExtraDataHere extradatahere;
    public SaveManager saveManager;
    public AdsScr adsScr;
    
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == AdsRemove)
        {
            extradatahere.dataForSaving.Ads = false;
            extradatahere.ButtonsCheck();
            saveManager.Save();
            adsScr.BannerDestroy();
            Debug.Log("efigan oi diafimiseis");
        }
        if(product.definition.id == NSFW)
        {
            extradatahere.dataForSaving.NSFW = true;
            extradatahere.ButtonsCheck();
            saveManager.Save();
            Debug.Log("agorastike to nsfw");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("den egine h agora toy " + product.definition.id + " epeidi " + reason);
    }

}
