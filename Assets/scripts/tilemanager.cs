using UnityEngine;

public class tilemanager : MonoBehaviour
{
    public bool ItsInside = false;
    public float TILE_WIDTH;
    public float TILE_HEIGHT;
    public float TILE_BORDER;
    public float LONG_TILE_AVG = 3;
    float last_pos = 0;
    int tiles_left = 4;
    int tiles_passed = 0;
    int _tiles_passed = 0;
    int long_tile = 1;
    int index = 0;
    Vector3 theScale;
    int rm;
    int rmHeight;
    float _pos;

    public GameObject[] Tile;
    void Start()
    {
        generateTiles();
    }
    public void generateTiles()
    {
        SetActiveToDefault();
        TILE_BORDER = 3 * TILE_WIDTH;
        foreach (var item in Tile)
        {
            last_pos = setTile(item);
        }
    }
    void Update()
    {

    }

    float setTile(GameObject tile)
    {
        if (_tiles_passed > 1)
        {
            tile.SetActive(false);
            _tiles_passed--;
            tiles_left--;
            return last_pos;
        }else if(_tiles_passed == 1){
            tile.GetComponent<tile>().resetTile();
            tile.transform.position = new Vector2(_pos, tile.transform.position.y);
            theScale = tile.transform.localScale;
            theScale.x = long_tile;
            tile.transform.localScale = theScale;
            tile.GetComponent<tile>().setLongTile(long_tile,TILE_HEIGHT);
            tiles_passed = 0;
            _tiles_passed = 0;
            // Debug.Log(tiles_passed);
            return last_pos;
        }
        long_tile = 1;
        do
        {
            do
            {
                if (index == 0)
                {
                    rm = Random.Range(1, 6);
                }
                else
                    rm = Random.Range(0, 3);
                rmHeight = Random.Range(0, 100);

                if (rmHeight < LONG_TILE_AVG)
                {
                    long_tile = Random.Range(2, 4);
                    long_tile = long_tile < tiles_left ? long_tile : tiles_left;
                    tiles_passed = long_tile - 1;
                    _tiles_passed = tiles_passed;
                }
                _pos = last_pos + (rm - 1) * TILE_WIDTH;
            } while (last_pos == _pos && index != 0);
        } while (_pos > TILE_BORDER || _pos < 0);
        
        if(_tiles_passed == 0){
            tile.GetComponent<tile>().resetTile();
            tile.transform.position = new Vector2(_pos, tile.transform.position.y);
            theScale = tile.transform.localScale;
            theScale.x = long_tile;
            tile.transform.localScale = theScale;
            tiles_passed = 0;
            // Debug.Log(long_tile);
            // tile.GetComponent<tile>().setLongTile(long_tile,TILE_HEIGHT);
        }else{
            tile.SetActive(false);
        }
        index++;
        tiles_left--;

        return _pos;
    }
    public void SetActiveToDefault()
    {
        ItsInside = false;
        last_pos = 0;
        tiles_left = 4;
        tiles_passed = 0;
        _tiles_passed = 0;
        long_tile = 1;
        index = 0;
        // theScale;
        // rm;
        // rmHeight;
        // _pos;
        foreach (var item in Tile)
        {
            index ++;
            item.SetActive(true);
            // item.GetComponent<BoxCollider2D>().enabled = true;
            item.GetComponent<tile>().cubeHited = false;
            item.GetComponent<tile>().itsInside = false;
        }
        index = 0;
    }

    public void hideSegment(){
        foreach (var item in Tile)
        {
            if(!item.GetComponent<tile>().itsInside){
                item.SetActive(false);
            }
        }
    }

}
