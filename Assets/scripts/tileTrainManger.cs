using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class tileTrainManger : MonoBehaviour
{
    public GameObject camera;
    // public int SPEED = 10;
    public float TILE_HIEGHT = 8.6f;
    public List<GameObject> tileSegments;
    double timeLeft = 0;
    double waittime = 0;
    Vector3 lastPos;
    double progress;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject crown1;
    public GameObject crown2;
    public GameObject crown3;
    public GameObject progressBar;
    public GameObject endlessSprite;
    public GameObject onlineAvater;
    public Image onlineAvaterImage;
    public AudioManager audioManager;
    public AudioSource audioSource;
    public bool endlessPlay = false;
    public bool endlessPlay2 = false;
    int index = 0;
    Vector3 theScale;
    Vector3 originalthePos;
    Vector3 thePos;
    int onlineplayerScore;
    bool onlineplayerbar = false;
    // Start is called before the first frame update
    void Start()
    {
        if (DataBank.playerDATA.onlinePlayer != null)
        {
            onlineplayerScore = UnityEngine.Random.Range(500, 1200);
            DataBank.playerDATA.onlinePlayer.score = onlineplayerScore;
            // Debug.Log(onlineplayerScore);
            // if(true){
            onlineAvater.SetActive(true);
            originalthePos = onlineAvater.transform.position;
            thePos = onlineAvater.transform.position;
            StartCoroutine(LoadSprite(DataBank.playerDATA.onlinePlayer.picture.thumbnail));
            onlineplayerbar = true;
        }
        theScale = progressBar.transform.localScale;
        timeLeft = DataBank.playerDATA.currentSong.duration;
        lastPos = tileSegments[tileSegments.Count - 1].transform.position;
        // audioManager.
        // StartCoroutine(loadSongFile(DataBank.playerDATA.currentSong.filePath));
        _loadSongFile(DataBank.playerDATA.currentSong.filePath);
        // Debug.Log(DataBank.playerDATA.currentSong.name);
    }
    IEnumerator LoadSprite(string urlSprite)
    {
        WWW www = new WWW(urlSprite);
        yield return www;
        onlineAvaterImage.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }
    // IEnumerator loadSongFile(string path)
    // {
    //     WWW www = new WWW("file:///" + path);

    //     AudioClip myAudioClip = www.GetAudioClip();

    //     while (!myAudioClip.isReadyToPlay)
    //         yield return www;
    //     Sound sound = new Sound();
    //     sound.clip = myAudioClip;
    //     sound.name = "song";
    //     audioManager.sounds = new Sound[1];
    //     audioManager.sounds[0] = sound;
    //     audioManager.Play("song");
    //     // AudioClip clip = www.GetAudioClip(false);
    //     // string[] parts = path.Split('\\');
    //     // clip.name = parts[parts.Length - 1];
    //     // clips.Add(clip);
    // }
    async void _loadSongFile(string path)
    {
        WWW www = new WWW("file:///" + path);

        AudioClip myAudioClip = www.GetAudioClip();

        while (!myAudioClip.isReadyToPlay)
        // Sound sound = new Sound();
        // sound.clip = myAudioClip;
        // sound.name = "song";
        // audioManager.sounds = new Sound[1];
        // audioManager.sounds[0] = sound;
        // audioManager.Play("song");
        // audioManager.GetComponent<AudioSource>().Play();
        // audioManager.GetComponent<AudioSource>().loop = true;
        audioSource.clip = myAudioClip;
        audioSource.loop = true;
        // audioSource.Play();
    }
    // IEnumerator volumeDown()
    // {
    //     //
    //     float v = audioManager.sounds[0].volume;
    //     while (v > 0)
    //     {
    //         yield return v;
    //         v -= Time.deltaTime;
    //         audioManager.GetComponent<AudioSource>().volume = Mathf.Clamp01(v);
    //     }
    // }
    // IEnumerator volumeUp()
    // {
    //     //
    //     float v = audioManager.GetComponent<AudioSource>().volume;
    //     while (v < 1)
    //     {
    //         yield return v;
    //         v += Time.deltaTime;
    //         audioManager.GetComponent<AudioSource>().volume = Mathf.Clamp01(v);
    //     }
    // }
    IEnumerator volumeDown()
    {
        //
        float v = audioSource.volume;
        while (v > 0)
        {
            yield return v;
            v -= Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(v);
        }
    }
    IEnumerator volumeUp()
    {
        //
        float v = audioSource.volume;
        while (v < 1)
        {
            yield return v;
            v += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(v);
        }
    }
    void restartMusic()
    {
        audioSource.time = 0;
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (!camera.GetComponent<touchTile>().playing)
            return;
        // if (!audioManager.GetComponent<AudioSource>().isPlaying)
        //     audioManager.GetComponent<AudioSource>().Play();
        if(!audioSource.isPlaying)
            audioSource.Play();
        // Debug.Log(waittime);
        // Debug.Log(Time.deltaTime);
        if (waittime == 0)
            timeLeft -= Time.deltaTime;

        // Debug.Log("Time out " + timeLeft);
        progress = (DataBank.playerDATA.currentSong.duration - timeLeft) / DataBank.playerDATA.currentSong.duration * 100;
        theScale.x = float.Parse((progress / 100 * 3).ToString());

        if (onlineplayerbar)
        {
            // // if(true){
            // Debug.Log("thePos.y");
            // Debug.Log(thePos.y);
            // Debug.Log(onlineAvater.transform.position.y);
            thePos.x = originalthePos.x + 420 * theScale.x / 6;
            onlineAvater.transform.position = thePos;
        }

        progressBar.transform.localScale = progress < 200 ? theScale : progressBar.transform.localScale;
        // Debug.Log("PROGRESS  " + progress);
        if (progress > 0 && index == 0)
        {
            index++;
            // Debug.Log("PROGRESS  " + index);
            // star1.SetActive(true);
        }
        else if (progress > 33 && index == 1)
        {
            index++;
            // Debug.Log("PROGRESS  " + index);
            star1.SetActive(true);
            DataBank.playerDATA.currentSong.starts = index - 1;
        }
        else if (progress > 66 && index == 2)
        {
            index++;
            // Debug.Log("PROGRESS  " + index);
            star2.SetActive(true);
            DataBank.playerDATA.currentSong.starts = index - 1;
        }
        else if (progress >= 100 && index == 3)
        {
            onlineplayerbar = checkOnlinePlayerScore();
            index++;
            // Debug.Log("PROGRESS  " + index);
            star3.SetActive(true);
            DataBank.playerDATA.currentSong.starts = index - 1;
            DataBank.playerDATA.currentSong.diamand += 1;
        }
        else if (progress > 150 && index == 4)
        {
            onlineplayerbar = checkOnlinePlayerScore();
            index++;
            // Debug.Log("PROGRESS  " + index);
            crown1.SetActive(true);
            DataBank.playerDATA.currentSong.diamand += 1;
            DataBank.playerDATA.currentSong.starts = index - 1;
        }
        else if (progress > 200 && index == 5)
        {
            onlineplayerbar = checkOnlinePlayerScore();
            index++;
            // Debug.Log("PROGRESS  " + index);
            crown2.SetActive(true);
            DataBank.playerDATA.currentSong.diamand += 1;
            DataBank.playerDATA.currentSong.starts = index - 1;
        }
        else if (progress >= 300 && index == 6)
        {
            onlineplayerbar = checkOnlinePlayerScore();
            index++;
            // Debug.Log("PROGRESS  " + index);
            crown3.SetActive(true);
            DataBank.playerDATA.currentSong.diamand += 1;
            DataBank.playerDATA.currentSong.starts = index - 1;
        }

        if (progress > 100 && waittime == 0 && endlessPlay != true)
        {
            foreach (var item in tileSegments)
            {
                item.GetComponent<tilemanager>().hideSegment();
            }

            if (timeLeft <= -2 && waittime == 0) /* timeLeft < -2 && */
            {
                StartCoroutine(volumeDown());
                // Debug.Log(itsInside.eatedTiles);
                // DataBank.playerDATA.currentSong.score = 
                // DataBank.playerDATA.Instance.saveSongScore(DataBank.playerDATA.currentSong.id,
                //                                             DataBank.playerDATA.currentSong.score);
                // DataBank.playerDATA.Instance.saveSongScore(DataBank.playerDATA.currentSong.id,
                //                                             DataBank.playerDATA.currentSong.score,
                //                                             DataBank.playerDATA.currentSong.starts,
                //                                             DataBank.playerDATA.currentSong.starts < 4 ? 0 : DataBank.playerDATA.currentSong.starts - 3);
                // UnityEngine.SceneManagement.SceneManager.LoadScene("GameEnd");
                endlessSprite.SetActive(true);
                // Debug.Log("speed " + camera.GetComponent<touchTile>().SPEED);
                camera.GetComponent<touchTile>().SPEED = DataBank.playerDATA.currentSong.speed += 2;
                // Debug.Log("speed " + camera.GetComponent<touchTile>().SPEED);
                waittime = 3;
            }
            // endlessSprite.SetActive(true);
            //     // Debug.Log("speed " + camera.GetComponent<touchTile>().SPEED);
            //     camera.GetComponent<touchTile>().SPEED = DataBank.playerDATA.currentSong.speed += 2;
            //     // Debug.Log("speed " + camera.GetComponent<touchTile>().SPEED);
            //     waittime = 3;
        }
        else if (progress > 200 && waittime == 0 && endlessPlay2 != true)
        {
            foreach (var item in tileSegments)
            {
                item.GetComponent<tilemanager>().hideSegment();
            }

            if (timeLeft <= -(DataBank.playerDATA.currentSong.duration + 3) && waittime == 0) /* timeLeft < -2 && */
            {
                StartCoroutine(volumeDown());
                // Debug.Log(itsInside.eatedTiles);
                // DataBank.playerDATA.currentSong.score = 
                // DataBank.playerDATA.Instance.saveSongScore(DataBank.playerDATA.currentSong.id,
                //                                             DataBank.playerDATA.currentSong.score);
                // DataBank.playerDATA.Instance.saveSongScore(DataBank.playerDATA.currentSong.id,
                //                                             DataBank.playerDATA.currentSong.score,
                //                                             DataBank.playerDATA.currentSong.starts,
                //                                             DataBank.playerDATA.currentSong.starts < 4 ? 0 : DataBank.playerDATA.currentSong.starts - 3);
                // UnityEngine.SceneManagement.SceneManager.LoadScene("GameEnd");
                endlessSprite.SetActive(true);
                // Debug.Log("speed " + camera.GetComponent<touchTile>().SPEED);
                // camera.GetComponent<touchTile>().SPEED = DataBank.playerDATA.currentSong.speed += 2;
                // Debug.Log("speed " + camera.GetComponent<touchTile>().SPEED);
                waittime = 3;
            }
            // endlessSprite.SetActive(true);
            //     // Debug.Log("speed " + camera.GetComponent<touchTile>().SPEED);
            //     // camera.GetComponent<touchTile>().SPEED = DataBank.playerDATA.currentSong.speed += 2;
            //     // Debug.Log("speed " + camera.GetComponent<touchTile>().SPEED);
            //     waittime = 3;
        }
        // camera.transform.position = new Vector3(camera.transform.position.x,camera.transform.position.y + SPEED*Time.deltaTime,-10);
        // else 
        if (tileSegments[tileSegments.Count - 1].transform.position.y < camera.transform.position.y + TILE_HIEGHT && waittime == 0)
        {
            foreach (var item in tileSegments)
            {
                if (item.transform.position.y < camera.transform.position.y - 2 * TILE_HIEGHT)
                {
                    lastPos.y += TILE_HIEGHT;
                    item.transform.position = lastPos;
                    tilemanager tm = item.GetComponent<tilemanager>();
                    tm.generateTiles();
                }
            }
        }
        else if (waittime > 0)
        {
            // Debug.Log("else");
            waittime -= Time.deltaTime;
            // Debug.Log(waittime);
            // if (waittime < 1 && endlessSprite.active)
            // {
            //     Debug.Log("waittime < 2");
            // }
            if (waittime < 0)
            {
                lastPos.y += TILE_HIEGHT;

                endlessSprite.SetActive(false);
                // Debug.Log("waittime < 0");
                waittime = 0;
                audioSource.pitch = 1.3f;
                restartMusic();
                StartCoroutine(volumeUp());
                if (progress < 200)
                    endlessPlay = true;
                else if (progress > 200)
                    endlessPlay2 = true;
            }
        }
    }
    bool checkOnlinePlayerScore()
    {
        return DataBank.playerDATA.currentSong.score > onlineplayerScore;
    }
}
