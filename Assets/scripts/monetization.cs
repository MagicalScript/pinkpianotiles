using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monetization : MonoBehaviour
{
    public static monetization instance;
    public infobar _infobar;
    public GameObject popupMsg;
    public GameObject diamand;
    public GameObject coin;
    public GameObject congtrats;
    public GameObject sorry;
    public Text number;
    // Start is called before the first frame update
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void showInterstitial()
    {
        if (Enhance.IsInterstitialReady())
        {
            // The ad is ready, show it
            Enhance.ShowInterstitialAd();
        }
    }
    public void showBanner()
    {
        if (Enhance.IsBannerAdReady())
        {
            // The ad is ready, show it
            Enhance.ShowBannerAdWithPosition(Enhance.Position.TOP);
        }
    }
    public void showRewarded()
    {
        if (Enhance.IsRewardedAdReady())
        {
            // The ad is ready, show it
            Enhance.ShowRewardedAd(OnRewardGranted, OnRewardDeclined, OnRewardUnavailable);
        }
    }

    private void OnRewardGranted(Enhance.RewardType rewardType, int rewardValue)
    {
        var pd = DataBank.playerDATA.Instance;
        int r = 0;
        if (rewardType == Enhance.RewardType.COINS)
        {
            coin.SetActive(true);
            r = rewardValue;
            pd.coins += rewardValue;
        }
        else if (rewardType == Enhance.RewardType.ITEM)
        {
            diamand.SetActive(true);
            r = UnityEngine.Random.Range(1, 2);
            pd.diamands += r;
        }


        popupMsg.SetActive(true);
        number.text = r.ToString() + " x";
        number.gameObject.SetActive(true);
        congtrats.SetActive(true);

        pd.saveplayer();
        _infobar.showData();
        PlayerPrefs.SetString("giftdate2", DateTime.Now.ToString());
    }

    private void OnRewardDeclined()
    {
        popupMsg.SetActive(true);
        sorry.SetActive(true);
    }

    private void OnRewardUnavailable()
    {
        popupMsg.SetActive(true);
        sorry.SetActive(true);
    }
}
