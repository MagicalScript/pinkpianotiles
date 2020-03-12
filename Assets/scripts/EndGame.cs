using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class EndGame : MonoBehaviour
{
    public Text name;
    // public Image thumbnail;
    public Text score;
    public Text winLoseText;
    public Text bestScore;
    public Text diamand;
    public Text coin;
    // public int stars;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject crown1;
    public GameObject crown2;
    public GameObject crown3;
    public GameObject starsBackground;
    public GameObject crownsBackgruond;
    public GameObject rateUsUI;
    public monetization monetization;

    // Start is called before the first frame update
    void Start()
    {
        monetization.showInterstitial();
        StartCoroutine(chackrate());
        if (DataBank.playerDATA.onlinePlayer != null)
        {
            if (DataBank.playerDATA.onlinePlayer.score < DataBank.playerDATA.currentSong.score)
            {
                winLoseText.text = "You Win";
            }
            else
            {
                winLoseText.text = "You Lose";
            }
        }
        itsInside.eatedTiles = 0;
        DataBank.playerDATA.currentSong.speed = 6.5f;
        var _playerdata = DataBank.playerDATA.currentSong;
        name.text = _playerdata.title;
        score.text = "Score : " + _playerdata.score.ToString();
        diamand.text = _playerdata.diamand.ToString();
        // coin.text = _playerdata.coin.ToString();
        coin.text = (_playerdata.score / 10).ToString();
        var _bestScore = from songScore in DataBank.playerDATA.Instance.songScores where songScore.id == _playerdata.id select songScore;
        foreach (var bscore in _bestScore)
        {
            bestScore.text = "Best Score : " + (bscore.bestScore > _playerdata.score ? bscore.bestScore : _playerdata.score).ToString();
        }
        // Debug.Log(_playerdata.starts);
        starsBackground.SetActive(_playerdata.starts < 4 ? true : false);
        crownsBackgruond.SetActive(_playerdata.starts > 3 ? true : false);
        star1.SetActive(_playerdata.starts > 0 && _playerdata.starts < 4 ? true : false);
        star2.SetActive(_playerdata.starts > 1 && _playerdata.starts < 4 ? true : false);
        star3.SetActive(_playerdata.starts > 2 && _playerdata.starts < 4 ? true : false);
        crown1.SetActive(_playerdata.starts > 3 ? true : false);
        crown2.SetActive(_playerdata.starts > 4 ? true : false);
        crown3.SetActive(_playerdata.starts > 5 ? true : false);
    }

    // public void likeClick()
    // {
    //     Debug.Log("likeClick");
    // }

    IEnumerator chackrate()
    {
        yield return new WaitForSeconds(1.5f);
        if (!PlayerPrefs.HasKey("rated") || PlayerPrefs.GetString("rated") == "false")
        {
            if (!PlayerPrefs.HasKey("rateTimes"))
            {
        Debug.Log("openRateUs 0");
                PlayerPrefs.SetInt("rateTimes", 0);
            }
            else if (PlayerPrefs.GetInt("rateTimes") < 3)
            {
        Debug.Log("openRateUs " + PlayerPrefs.GetInt("rateTimes"));
                PlayerPrefs.SetInt("rateTimes", PlayerPrefs.GetInt("rateTimes") + 1);
            }else if(PlayerPrefs.GetInt("rateTimes") == 3){
        Debug.Log("openRateUs rateUsUI.SetActive(true);");
                rateUsUI.SetActive(true);
                PlayerPrefs.SetInt("rateTimes",0);
            }
            // string d = PlayerPrefs.GetString("ratedate");
            // DateTime dateDiff;
            // DateTime.TryParse(d, out dateDiff);
            // if ((DateTime.Now - dateDiff).TotalDays > 0.001 || !PlayerPrefs.HasKey("ratedate"))
            // {
            //     rateUsUI.SetActive(true);
            // }
        }
    }
    public void openRateUs()
    {
        // yield return new WaitForSeconds(3f);
        Debug.Log("openRateUs");
        Application.OpenURL("market://details?id=" + Application.identifier);
        PlayerPrefs.SetString("rated", "true");
        rateUsUI.SetActive(false);

    }
    public void laterRate()
    {
        Debug.Log("laterRate");
        PlayerPrefs.SetString("ratedate", DateTime.Now.ToString());
        PlayerPrefs.SetString("rate", "false");
        rateUsUI.SetActive(false);

    }

    public void ReplayClick()
    {
        // Debug.Log("ReplayClick");
        DataBank.playerDATA.currentSong.score = 0;
        DataBank.playerDATA.currentSong.starts = 0;
        SceneManager.LoadScene("tile");
    }
    public void BackClick()
    {
        // Debug.Log("BackClick");
        SceneManager.LoadScene("ui");
        DataBank.playerDATA.currentSong.id = 0;
        DataBank.playerDATA.currentSong.title = "";
        DataBank.playerDATA.currentSong.price = 0;
        DataBank.playerDATA.currentSong.score = 0;
        DataBank.playerDATA.currentSong.starts = 0;
        DataBank.playerDATA.onlinePlayer = null;
        // DataBank. playerDATA.currentSong. = 0;
    }

    public void likeClick()
    {
        var _song = from song in DataBank.playerDATA.Instance.songs
                    where song.id == DataBank.playerDATA.currentSong.id
                    select song;
        // liked.SetActive(_song.liked);
        var s = _song.ElementAt(0);
        s.liked = true;
        DataBank.playerDATA.Instance.updateLikeSong(s);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
