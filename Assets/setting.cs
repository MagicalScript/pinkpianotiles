using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void rateUs(){
        Application.OpenURL("market://details?id=" + Application.identifier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
