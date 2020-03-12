using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using DataBank;

public class musicItem : MonoBehaviour
{
    public song _song;
    public archive _archive;
    public GameObject starsGray;
    public GameObject crownsGray;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject crown1;
    public GameObject crown2;
    public GameObject crown3;
    public GameObject IdText;
    public GameObject nameText;
    public GameObject DescText;
    public GameObject buyButton;
    public GameObject playButton;
    public GameObject liked;
    public Text score;
    public Text price;
    public GameObject coinCurrency;
    public GameObject diamandCurrency;
    public Text dateText;
    public infobar _infobar;
    private Downloader _downloader = new Downloader();
    public GameObject downloadState;
    
    public Sprite instrementalSprite;
    public Sprite hiphopSprite;
    public Sprite soundtrackSprite;
    public Image thampnail;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void show(song i)
    {
        _song = i;
        // Debug.Log(i.name);
        // GameObject go = transform.GetChild(0).GetChild(0).gameObject;
        Text t = IdText.GetComponent<Text>();
        t.text = i.id.ToString();
        t = DescText.GetComponent<Text>();
        t.text = i.title.ToString();
        // go = transform.GetChild(1).GetChild(0).gameObject;
        t = nameText.GetComponent<Text>();
        t.text = i.title;
        if (i.crowns > 0)
        {
            starsGray.SetActive(false);
            crownsGray.SetActive(true);
            crown1.SetActive(i.crowns > 0 ? true : false);
            crown2.SetActive(i.crowns > 1 ? true : false);
            crown3.SetActive(i.crowns > 2 ? true : false);
        }
        else
        {
            // Debug.Log(i.stars);
            star1.SetActive(i.stars > 0 ? true : false);
            star2.SetActive(i.stars > 1 ? true : false);
            star3.SetActive(i.stars > 2 ? true : false);
        }
        if (i.owned)
        {
            // Debug.Log("owned .....;;. owned");
            buyButton.SetActive(false);
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
            buyButton.SetActive(true);
            if (i.currency == currency.coin)
            {
                coinCurrency.SetActive(true);
                diamandCurrency.SetActive(false);
            }
            else
            {
                coinCurrency.SetActive(false);
                diamandCurrency.SetActive(true);
            }
            // Text _price = buyButton.transform.GetChild(2).gameObject.GetComponent<Text>();
            price.text = i.price.ToString();
        }
        if(i.genre == SongGenre.Instrumental){
            thampnail.sprite = instrementalSprite;
        }else if(i.genre == SongGenre.HipHop)
        {   
            thampnail.sprite = hiphopSprite;
        }else if(i.genre == SongGenre.Soundtrack)
        {   
            thampnail.sprite = soundtrackSprite;
        }
        liked.SetActive(i.liked);
    }


    public void showAchievement(archive i)
    {
        _archive = i;
        score.text = "Score : " + _archive.score.ToString();
        dateText.text = i.date.ToString();
        // Debug.Log(i.name);
        // GameObject go = transform.GetChild(0).GetChild(0).gameObject;
        Text t = IdText.GetComponent<Text>();
        // t.text = i.id.ToString();
        t = DescText.GetComponent<Text>();
        t.text = i.author.ToString();
        // go = transform.GetChild(1).GetChild(0).gameObject;
        t = nameText.GetComponent<Text>();
        t.text = i.name;
        if (i.crowns > 0)
        {
            starsGray.SetActive(false);
            crownsGray.SetActive(true);
            crown1.SetActive(i.crowns > 0 ? true : false);
            crown2.SetActive(i.crowns > 1 ? true : false);
            crown3.SetActive(i.crowns > 2 ? true : false);
        }
        else
        {
            // Debug.Log(i.stars);
            star1.SetActive(i.stars > 0 ? true : false);
            star2.SetActive(i.stars > 1 ? true : false);
            star3.SetActive(i.stars > 2 ? true : false);
        }
        // if (i.owned)
        // {
        //     // Debug.Log("owned .....;;. owned");
        //     buyButton.SetActive(false);
        // // }
        // else
        // {
        //     Text _price = buyButton.transform.GetChild(2).gameObject.GetComponent<Text>();
        //     _price.text = i.price.ToString();
        // }
        // liked.SetActive(i.liked);
    }
    public void goToPlay()
    {
        if (_song.filePath == "false")
        {
            // downloadLancer(_song);
            downloadState.SetActive(true);
            _downloader.SyncGetSongById(_song,goToTilePlay);
        }
        else
        {
            Debug.Log(_song.filePath);
            goToTilePlay(_song);
        }
    }
    async void downloadLancer(song song)
    {
        await _downloader.getSongById(song);
        goToTilePlay(_song);
    }
    public void goToTilePlay(song _song)
    {
        Debug.Log("goToPlay !: " + _song.filePath);
        SceneManager.LoadScene("tile");
        playerDATA.currentSong.id = _song.id;
        playerDATA.currentSong.title = _song.title;
        playerDATA.currentSong.speed = 6.5f;
        playerDATA.currentSong.filePath = _song.filePath;
        // playerDATA.currentSong.duration = _song.duration;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void likeBtn()
    {
        if (_song.liked)
        {
            _song.liked = false;
        }
        else
        {
            _song.liked = true;
        }
        liked.SetActive(_song.liked);
        DataBank.playerDATA.Instance.updateLikeSong(_song);
    }

    public void buyClick()
    {
        // Debug.Log("buy btn");
        var pd = DataBank.playerDATA.Instance;
        if (_song.currency == currency.coin)
            if (_song.price <= pd.coins)
            {
                pd.coins -= int.Parse(_song.price.ToString());
                _song.owned = true;
                pd.updateOwnedSong(_song);
                pd.saveplayer();
            }
            else if (pd.diamands * 100 >= _song.price)
            {
                int i = int.Parse(_song.price.ToString()) / 100 + 1;
                pd.coins += i * 100;
                pd.diamands -= i;
                pd.coins -= int.Parse(_song.price.ToString());
                _song.owned = true;
                pd.updateOwnedSong(_song);
                pd.saveplayer();
            }
            else
            {
                Debug.Log("not enough coins");
            }
        else if (_song.currency == currency.diamand)
            if (_song.price <= pd.diamands)
            {
                pd.diamands -= int.Parse(_song.price.ToString());
                _song.owned = true;
                pd.updateOwnedSong(_song);
                pd.saveplayer();
            }
            else
            {
                Debug.Log("not enough diamands");
            }
        _infobar.showData();
        this.show(_song);
    }
}
