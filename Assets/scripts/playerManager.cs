using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataBank;

public class playerManager : MonoBehaviour
{
    public static playerDATA _playerDB;
    public GameObject popup;
    public GameObject musicItem;
    public GameObject musicContentHolder;
    public GameObject achievementItem;
    public GameObject achievementItemContentHolder;
    public GameObject FavItem;
    public Scrollbar scrollbarMusicList;
    public GameObject FavItemContentHolder;
    List<musicItem> listmusicItem = new List<musicItem>();
    List<musicItem> listAchievementItem = new List<musicItem>();
    List<musicItem> listFavItem = new List<musicItem>();
    public void Awake()
    {
        // PlayerPrefs.DeleteAll();
        Application.targetFrameRate = 60;
        _playerDB = playerDATA.Instance;
        // _playerDB.loadAllData();
    }
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(checkDB());2
        _playerDB.loadAllData();
        songsClick();
        favoritClick();
        archiveClick();
    }
    public void refreshList()
    {
        foreach (var item in listmusicItem)
        {
            Destroy(item.gameObject);
        }
        listmusicItem.Clear();
        musicItem.SetActive(true);
    }
    public void songsClick()
    {
        // refreshList();
        foreach (var i in _playerDB.songs)
        {
            GameObject _musicItem = (GameObject)Instantiate(musicItem);
            _musicItem.transform.SetParent(musicContentHolder.transform, true);
            _musicItem.transform.localScale = new Vector3(1, 1, 1);
            musicItem mi = _musicItem.GetComponent<musicItem>();
            mi.show(i);
            listmusicItem.Add(mi);
        }
        scrollbarMusicList.value = 1;
        musicItem.SetActive(false);
    }
    public void archiveClick()
    {
        var ls = DataBank.playerDATA.Instance.archives;
        foreach (var item in ls)
        {
            // Debug.Log(item.date);
            GameObject _musicItem = (GameObject)Instantiate(achievementItem);
            _musicItem.transform.SetParent(achievementItemContentHolder.transform, true);
            _musicItem.transform.localScale = new Vector3(1, 1, 1);
            musicItem mi = _musicItem.GetComponent<musicItem>();
            mi.showAchievement(item);
            listAchievementItem.Add(mi);
        }
        achievementItem.SetActive(false);
    }
    public void favoritClick()
    {
        var ls = DataBank.playerDATA.Instance.getfavs();
        foreach (var item in ls)
        {
            // Debug.Log(item.name);
            GameObject _musicItem = (GameObject)Instantiate(FavItem);
            _musicItem.transform.SetParent(FavItemContentHolder.transform, true);
            _musicItem.transform.localScale = new Vector3(1, 1, 1);
            musicItem mi = _musicItem.GetComponent<musicItem>();
            mi.show(item);
            listFavItem.Add(mi);
        }
        FavItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showPopupStore()
    {
        popup.SetActive(true);
    }
}
