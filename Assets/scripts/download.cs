using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using CI.HttpClient;

public class Downloader
{
    public delegate void afterDownload(song _song);
    string songURL = "https://cf-preview-media.sndcdn.com/preview/0/30/1733sGgBf1Cd.128.mp3?Policy=eyJTdGF0ZW1lbnQiOlt7IlJlc291cmNlIjoiKjovL2NmLXByZXZpZXctbWVkaWEuc25kY2RuLmNvbS9wcmV2aWV3LzAvMzAvMTczM3NHZ0JmMUNkLjEyOC5tcDMiLCJDb25kaXRpb24iOnsiRGF0ZUxlc3NUaGFuIjp7IkFXUzpFcG9jaFRpbWUiOjE1NTU1OTA1MjV9fX1dfQ__&Signature=jEJ1Sq7AmK0DeZVuOMueP2VOPBQXCaip6uBy7-shufcOHpZD5-xBNj40lm5JN81CkVcUnCtZ8MH-mMQw3l7RM3CNg3pIFgRmJaYVOVUeQJHh~8Cr~EkR3DFVrF1m6~nZSFFw7enJM9s9GUGdaGpVyT4ydVjtgCEzpUIXxMShW6ERGhMP~nQG2blBbjKdZHmws5HIz8eKPAf5ZP5gLMy6J2beLMnNEgqiRpgUtwrk93ha0O2g2mTZ2OeTJsPwsDBtJST0E67GtA6sCO~EwpEWIGXnUW1OnZCSOZRqMiCQmYaWaoIySwHPVLzPA1qBPe6EGocIrWuEwsK-BtZvc43Bkg__&Key-Pair-Id=APKAJAGZ7VMH2PFPW6UQ";
    // Start is called before the first frame update
    string songName = "https://soundcloud.com/alibrustofski/fight-song-rachel-platten-cover-by-ali-brustofski-this-is-my-fight-song";
    string getRequast = "https://api.soundcloud.com/resolve.json?url=https://soundcloud.com/alibrustofski/fight-song-rachel-platten-cover-by-ali-brustofski-this-is-my-fight-song&client_id=e2a6681bccff23130855618e14c481af";
    
    void Start()
    {
        // getSongId(songURL);
    }

    public static bool tufrn = false;
    public async Task downloadSong(string Url)
    {

        HttpClient httpClient = new HttpClient();
        httpClient.Get(new System.Uri(Url), HttpCompletionOption.AllResponseContent, (r) =>
        {
            // Raised either when the download completes or periodically depending on the HttpCompletionOption
            Debug.Log(r.PercentageComplete);

            if (!tufrn)
            {
                // using (Stream streamToReadFrom = r.ReadAsStream())
                // {

                Stream streamToReadFrom = r.ReadAsStream();
                string stt = Application.persistentDataPath + "/test10.mp3";
                Debug.Log(stt);
                // Stream str = File.Create(stt);
                tufrn = true;
                Stream str = File.Create(stt);
                streamToReadFrom.CopyTo(str);
                str.Close();
                // }

            }
        });

    }
    // Update is called once per frame
    void Update()
    {

    }

    public async Task getSongById(song songData)
    {
        track jsontoobjet = new track();
        HttpClient httpClient = new HttpClient();
        httpClient.Get(new System.Uri(string.Format("https://api.soundcloud.com/resolve.json?url={0}&client_id=e2a6681bccff23130855618e14c481af",
            songData.url)),
                HttpCompletionOption.AllResponseContent, (r) =>
                {
                    Stream sr = r.ReadAsStream();
                    // using (Stream responseStream = response.GetResponseStream())
                    // {
                    StreamReader reader = new StreamReader(sr);
                    // Console.WriteLine(reader.ReadToEnd());
                    // }
                    jsontoobjet = JsonUtility.FromJson<track>(reader.ReadToEnd());
                    Debug.Log(jsontoobjet.id);

                    httpClient.Get(new System.Uri(string.Format("http://api.soundcloud.com/i1/tracks/{0}/streams?client_id=e2a6681bccff23130855618e14c481af",
                                jsontoobjet.id)),
                                    HttpCompletionOption.AllResponseContent, (r2) =>
                                    {
                                        sr = r2.ReadAsStream();
                                        // using (Stream responseStream = response.GetResponseStream())
                                        // {
                                        reader = new StreamReader(sr);
                                        // Console.WriteLine(reader.ReadToEnd());
                                        // }
                                        jsontoobjet = JsonUtility.FromJson<track>(reader.ReadToEnd());
                                        Debug.Log(jsontoobjet.http_mp3_128_url);

                                        httpClient.Get(new System.Uri(jsontoobjet.http_mp3_128_url), HttpCompletionOption.AllResponseContent, (r3) =>
                                        {
                                            // Raised either when the download completes or periodically depending on the HttpCompletionOption
                                            Debug.Log(r3.PercentageComplete);

                                            if (!tufrn)
                                            {
                                                // using (Stream streamToReadFrom = r.ReadAsStream())
                                                // {

                                                Stream streamToReadFrom = r3.ReadAsStream();
                                                string stt = Application.persistentDataPath + "/" + songData.title +".audio";
                                                songData.filePath = stt;
                                                DataBank.playerDATA.Instance.updateFilePathSong(songData);
                                                Debug.Log(stt);
                                                // Stream str = File.Create(stt);
                                                tufrn = true;
                                                Stream str = File.Create(stt);
                                                streamToReadFrom.CopyTo(str);
                                                str.Close();
                                                 
                                            }
                                        });


                                    });
                });
        // return jsontoobjet.id;
    }
    public void SyncGetSongById(song songData,afterDownload fnc)
    {
        track jsontoobjet = new track();
        HttpClient httpClient = new HttpClient();
        httpClient.Get(new System.Uri(string.Format("https://api.soundcloud.com/resolve.json?url={0}&client_id=e2a6681bccff23130855618e14c481af",
            songData.url)),
                HttpCompletionOption.AllResponseContent, (r) =>
                {
                    Stream sr = r.ReadAsStream();
                    // using (Stream responseStream = response.GetResponseStream())
                    // {
                    StreamReader reader = new StreamReader(sr);
                    // Console.WriteLine(reader.ReadToEnd());
                    // }
                    jsontoobjet = JsonUtility.FromJson<track>(reader.ReadToEnd());
                    Debug.Log("SyncGetSongById : "+jsontoobjet.id);

                    httpClient.Get(new System.Uri(string.Format("http://api.soundcloud.com/i1/tracks/{0}/streams?client_id=e2a6681bccff23130855618e14c481af",
                                jsontoobjet.id)),
                                    HttpCompletionOption.AllResponseContent, (r2) =>
                                    {
                                        sr = r2.ReadAsStream();
                                        // using (Stream responseStream = response.GetResponseStream())
                                        // {
                                        reader = new StreamReader(sr);
                                        // Console.WriteLine(reader.ReadToEnd());
                                        // }
                                        jsontoobjet = JsonUtility.FromJson<track>(reader.ReadToEnd());
                                        Debug.Log("SyncGetSongById : "+jsontoobjet.http_mp3_128_url);

                                        httpClient.Get(new System.Uri(jsontoobjet.http_mp3_128_url), HttpCompletionOption.AllResponseContent, (r3) =>
                                        {
                                            // Raised either when the download completes or periodically depending on the HttpCompletionOption
                                            Debug.Log("SyncGetSongById : "+r3.PercentageComplete);

                                            if (!tufrn)
                                            {
                                                // using (Stream streamToReadFrom = r.ReadAsStream())
                                                // {

                                                Stream streamToReadFrom = r3.ReadAsStream();
                                                string stt = Application.persistentDataPath + "/" + songData.title +".mp3";
                                                songData.filePath = stt;
                                                DataBank.playerDATA.Instance.updateFilePathSong(songData);
                                                Debug.Log("SyncGetSongById : "+stt);
                                                // Stream str = File.Create(stt);
                                                tufrn = true;
                                                Stream str = File.Create(stt);
                                                streamToReadFrom.CopyTo(str);
                                                str.Close();
                                                fnc(songData);
                                            }
                                        });


                                    });
                });
        // return jsontoobjet.id;
    }
}
