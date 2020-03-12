using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itsInside : MonoBehaviour
{
    public static int eatedTiles = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D o)
    {
        // Debug.Log(o.gameObject.name + " itsInside");
        if(o.gameObject.tag == "tile"){
            o.GetComponent<tile>().itsInside = true;
            eatedTiles ++;
            // Debug.Log(eatedTiles);
        }
    }
}
