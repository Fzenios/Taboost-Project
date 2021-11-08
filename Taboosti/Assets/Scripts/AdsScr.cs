using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdsScr : MonoBehaviour
{
    public Text text;
    string App_ID = "ca-app-pub-3970092684747698~1257890209";

    string BannerID = "ca-app-pub-3970092684747698/1508143978";
    string InterstitialID = "ca-app-pub-3970092684747698/7961354767";
    private BannerView bannerView;
    private InterstitialAd interstitial;

    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(InitializationStatus => { });

    }
    public void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(BannerID, AdSize.SmartBanner, AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
    }

    public void ShowBanner()
    {
         // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);

    }

        public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        text.text = " egine to load ";
        //MonoBehaviour.print("HandleAdLoaded event received");
        
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        text.text = " failed ";
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }



    



}

