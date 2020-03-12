using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public SpriteRenderer sr;
    public SpriteRenderer longTileBegin;
    public SpriteRenderer longTileEnd;
    public SpriteRenderer longTileMidle;
    public SpriteRenderer longTileMidle2;
    public GameObject dragTile;
    public TrailRenderer tr;
    Vector3 theScale;
    int TileSize = 1;
    float SPEED = 6.5f;
    bool turnDragTile = false;
    // public float TILE_HIEGHT = 8.6f;
    public Color active;
    public Color passive;
    public Color assertive;
    private bool _cubeHited;
    public bool cubeHited
    {
        set
        {
            if (TileSize != 1)
            {
                // code drag tile
                if (!_cubeHited)
                    turnDragTile = true;
                dragTile.SetActive(true);

            }

            _cubeHited = value;
            sr.color = value == true ? passive : active;

        }
        get { return _cubeHited; }
    }
    public bool itsInside;
    // Start is called before the first frame update
    void Start()
    {
        cubeHited = false;
        itsInside = false;
    }
    // void update()
    // {
    //     if (turnDragTile)
    //     {
    //         if ()
    //     }
    // }

    bool cleared = false;
    void Update()
    {
        if (turnDragTile)
        {
            if(!cleared){
                tr.Clear();
                cleared = true;
                SPEED = DataBank.playerDATA.currentSong.speed;
            }

            // Debug.Log("transform " + dragTile.transform.localScale.ToString());
            dragTile.transform.position = new Vector3(dragTile.transform.position.x, dragTile.transform.position.y, dragTile.transform.position.z);
            if (dragTile.transform.position.y <= transform.position.y)
                dragTile.transform.position = new Vector3(dragTile.transform.position.x, dragTile.transform.position.y + SPEED * Time.deltaTime, dragTile.transform.position.z);

            if (Input.touchCount > 0)
            {
                // if (CheckForLongPress())
                // { //user is touching the screen with one or more fingers
                //   //do something
                //     Debug.Log("Hey Hey Hey Hey Hey Hey Hey !");
                //     // turnDragTile = false;
                // }
                // else
                // { //user is not currently touching the screen
                //   //do something else
                //     turnDragTile = false;
                // }//Input.GetMouseButtonDown(0)
                turnDragTile = true;
            }else{
                turnDragTile = false;
            }
            // if (Input.GetMouseButtonDown(0))
            // { //user is touching the screen with one or more fingers
            //   //do something
            //     Debug.Log("Hey Hey Hey Hey Hey Hey Hey !");
            // }
            // else if (Input.GetMouseButtonUp(0))
            // { //user is not currently touching the screen
            //   //do something else
            //     turnDragTile = false;
            // }//Input.GetMouseButtonDown(0)
        }
    }
    public void setLongTile(int size, float TILE_HIEGHT)
    {
        // Debug.Log("setLongTile");
        // Debug.Log(size);
        // Debug.Log(TILE_HIEGHT);
        // //set scale size code
        TileSize = size;
        float longtilehiegth = TILE_HIEGHT / size;
        // Debug.Log(longtilehiegth);

        longTileBegin.gameObject.SetActive(true);
        longTileEnd.gameObject.SetActive(true);

        theScale = longTileBegin.transform.localScale;
        theScale.x = theScale.x / size;
        longTileBegin.transform.localScale = theScale;

        theScale = longTileEnd.transform.localScale;
        theScale.x = theScale.x / size;
        longTileEnd.transform.localScale = theScale;

        // Transform goTr = dragTile.GetComponentInParent<Transform>();
        // theScale = goTr.localScale;
        // theScale.y = theScale.y / size;
        // goTr.localScale = theScale;

        theScale = dragTile.transform.localScale;
        theScale.y = theScale.y / size;
        dragTile.transform.localScale = theScale;

        // set positions , - (longtilehiegth  * size)
        // longTileEnd.transform.position = new Vector3(longTileEnd.transform.position.x, transform.position.y, longTileEnd.transform.position.z);
        longTileBegin.transform.position = new Vector3(longTileBegin.transform.position.x, transform.position.y - (TILE_HIEGHT * (size - 1)), longTileBegin.transform.position.z);
        dragTile.transform.position = new Vector3(dragTile.transform.position.x, transform.position.y - (TILE_HIEGHT * (size - 1)), dragTile.transform.position.z);
        if (size > 2)
        {
            longTileMidle.gameObject.SetActive(true);
            theScale = longTileMidle.transform.localScale;
            theScale.x = theScale.x / size;
            longTileMidle.transform.localScale = theScale;
            longTileMidle.transform.position = new Vector3(longTileMidle.transform.position.x, transform.position.y - (TILE_HIEGHT * (size - 2)), longTileMidle.transform.position.z);
        }
        else if (size > 3)
        {
            longTileMidle2.gameObject.SetActive(true);
            theScale = longTileMidle2.transform.localScale;
            theScale.x = theScale.x / size;
            longTileMidle2.transform.localScale = theScale;
            longTileMidle2.transform.position = new Vector3(longTileMidle2.transform.position.x, transform.position.y - (TILE_HIEGHT * (size - 3)), longTileMidle2.transform.position.z);
        }
    }
    public void resetTile()
    {
        cleared = false;
        TileSize = 1;
        dragTile.SetActive(false);
        turnDragTile = false;

        longTileEnd.gameObject.SetActive(false);
        longTileMidle.gameObject.SetActive(false);
        longTileMidle2.gameObject.SetActive(false);
        longTileBegin.gameObject.SetActive(false);


        theScale = longTileBegin.transform.localScale;
        theScale.x = 1;
        theScale.y = 1;

        longTileBegin.transform.localScale = theScale;
        longTileEnd.transform.localScale = theScale;
        longTileMidle.transform.localScale = theScale;
        longTileMidle2.transform.localScale = theScale;
        dragTile.transform.localScale = theScale;

        longTileBegin.transform.position = new Vector3(longTileBegin.transform.position.x, transform.position.y, longTileBegin.transform.position.z);
        longTileEnd.transform.position = new Vector3(longTileEnd.transform.position.x, transform.position.y, longTileEnd.transform.position.z);
        longTileMidle.transform.position = new Vector3(longTileMidle.transform.position.x, transform.position.y, longTileMidle.transform.position.z);
        longTileMidle2.transform.position = new Vector3(longTileMidle2.transform.position.x, transform.position.y, longTileMidle2.transform.position.z);
        dragTile.transform.position = new Vector3(dragTile.transform.position.x, transform.position.y, dragTile.transform.position.z);
    }

    public void dragTileAction()
    {
        dragTile.SetActive(true);
    }


    float _timePressed;
    float _timeLastPress;
    float WaitingSeconds;
    bool CheckForLongPress()
    {
        if (Input.touches[0].phase == TouchPhase.Began)
        { // If the user puts her finger on screen...
            _timePressed = Time.time - _timeLastPress;
        }

        if (Input.touches[0].phase == TouchPhase.Ended)
        { // If the user raises her finger from screen
            _timeLastPress = Time.time;
            if (_timePressed > WaitingSeconds / 2f)
            { // Is the time pressed greater than our time delay threshold?
                return true;
            }
        }
        return false;
    }

    public void setRedTile(){
        sr.color = sr.color != assertive ? assertive : Color.clear;
    }
}
