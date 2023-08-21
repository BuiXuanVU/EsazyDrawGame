using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.Events;

public class AdmobAds : MonoBehaviour, AdProvide {
    //public AdsId admob;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start () {
        this.InitAds ();
    }

    public void InitAds () {
        MobileAds.Initialize (HandleInitCompleteAction);
        //this.InitBanner();
        this.ReloadInterstitial ();
        this.ReloadVideoReward ();
    }
    private void HandleInitCompleteAction (InitializationStatus initstatus) {
        // Callbacks from GoogleMobileAds are not guaranteed to be called on
        // main thread.
        // In this example we use MobileAdsEventExecutor to schedule these calls on
        // the next Update() loop.
        MobileAdsEventExecutor.ExecuteInUpdate (() => {
            // statusText.text = "Initialization complete";
            //RequestBanner ();
        });
    }
    #region BANNER
    private BannerView banner;
    private bool isBanner = false;
    public void InitBanner () {
        this.isBanner = false;

        if (this.banner != null) {
            this.banner.Destroy ();
        }
        AdSize adSize = new AdSize (this.bannerSizeToPixels (320), this.bannerSizeToPixels (50));
#if UNITY_ANDROID
        this.banner = new BannerView (AdsManager.Instance.BannerKeyAndroid, AdSize.Banner, AdPosition.Bottom);
#elif UNITY_IOS
        this.banner = new BannerView (AdsManager.Instance.BannerKeyiOS, AdSize.Banner, AdPosition.Top);
#endif
        if (this.banner != null) {
            this.Message ("banner inited");
        }

        this.banner.OnAdLoaded += BannerOnAdLoaded;
#if DEVICE_ID
        string deviceId = AdMobUtility.GetTestDeviceId ();
        AdRequest request = new AdRequest.Builder ().AddTestDevice (deviceId).Build ();
        this.Message ("request baner: " + deviceId);
        this.banner.LoadAd (request);
#else
        AdRequest request = new AdRequest.Builder ().Build ();
        this.banner.LoadAd (request);
#endif
    }
    private int bannerSizeToPixels (int size) {
        return size * Mathf.RoundToInt (Screen.dpi / 160);
    }

    public bool IsBanner () {
        if (this.banner != null) {
            return this.isBanner;
        }
        this.InitBanner ();
        return false;
    }

    public void RequestBanner () {
        if (this.banner != null) {
            if (!this.isBanner) {
                this.InitBanner ();
            }
        } else {
            this.InitBanner ();
        }
    }
    public void ShowBanner () {
        if (this.banner != null) {
            if (this.isBanner) {
                this.banner.Show ();
            } else {
                this.InitBanner ();
            }
        } else {
            this.InitBanner ();
        }

    }
    public void HideBanner () {
        if (this.banner != null) {
            this.banner.Hide ();
            this.banner.Destroy ();
        }
    }
    public void BannerOnAdLoaded (object sender, EventArgs args) {
        this.isBanner = true;
    }
    #endregion
    #region INTERSTITIAL
    private InterstitialAd interstitial;
    private void InitInterstitial () {

#if UNITY_ANDROID
        if (AdsManager.Instance.InterstitialAndroid == null) {
            this.Message ("Admob id NULL");
            return;
        }
#elif UNITY_IOS
        if (AdsManager.Instance.InterstitialiOS == null) {
            this.Message ("Admob id NULL");
            return;
        }
#endif
        if (this.interstitial != null) {
            this.interstitial.Destroy ();
        }
#if UNITY_ANDROID
        this.interstitial = new InterstitialAd (AdsManager.Instance.InterstitialAndroid);
#elif UNITY_IOS
        this.interstitial = new InterstitialAd (AdsManager.Instance.InterstitialiOS);
#endif

        if (this.interstitial != null) {
            this.Message ("interstitial inited");
        }

        this.interstitial.OnAdClosed += (delegate (System.Object sender, EventArgs args) {
            this.Message ("interstitial to close");
            //this.RequestInterstitial();
            this.ReloadInterstitial ();

        });
        this.interstitial.OnAdLoaded += (delegate (System.Object sender, EventArgs args) {
            this.Message ("interstitial Loaded");
        });
        this.interstitial.OnAdFailedToLoad += (delegate (System.Object sender, AdFailedToLoadEventArgs args) {
            this.Message ("interstitial fail to load: ");
        });

#if DEVICE_ID
        string deviceId = AdMobUtility.GetTestDeviceId ();
        AdRequest request = new AdRequest.Builder ().AddTestDevice (deviceId).Build ();
        this.Message ("request interstitial: " + deviceId);
        this.interstitial.LoadAd (request);
#else
        AdRequest request = new AdRequest.Builder ().Build ();
        this.interstitial.LoadAd (request);
#endif
    }
    public bool IsInterstitial () {
        if (this.interstitial.IsLoaded ()) {
            return true;
        }
        this.RequestInterstitial ();
        return false;
    }

    public void RequestInterstitial () {
        if (this.interstitial != null) {
            if (!this.interstitial.IsLoaded ()) {
                this.InitInterstitial ();
            }
        } else {
            this.InitInterstitial ();
        }
    }

    public UnityAction<bool> interCallback;
    public void ShowInterstitial (UnityAction<bool> callback = null) {
        if (this.interstitial != null) {
            if (this.interstitial.IsLoaded ()) {
                this.interCallback = callback;
                this.Message ("Show Interstitial");
                this.interstitial.Show ();

            } else {
                RequestInterstitial ();
            }
        } else {
            this.InitInterstitial ();
        }
    }

    private void ReloadInterstitial () {
        this.StartCoroutine (this.OnWaitingLoadInterstitail ());
    }
    private IEnumerator OnWaitingLoadInterstitail () {
        yield return new WaitForEndOfFrame ();
        yield return new WaitForSeconds (0.1f);
        this.RequestInterstitial ();
    }
    #endregion

    #region VIDEO REWARD

    private RewardedAd rewardVideo;
    private UnityAction<bool> videoCallback;

    private void InitVideoReward () {

        if (this.rewardVideo != null) {
            this.rewardVideo = null;
        }
#if UNITY_ANDROID
        this.rewardVideo = new RewardedAd (AdsManager.Instance.VideoRewardKeyAndroid);
#elif UNITY_IOS
        this.rewardVideo = new RewardedAd (AdsManager.Instance.VideoRewardKeyiOS);
#endif

        if (this.rewardVideo != null) {
            this.Message ("rewardVideo inited");
        }

        this.rewardVideo.OnAdLoaded += (delegate (System.Object sender, EventArgs args) {
            this.Message ("Reward video Loaded");
        });
        //     rewardVideo = new RewardedAd (this.GetAdsId ().rewardVideo);
        this.rewardVideo.OnAdFailedToLoad += (delegate (System.Object sender, AdFailedToLoadEventArgs args) {
            this.Message ("Reward video fail to load");

        });

        this.rewardVideo.OnAdClosed += (delegate (System.Object sender, EventArgs args) {
            this.Message ("Reward video closed. Shame");
            this.RewardVideo (false);
        });
        this.rewardVideo.OnUserEarnedReward += HandleUserEarnedReward;

        this.rewardVideo.OnAdClosed += HandleRewardedAdClosed;
        this.RequestVideoReward ();
    }
    public void HandleRewardedAdClosed (object sender, EventArgs args) {
        MonoBehaviour.print ("HandleRewardedAdClosed event received");
    }
    public void HandleUserEarnedReward (object sender, Reward args) {
        this.RewardVideo (true);
        string type = args.Type;
        double amount = args.Amount;

        MonoBehaviour.print (
            "HandleRewardedAdRewarded event received for " +
            amount.ToString () + " " + type);
    }
    public void RequestVideoReward () {
        if (this.rewardVideo != null) {
            if (!this.rewardVideo.IsLoaded ()) {
                this.Message ("Request video reward");
                // RequestVideoReward ();

#if DEVICE_ID
                string deviceId = AdMobUtility.GetTestDeviceId ();
                AdRequest request = new AdRequest.Builder ().AddTestDevice (deviceId).Build ();

                this.rewardVideo.LoadAd (request, this.GetAdsId ().rewardVideo);
#else
                AdRequest request = new AdRequest.Builder ().Build ();

                this.rewardVideo.LoadAd (request);
#endif

            }
        } else {
            this.InitVideoReward ();
        }
    }
    public bool IsVideoReward () {
        if (this.rewardVideo.IsLoaded ()) {
            return true;
        }
        this.RequestVideoReward ();
        return false;
    }

    public void ShowVideoReward (UnityAction<bool> callback = null) {
        if (this.rewardVideo != null) {
            if (this.rewardVideo.IsLoaded ()) {
                this.videoCallback = callback;
                this.Message ("Show Video Reward");
                this.rewardVideo.Show ();
            }
        } else {
            this.InitVideoReward ();
        }
    }
    private void RewardVideo (bool isReward) {
        this.StartCoroutine (this.OnWaitingReward (isReward));
    }
    private IEnumerator OnWaitingReward (bool isReward) {
        yield return new WaitForEndOfFrame ();
        yield return new WaitForSeconds (0.2f);
        if (this.videoCallback != null) {
            this.Message ("Reward Video: " + isReward);
            this.videoCallback.Invoke (isReward);
            this.videoCallback = null;


        }
        yield return new WaitForEndOfFrame ();
        this.RequestVideoReward ();
    }
    private void ReloadVideoReward () {
        this.InitVideoReward ();
    }
    #endregion

    public void Message (string message) {
        Debug.Log (string.Format ("ADMOB ADS: {0}", message));

    }
    public void Clear () {

    }

}