using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//ONEAPP NOTE
//File này để gọi các lệnh kiểm tra ads, lệnh request ads và lệnh show banner, trung gian, video từ AdmodADS

public class AdsManager : MonoSingleton<AdsManager> {
    public List<AdProvide> adProvides;
#if UNITY_ANDROID
    public string BannerKeyAndroid;
    public string InterstitialAndroid;
    public string VideoRewardKeyAndroid;
#elif UNITY_IOS
    public string BannerKeyiOS;
    public string InterstitialiOS;
    public string VideoRewardKeyiOS;
#endif
    private bool isInitAds = false;
    public override void Init () {
        base.Init ();
        this.adProvides = new List<AdProvide> ();
#if FIREBASE
        //   FireBaseManager.Instance.AddCallbackFetchData (this.OnCallbackFetchData);
#endif

    }
    private void OnDisable () {
#if FIREBASE
        //        FireBaseManager.Instance.RemoveCallbackFeathData (this.OnCallbackFetchData);
#endif
    }
    protected override void Awake()
    {
        DontDestroyOnLoad (this);
    }
    private void Start () {
        //UserProfile.Instance.AddCallbackNetwork(this.OnChangeNetwork);
        if (!this.isInitAds) {
            this.StartCoroutine (this.InitAds ());
        }
    }
   
    private bool isAdsInit = false;
    private IEnumerator InitAds () {
        if (this.isAdsInit) {
            yield break;
        }

        AdmobAds admobAds = new GameObject ().AddComponent<AdmobAds> ();
        if (admobAds != null) {
            admobAds.transform.SetParent (this.transform);
            admobAds.name = "Admob Ads";
            //admobAds.InitAds();
            this.adProvides.Add (admobAds);
        }

        this.isAdsInit = true;
    }

    private void IsCheckAds () {
        if (this.adProvides == null) {
            this.adProvides = new List<AdProvide> ();
        }
        if (this.adProvides.Count <= 0) {
            this.InitAds ();
        }
    }
    public bool IsBanner () {
        foreach (AdProvide ads in this.adProvides) {
            if (ads.IsBanner ()) {
                return true;
            }
        }
        return false;
    }

    public void ShowBanner () {
        this.IsCheckAds ();
     
        foreach (AdProvide ads in this.adProvides) {
            if (ads is AdmobAds) {
                ((AdmobAds) ads).InitBanner ();
                return;
            }
        }
    }
    public void HideBanner () {
        foreach (AdProvide ads in this.adProvides) {
            if (ads is AdmobAds) {
                ((AdmobAds) ads).HideBanner ();
                return;
            }
        }
    }

    public AdProvide IsInterstitial () {

        foreach (AdProvide ads in this.adProvides) {
            if (ads.IsInterstitial ()) {
                return ads;
            }
        }
        return null;
    }
    public void ShowInterstitial (UnityAction<bool> callback = null) {
        //   SoundManager.Instance.TurnOffAllSoundTrack ();
        this.IsCheckAds ();
        AdProvide ad = this.IsInterstitial ();
        if (ad != null) {
            ad.ShowInterstitial ();
            return;
        } else {
            //this.StartCoroutine(this.RequestInterstitial());
        }
    }
    public bool IsShowAds () {
        // LevelData lv = LevelDatas.Instance.GetLevelData (5, 6);
        // if (lv != null) {
        //     int lvCurrent = LevelDatas.Instance.Level;
        //     if (lvCurrent % 3 == 0) {
        //         return true;
        //     }
        // }
        return false;
    }

    private IEnumerator RequestInterstitial () {
        //  LoadingManager.Instance.ShowLoading (true);
        yield return new WaitForEndOfFrame ();
        foreach (AdProvide ad in this.adProvides) {
            ad.RequestInterstitial ();
        }
        yield return new WaitForSeconds (2.0f);
        // LoadingManager.Instance.ShowLoading (false);
        AdProvide inter = this.IsVideoReward ();
        if (inter != null) {
            inter.ShowInterstitial ();
        } else {
            //   MessageBox.Instance.ShowMessageBox ("Error!", "No Ads Avalible!");
        }
    }

    public bool IsReward () {
        return this.IsVideoReward () != null;
    }

    private AdProvide IsVideoReward () {
        foreach (AdProvide ads in this.adProvides) {
            if (ads.IsVideoReward ()) {
                return ads;
            }
        }
        return null;
    }
    public void ShowVideoReward (UnityAction<bool> callback = null) {
        Debug.LogError ("Showvideo");
        this.IsCheckAds ();
#if UNITY_EDITOR
        if (callback != null) {
            callback.Invoke (true);
        }
        return;
#endif
        AdProvide ad = this.IsVideoReward ();
        if (ad == null) //khong co ads, request
        {
            this.StartCoroutine (this.RequestVideoAds (callback));

        } else {
            ad.ShowVideoReward (callback);
        }
    }

    private IEnumerator RequestVideoAds (UnityAction<bool> callback = null) {
        //   LoadingManager.Instance.ShowLoading (true);
        yield return new WaitForEndOfFrame ();
        foreach (AdProvide ad in this.adProvides) {
            ad.RequestVideoReward ();
        }
        yield return new WaitForSeconds (2.0f);
        // LoadingManager.Instance.ShowLoading (false);
        AdProvide reward = this.IsVideoReward ();
        if (reward != null) {
            reward.ShowVideoReward (callback);
        } else {
            //  MessageBox.Instance.ShowMessageBox ("Error!", "No Ads Avalible!");
        }
    }
}