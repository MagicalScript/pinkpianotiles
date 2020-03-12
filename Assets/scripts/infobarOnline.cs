using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class infobarOnline : MonoBehaviour
{
    public Text diamand;
    public Text coin;
    public Text star;
    public Text crown;
    // Start is called before the first frame update
    void Start()
    {
        showData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showData()
    {
        var dp = DataBank.playerDATA.Instance;

        diamand.text = UnityEngine.Random.Range(dp.diamands > 20 ? dp.diamands - 20 : 0, dp.diamands + 20).ToString();
        coin.text = UnityEngine.Random.Range(dp.coins > 200 ? dp.coins - 200 : 0, dp.coins + 200).ToString();
        star.text = UnityEngine.Random.Range(dp.stars > 50 ? dp.stars - 50 : 0, dp.stars + 50).ToString();
        crown.text = UnityEngine.Random.Range(dp.crowns > 50 ? dp.crowns - 10 : 0, dp.crowns + 10).ToString();
    }
}
