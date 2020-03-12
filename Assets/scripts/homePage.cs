using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class homePage : MonoBehaviour
{
    public infobar _infobar;
    public GameObject popupMsg;
    public GameObject diamand;
    public GameObject coin;
    public GameObject congtrats;
    public GameObject sorry;
    public Text number;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rewordedvideoAds()
    {

    }
    public void todaysGift()
    {
        var pd = DataBank.playerDATA.Instance;
        //todays gift not yet gut
        string d = PlayerPrefs.GetString("giftdate");
        DateTime dateDiff;
        DateTime.TryParse(d, out dateDiff);
        // Debug.Log(dateDiff);
        // Debug.Log("dateDiff " + (DateTime.Now - dateDiff).TotalDays);
        if ((DateTime.Now - dateDiff).TotalDays > .75 || !PlayerPrefs.HasKey("giftdate"))
        {

            int r = UnityEngine.Random.Range(0, 2);
            if (r < 1)
            {
                coin.SetActive(true);
                r = UnityEngine.Random.Range(0, 100);
                pd.coins += r;
            }
            else
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
            PlayerPrefs.SetString("giftdate", DateTime.Now.ToString());
        }
        else
        {
            popupMsg.SetActive(true);
            sorry.SetActive(true);
        }
    }
    public void OKbtn()
    {
        number.gameObject.SetActive(false);
        diamand.SetActive(false);
        coin.SetActive(false);
        congtrats.SetActive(false);
        sorry.SetActive(false);
        popupMsg.SetActive(false);
    }
}
