using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DataBank;

public class cdplay : MonoBehaviour
{
    public float Speed = 20;
    public song _song;
    // public AudioManager audioManager;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        var songlist = from song in DataBank.playerDATA.Instance.songs where song.filePath != "false" select song;
        int rdm = Random.Range(0, songlist.Count());
        // songlist.ElementAt
        Debug.Log(songlist.ElementAt(rdm).title);
        // StartCoroutine(loadSongFile(songlist.ElementAt(rdm).filePath));
        _loadSongFile(songlist.ElementAt(rdm).filePath);
    }
    IEnumerator loadSongFile(string path)
    {
        WWW www = new WWW("file:///" + path);

        AudioClip myAudioClip = www.GetAudioClip();

        while (!myAudioClip.isReadyToPlay)
            yield return www;
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
        audioSource.Play();
    }
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
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Speed * Time.deltaTime);
    }
}
