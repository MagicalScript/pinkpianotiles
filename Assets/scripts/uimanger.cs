using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class uimanger : MonoBehaviour
{
    public Transform Container ,mainMenu, SongMenu, archiveMenu, OnlineMenu, favMenu;
    public Transform BtnContainer ,BtnMainMenu, BtnSongMenu, BtnArchiveMenu, BtnOnlineMenu, BtnFavMenu;
    public GameObject backBtnSetting,backBtnListMusic;
    public GameObject listContainer,settingContainer;
    // Start is called before the first frame update
    private Transform currentPage;
    private Transform currentBtn;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toMainMenu()
    {
        MoveTo(mainMenu);
        btnMoveTo(BtnMainMenu);
    }
    public void toSongMenu()
    {
        MoveTo(SongMenu);
        btnMoveTo(BtnSongMenu);
    }
    public void toArchiveMenu()
    {
        btnMoveTo(BtnArchiveMenu);
        MoveTo(archiveMenu);
    }
    public void toOnlineMenu()
    {
        btnMoveTo(BtnOnlineMenu);
        MoveTo(OnlineMenu);
    }
    public void toFavMenu()
    {
        btnMoveTo(BtnFavMenu);
        MoveTo(favMenu);
    }

    private void MoveTo(Transform page){
        if(currentPage != page){
           Container.DOMove(new Vector3(Container.position.x - page.position.x, Container.position.y, Container.position.z), 0.5f, true);
           currentPage = page;
        }
    }
    private void btnMoveTo(Transform btn){
        if(currentBtn != btn){
           BtnContainer.DOMove(new Vector3(btn.position.x, BtnContainer.position.y, BtnContainer.position.z), 0.5f, true);
           currentPage = btn;
        }
    }
    public void showSetting(){
        backBtnSetting.SetActive(true);
        backBtnListMusic.SetActive(false);
        listContainer.SetActive(false);
        settingContainer.SetActive(true);
    }
    public void showLists(){
        backBtnSetting.SetActive(false);
        backBtnListMusic.SetActive(true);
        listContainer.SetActive(true);
        settingContainer.SetActive(false);
    }
}
