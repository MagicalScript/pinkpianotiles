using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookScript : MonoBehaviour
{

    public Image ProfilePicture;
    public Text FriendsText;
    public Text profilename;
    string profilePictureKey = "profilePicture";
    string profileNameKey = "profileName";
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
    }
    public void Start()
    {
        if (PlayerPrefs.HasKey(profilePictureKey))
        {
            StartCoroutine(loadProfilePicSprite(PlayerPrefs.GetString(profilePictureKey)));
        }
        if (PlayerPrefs.HasKey(profileNameKey))
        {
            StartCoroutine(loadProfilename(PlayerPrefs.GetString(profileNameKey)));
        }
    }
    // Use this for initialization
    IEnumerator loadProfilePicSprite(string path)
    {
        WWW www = new WWW("file:///" + path);
        while (!www.isDone)
            yield return null;
        ProfilePicture.sprite = Sprite.Create(www.texture, new Rect(0, 0, 128, 128), new Vector2());
    }
    IEnumerator loadProfilename(string name)
    {
        profilename.name = name;
        yield return null;
    }

    #region Login / Logout
    public void loginBtn()
    {
        StartCoroutine(FacebookLogin());
    }

    IEnumerator FacebookLogin()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);
        FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, FbGetPicture);
        FB.API("me?fields=name", HttpMethod.GET, GetFacebookData);
        yield return null;
    }


    private void FbGetPicture(IGraphResult result)
    {
        string PicturePath;
        if (result.Texture != null)
        {
            ProfilePicture.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
            PicturePath = SaveTextureToFile(result.Texture, "profile.png");
            PlayerPrefs.SetString(profilePictureKey, PicturePath);
        }
    }
    void GetFacebookData(Facebook.Unity.IGraphResult result)
    {
        string fbName = result.ResultDictionary["name"].ToString();
        profilename.text = fbName;
        PlayerPrefs.SetString(profileNameKey, fbName);

        // Debug.Log("fbName: " + fbName);
    }


    public string SaveTextureToFile(Texture2D texture, string fileName)
    {
        string path = Application.dataPath + "/" + fileName;
        var bytes = texture.EncodeToPNG();
        var file = File.Open(path, FileMode.Create);
        var binary = new BinaryWriter(file);
        binary.Write(bytes);
        file.Close();
        return path;
    }

    public void FacebookLogout()
    {
        FB.LogOut();
    }
    #endregion

    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("https://resocoder.com"), "Check it out!",
            "Good programming tutorials lol!",
            new System.Uri("https://resocoder.com/wp-content/uploads/2017/01/logoRound512.png"));
    }

    #region Inviting
    public void FacebookGameRequest()
    {
        FB.AppRequest("Hey! Come and play this awesome game!", title: "Reso Coder Tutorial");
    }

    public void FacebookInvite()
    {
        FB.Mobile.AppInvite(new System.Uri("https://play.google.com/store/apps/details?id=com.tappybyte.byteaway"));
    }
    #endregion

    public void GetFriendsPlayingThisGame()
    {
        string query = "/me/friends";
        FB.API(query, HttpMethod.GET, result =>
        {
            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
            var friendsList = (List<object>)dictionary["data"];
            FriendsText.text = string.Empty;
            foreach (var dict in friendsList)
                FriendsText.text += ((Dictionary<string, object>)dict)["name"];
        });
    }
}