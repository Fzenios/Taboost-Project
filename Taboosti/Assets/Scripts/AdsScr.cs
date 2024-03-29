using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdsScr : MonoBehaviour
{
    string bannerID;
    string interstitialAd;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    public ExtraDataHere extradatahere;

    void Start()
    {
        if(extradatahere.dataForSaving.Ads)
        {
            bannerID = "ca-app-pub-3970092684747698/1508143978";
            interstitialAd = "ca-app-pub-3970092684747698/7961354767";
            MobileAds.Initialize(initStatus => { });
            
            this.RequestBanner();
            RequestInterstitial();
            //LoadInterstitial();
        }
        
    }
    void RequestBanner()
    {
        bannerView = new BannerView(bannerID, AdSize.Banner , AdPosition.Bottom);
        
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
     
        ShowBanner();
    }
    public void ShowBanner()
    {
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        if(!extradatahere.dataForSaving.Ads)
            bannerView.Destroy();
    }
    void RequestInterstitial()
    {
        interstitial = new InterstitialAd(interstitialAd);
        this.interstitial.OnAdLoaded += this.HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleOnAdOpened;
        this.interstitial.OnAdClosed += this.HandleOnAdClosed;
        
        //LoadInterstitial();
    }
    public void LoadInterstitial()
    {
        if(extradatahere.dataForSaving.Ads)
        {
            AdRequest request = new AdRequest.Builder().Build();

            this.interstitial.LoadAd(request);
            //ShowInterstitial();
        }
    }
    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded()) 
        {
            this.interstitial.Show();
        }
    }   
    public void BannerDestroy()
    {    
        bannerView.Destroy();
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
       // MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLeavingApplication event received");
    }



    



}

