using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Mono.Data.Sqlite;
using System.Data;
using System;


// public struct OnlinePlayer
// {
//     public int diamands;
//     public int coins;
//     public int stars;
//     public int crowns;

// }
public enum SongGenre
{
    Instrumental,
    HipHop,
    Soundtrack
}
public enum currency
{
    coin,
    diamand
}
public struct song
{
    public int id;
    public string title;
    public string desc;
    public string url;
    public SongGenre genre;
    public double price;
    public currency currency;
    public double duration;
    public int stars;
    public int crowns;
    public bool owned;
    public float speed;
    public bool liked;
    public string filePath;
}
public struct _songScore
{
    public int id;
    public string title;
    public string url;
    public SongGenre genre;
    public double price;
    private const double _duration = 120; // fixed duration to 2min
    public double duration
        {
            get
            {
                return _duration;
            }
        }
    public int score;
    public int starts;
    public int diamand;
    public int coin;
    public int gifts;
    public float speed;
    public string filePath;
}
public struct album
{
    public int id;
    public string name;
    public float price;
    public string thumbnail;
}
public struct songScore
{
    public int id;
    public int songID;
    public int score;
    public DateTime date;
    public int bestScore;
    public int starts;
    public int crowns;
}
public struct archive
{
    public string name;
    public string author;
    public DateTime date;
    public int stars;
    public int crowns;
    public int score;
}
namespace DataBank
{
    
    public class playerDATA : SqliteHelper
    {
        private static bool turn = false;
        private static playerDATA _Instance;
        public static onlinedataADPT.Result onlinePlayer;
        public static playerDATA Instance
        {
            private set
            {
                _Instance = value;
            }
            get
            {
                // Debug.Log(turn);
                if (!turn)
                {
                    _Instance = new playerDATA();
                    turn = true;
                }
                return _Instance;
            }
        }

        // Start is called before the first frame update
        #region SQLDB
        string cmd_songdb = @"CREATE TABLE song (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    title VARCHAR(50) NULL DEFAULT NULL,
                    desc VARCHAR(50) NULL DEFAULT NULL,
                    url VARCHAR(200) NULL DEFAULT NULL,
                    genre VARCHAR(50) NULL DEFAULT NULL,
                    price VARCHAR(50) NULL DEFAULT NULL,
                    currency VARCHAR(50) NULL DEFAULT NULL,
                    duration VARCHAR(50) NULL DEFAULT 120,
                    owned VARCHAR(50) NULL DEFAULT NULL,
                    liked VARCHAR(50) NULL DEFAULT false,
                    speed VARCHAR(50) NULL DEFAULT false,
                    filePath VARCHAR(50) NULL DEFAULT false
                )";
        string cmd_albumdb = @"CREATE TABLE album (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name VARCHAR(50) NULL DEFAULT NULL,
                    price VARCHAR(50) NULL DEFAULT NULL,
                    thumbnail VARCHAR(50) NULL DEFAULT NULL
                )";
        string cmd_albumsongsdb = @"CREATE TABLE albumsongs (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    albumID VARCHAR(50) NULL DEFAULT NULL,
                    songID VARCHAR(50) NULL DEFAULT NULL
                )";
        string cmd_songScoredb = @"CREATE TABLE songScore (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    songID VARCHAR(50) NULL DEFAULT NULL,
                    score VARCHAR(50) NULL DEFAULT NULL,
                    date VARCHAR(50) NULL DEFAULT NULL,
                    starts VARCHAR(50) NULL DEFAULT 0,
                    crowns VARCHAR(50) NULL DEFAULT 0
                )";
        string cmd_playerddb = @"CREATE TABLE player (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    facebook VARCHAR(100) NULL DEFAULT NULL,
                    diamand VARCHAR(50) NULL DEFAULT NULL,
                    coin VARCHAR(50) NULL DEFAULT NULL
                )";

        public void createDB()
        {
            this.ExecuteCMD(cmd_albumdb);
            this.ExecuteCMD(cmd_albumsongsdb);
            this.ExecuteCMD(cmd_playerddb);
            this.ExecuteCMD(cmd_songScoredb);
            this.ExecuteCMD(cmd_songdb);
            this.ExecuteCMD(Query.DATAQuery);
            Debug.Log("createDB finishd");
        }
        #endregion
        #region declarations

        public static _songScore currentSong;
        public List<song> songs;
        public List<album> albums;
        public List<songScore> songScores;
        public List<archive> archives;
        public int diamands;
        public int stars;
        public int coins;
        public int crowns;
        #endregion

        private playerDATA()
        {
            // createDB();

            bool notready = true;
            if (PlayerPrefs.HasKey("dataReady"))
                if (PlayerPrefs.GetInt("dataReady") == 1)
                {
                    notready = false;
                    // Debug.Log("loadAllData()");
                    loadAllData();
                }
            if (notready)
            {
                PlayerPrefs.SetInt("dataReady", 1);
                PlayerPrefs.Save();
                createDB();
                loadAllData();
                // Debug.Log("createDB()");
            }
            // Debug.Log("notready "+notready);
        }

        public IDbCommand saveAllData()
        {
            string cmd = String.Format("");
            return null;
        }
        public void loadAllData()
        {
            songScores = this.GetSongScores();
            songs = this.GetSongs();
            // albums = this.GetAlbums();
            getplayer();
            getacheves();
            archives = GetArchive();
        }

        public int ExecuteCMD(string cmd)
        {
            IDbCommand query = getDbCommand();
            query.CommandText = cmd;
            return query.ExecuteNonQuery();
        }
        public IDataReader ExecuteReadCMD(string cmd)
        {
            IDbCommand query = getDbCommand();
            query.CommandText = cmd;
            return query.ExecuteReader();
        }
        //datetime('now')
        public int saveSongScore(int song,
                                    int diamand, int score, int stars, int crowns)
        {
            // remove bestscore and get it from DB by query
            string cmd = String.Format(@"insert into songScore (songID,score,date,starts,crowns) 
                        values ('{0}','{1}',datetime('now'),'{2}','{3}')"
                                    , song
                                    , score, stars, crowns);
            saveplayer(diamand, score);
            return ExecuteCMD(cmd);
        }

        public void saveplayer(int diamand, int score)
        {
            coins += (score / 10);
            diamands += diamand;
            PlayerPrefs.SetInt("diamand", diamands);
            PlayerPrefs.SetInt("score", coins);
        }
        public void saveplayer()
        {
            PlayerPrefs.SetInt("diamand", this.diamands);
            PlayerPrefs.SetInt("score", this.coins);
        }
        public void getplayer()
        {
            diamands = PlayerPrefs.GetInt("diamand");
            coins = PlayerPrefs.GetInt("score");
        }
        public void getacheves()
        {
            string cmd = String.Format(@"SELECT 
                sum(cast(starts as decimal)),
                sum(cast(crowns as decimal))
            FROM 
                songScore");
            // List<song> songlist = new List<song>();
            IDataReader songData = ExecuteReadCMD(cmd);
            while (songData.Read())
            {
                int.TryParse(songData[0].ToString(), out stars);
                int.TryParse(songData[1].ToString(), out crowns);
            }
        }
        public List<song> GetSongs()
        {
            string cmd = String.Format(@"SELECT 
                song.id,
                song.title,
                song.desc,
                song.url,
                song.genre,
                song.price,
                song.currency,
                song.duration,
                max(cast(songScore.starts as decimal)) as stars,
                max(cast(songScore.crowns as decimal)) as crowns,
                song.owned,
                song.speed,
                song.liked,
                song.filePath
            FROM 
                song
                Left JOIN songScore ON (songScore.songID = song.id)
            Group By song.id");
            List<song> songlist = new List<song>();
            IDataReader songData = ExecuteReadCMD(cmd);
            while (songData.Read())
            {
                song sg = new song();
                sg.id = songData.GetInt32(0);
                sg.title = songData[1].ToString();
                sg.desc = songData[2].ToString();
                sg.url = songData[3].ToString();
                switch (songData[4].ToString())
                {
                    case "Soundtrack":
                        sg.genre = SongGenre.Soundtrack;
                        break;
                    case "HipHop":
                        sg.genre = SongGenre.HipHop;
                        break;
                    default:
                        sg.genre = SongGenre.Instrumental;
                        break;
                }
                // Debug.Log(songData[4].ToString());
                sg.price = double.Parse(songData[5].ToString());
                switch (songData[6].ToString())
                {
                    case "coin":
                        sg.currency = currency.coin;
                        break;
                    default:
                        sg.currency = currency.diamand;
                        break;
                }
                sg.duration = double.Parse(songData[7].ToString());
                int.TryParse(songData[8].ToString(), out sg.stars);
                int.TryParse(songData[9].ToString(), out sg.crowns);
                bool.TryParse(songData[10].ToString(), out sg.owned);
                float.TryParse(songData[11].ToString(), out sg.speed);
                bool.TryParse(songData[12].ToString(), out sg.liked);
                sg.filePath = songData[13].ToString();
                songlist.Add(sg);
            }
            return songlist;
        }

        public List<album> GetAlbums()
        {
            string cmd = String.Format(@"select id,name,price,thumbnail
            from album");
            List<album> albumlist = new List<album>();
            IDataReader songData = ExecuteReadCMD(cmd);
            while (songData.Read())
            {
                album sg = new album();
                sg.id = songData.GetInt32(0);
                sg.name = songData[1].ToString();
                sg.price = float.Parse(songData[2].ToString());
                sg.thumbnail = songData[3].ToString();
                albumlist.Add(sg);
            }
            return albumlist;
        }

        public List<song> GetSongsAlbum(int albumID)
        {
            string cmd = String.Format(@"select id,name,url,thumbnail,price,duration
                                        from song,albumsongs
                                        where song.id = albumsongs.songID 
                                        and albumsongs.albumID = {0}", albumID);
            List<song> songlist = new List<song>();
            IDataReader songData = ExecuteReadCMD(cmd);
            while (songData.Read())
            {
                song sg = new song();
                sg.id = songData.GetInt32(0);
                sg.title = songData[1].ToString();
                sg.url = songData[2].ToString();
                switch (songData[3].ToString())
                {
                    case "Soundtrack":
                        sg.genre = SongGenre.Soundtrack;
                        break;
                    case "HipHop":
                        sg.genre = SongGenre.HipHop;
                        break;
                    default:
                        sg.genre = SongGenre.Instrumental;
                        break;
                }
                sg.price = double.Parse(songData[4].ToString());
                sg.duration = double.Parse(songData[5].ToString());
                songlist.Add(sg);
            }
            return songlist;
        }

        public List<songScore> GetSongScores()
        {
            string cmd = String.Format(@"select songScore.id,songScore.songID,score,date,sMax.bestScore,starts,crowns
                    from songScore
                    left join 
                    (select songID,id,max(cast(score as decimal)) as bestScore
                    from songScore group by songID) sMax
                    ON songScore.songID = sMax.songID");
            List<songScore> songScorelist = new List<songScore>();
            IDataReader songData = ExecuteReadCMD(cmd);
            while (songData.Read())
            {
                songScore sg = new songScore();
                sg.id = songData.GetInt32(0);
                sg.songID = int.Parse(songData[1].ToString());
                sg.score = int.Parse(songData[2].ToString());
                DateTime.TryParse(songData[3].ToString(), out sg.date);
                // DateTime.TryParse( songData[3].ToString(),out sg.date);
                sg.bestScore = int.Parse(songData[4].ToString());
                int.TryParse(songData[5].ToString(), out sg.starts);
                int.TryParse(songData[6].ToString(), out sg.crowns);
                songScorelist.Add(sg);
            }
            return songScorelist;
        }

        public List<archive> GetArchive()
        {
            string cmd = String.Format(@"SELECT 
                    song.title,
                    song.desc,
                    songScore.date,
                    songScore.starts,
                    songScore.crowns,
                    songScore.score
                FROM 
                    song
                    INNER JOIN songScore ON (song.id = songScore.songID)    
                ORDER BY 
                    songScore.id Desc");
            List<archive> songScorelist = new List<archive>();
            IDataReader songData = ExecuteReadCMD(cmd);
            while (songData.Read())
            {
                archive sg = new archive();
                // sg.id = songData.GetInt32(0);
                sg.name = songData[0].ToString();
                sg.author = songData[1].ToString();
                DateTime.TryParse(songData[2].ToString(), out sg.date);
                int.TryParse(songData[3].ToString(), out sg.stars);
                int.TryParse(songData[4].ToString(), out sg.crowns);
                int.TryParse(songData[5].ToString(), out sg.score);
                songScorelist.Add(sg);
            }
            return songScorelist;
        }

        public System.Collections.Generic.IEnumerable<song> getfavs()
        {
            return from song in songs where song.liked == true select song;
        }

        public void updateLikeSong(song _song)
        {
            string cmd = String.Format(@"update song set liked = '{0}' where id = '{1}'",
                         _song.liked, _song.id);
            ExecuteCMD(cmd);
        }
        public void updateOwnedSong(song _song)
        {
            string cmd = String.Format(@"update song set owned = '{0}' where id = '{1}'",
                         _song.owned, _song.id);
            ExecuteCMD(cmd);
        }
        public void updateFilePathSong(song _song)
        {
            string cmd = String.Format(@"update song set filePath = '{0}' where id = '{1}'",
                         _song.filePath, _song.id);
            ExecuteCMD(cmd);
        }
    }
}