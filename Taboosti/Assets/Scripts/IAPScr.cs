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
    
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == AdsRemove)
        {
            extradatahere.dataForSaving.Ads = false;
            saveManager.Save();
            Debug.Log(extradatahere.dataForSaving.Ads);
            Debug.Log("efigan oi diafimiseis");
        }
        if(product.definition.id == NSFW)
        {
            extradatahere.dataForSaving.NSFW = false;
            saveManager.Save();
            Debug.Log(extradatahere.dataForSaving.NSFW);
            Debug.Log("agorastike to nsfw");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("den egine h agora toy " + product.definition.id + " epeidi " + reason);
    }

}
