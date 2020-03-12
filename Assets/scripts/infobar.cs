using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class infobar : MonoBehaviour
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

    public void showData(){
        var p = DataBank.playerDATA.Instance;
        diamand.text = p.diamands.ToString();
        coin.text = p.coins.ToString();
        star.text = p.stars.ToString();
        crown.text = p.crowns.ToString();
    }
}
