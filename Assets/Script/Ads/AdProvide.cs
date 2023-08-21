using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AdsId {
    public AdsConfig admob;

}
//ONEAPP NOTE
//File này dùng để chưa các key ads và được tái sử dụng tùy theo mục đích: key local hoặc firebase sign

[System.Serializable]
public class AdsConfig {
    public string appid = "YOUR_APP_ID";
    public string banner = "YOUR_PLACEMENT_ID";
    public string instertitial = "YOUR_PLACEMENT_ID";
    public string rewardVideo = "YOUR_PLACEMENT_ID";

    public AdsConfig () { }
    public AdsConfig (string appid, string bannerid, string intersitialid, string rewardid) {
        this.appid = appid;
        this.banner = bannerid;
        this.instertitial = intersitialid;
        this.rewardVideo = rewardid;
    }
}

public interface AdProvide {
    void InitAds ();
    bool IsBanner ();
    void ShowBanner ();
    void RequestBanner ();

    void RequestInterstitial ();
    bool IsInterstitial ();
    void ShowInterstitial (UnityAction<bool> callback = null);

    void RequestVideoReward ();
    bool IsVideoReward ();
    void ShowVideoReward (UnityAction<bool> callback = null);

    void Message (string message);
    void Clear ();
}