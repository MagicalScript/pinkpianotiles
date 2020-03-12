using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store : MonoBehaviour
{
    public infobar _infobar;
    public GameObject container;
    private DataBank.playerDATA pd;
    // Start is called before the first frame update
    void Start()
    {
        pd = DataBank.playerDATA.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buy5d(){
        pd.diamands += 5;
        pd.saveplayer();
        _infobar.showData();
        hideMe();
    }
    public void buy12d(){
        pd.diamands += 12;
        pd.saveplayer();
        _infobar.showData();
        hideMe();
    }
    public void buy20d(){
        pd.diamands += 20;
        pd.saveplayer();
        _infobar.showData();
        hideMe();
    }
    public void hideMe(){
        Debug.Log("hideMe");
        gameObject.SetActive(false);
    }
}
