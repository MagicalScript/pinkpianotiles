using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using CI.HttpClient;

public class onlinePLayer : MonoBehaviour
{
    private Downloader _downloader = new Downloader();
    public GameObject downloadState;

    private onlinedataADPT.Result onlinePlayer;
    public string urlOnlineData = "https://randomuser.me/api/";
    // Start is called before the first frame update
    async void checkOnlinePlayer(string url)
    {
        HttpClient httpClient = new HttpClient();
        httpClient.Get(new System.Uri(url), HttpCompletionOption.AllResponseContent, (r) =>
                {
                    Stream sr = r.ReadAsStream();
                    StreamReader reader = new StreamReader(sr);

                    onlinedataADPT.Result[] _onlinePLayer = new onlinedataADPT.Result[2];
                    _onlinePLayer = JsonHelper.FromJson<onlinedataADPT.Result>(reader.ReadToEnd());

                    // Debug.Log("checkOnlinePlayer done");
                    // Debug.Log(_onlinePLayer[0].picture.large);
                    onlinePlayer = _onlinePLayer[0];
                    StartCoroutine(LoadSprite(_onlinePLayer[0].picture.medium));
                    nametext.text = _onlinePLayer[0].name.first + " " + _onlinePLayer[0].name.last;
                    Contery.text = _onlinePLayer[0].location.timezone.description;
                });
    }

    public Image img;
    public Text nametext;
    public Text Contery;
    // The source image
    // public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";

    IEnumerator LoadSprite(string urlSprite)
    {
        WWW www = new WWW(urlSprite);
        yield return www;
        img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }
    void Start()
    {
        checkOnlinePlayer(urlOnlineData);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBtn()
    {
        var _song = getRandomSong();

        if (_song.filePath == "false")
        {
            // downloadLancer(_song);
            downloadState.SetActive(true);
            _downloader.SyncGetSongById(_song, goToTilePlay);
        }
        else
        {
            goToTilePlay(_song);
        }
    }

    public void goToTilePlay(song _song)
    {
        // Debug.Log("goToPlay");
        DataBank.playerDATA.onlinePlayer = onlinePlayer;
        SceneManager.LoadScene("tile");
        DataBank.playerDATA.currentSong.id = _song.id;
        DataBank.playerDATA.currentSong.title = _song.title;
        DataBank.playerDATA.currentSong.speed = 6.5f;
        DataBank.playerDATA.currentSong.filePath = _song.filePath;
        // playerDATA.currentSong.duration = _song.duration;
    }

    public song getRandomSong()
    {
        var songlist = from song in DataBank.playerDATA.Instance.songs where song.owned == true select song;
        int rdm = Random.Range(0, songlist.Count());
        // // songlist.ElementAt
        Debug.Log("rdm  :  " + rdm + "songlist.Count() : " + songlist.Count());
        // StartCoroutine(loadSongFile(songlist.ElementAt(rdm).filePath));
        return songlist.ElementAt(rdm);
    }
}
