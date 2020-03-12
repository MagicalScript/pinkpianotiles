namespace DataBank
{
    public static class Query
    {
        #region DATAQuery
        public static string DATAQuery = @"INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/rysktchkw/piano-work-02','Piano Work',50,4,'true','true','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/sei_peridot/piano-melancholy','Piano Melancholy',50,4,'true','true','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/seanporteousmusic/piano-and-guitar-heaven','Heaven',100,4,'true','true','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/usernametakenn/lany-ilysb-piano-cover','ILYSB',100,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('HipHop','https://soundcloud.com/joakimkarud/piano-sax','Piano & Sax',400,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/lady-gaga-always-remember-us-this-way-from-a-star-is-born-piano-instrumental-cover','ALWAYS REMEMBER US THIS WAY ',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/lady-gaga-bradley-cooper-shallow-a-star-is-born-piano-instrumental-cover','SHALLOW ',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/myuu/bloody-tears-piano-version-castlevania-cover','Bloody Tears',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/iwproduction/nighttime-birds-jazz-electronic-soundtrack-ambient-atmospheric-piano','Nighttime Birds',550,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/fleetwood-mac-landslide-piano-instrumental-cover','LANDSLIDE ',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('HipHop','https://soundcloud.com/n3beats/hip-hop-piano-instrumental','Hip-Hop Piano Instrumental',700,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/adele-hello-piano-instrumental-cover','Hello',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/naoya-sakamata/meaning-of-lifespan-emotional-piano-eurobeat','Meaning Of Lifespan',550,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/lionel-richie','ENDLESS LOVE',3,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/ed-sheeran-perfect-piano-instrumental-cover','PERFECT ',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/ellie-goulding-love-me-like-you-do-piano-instrumental-cover','Love me like you do',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/jonathan-rich/piano-theme','Piano Theme',450,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/billy-joel-shes-always-a-woman-piano-cover','SHE''S ALWAYS A WOMAN ',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/wiz-khalifa-see-you-again-piano-instrumental-cover','See you again',5,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/adele-all-i-ask-piano-instrumental-cover','All I ask',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/sweetwaveaudio/little-romantic-piano-free','Little Romantic Piano',450,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/glen-hansard-falling-slowly','Falling slowly',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/adele-when-we-were-young-piano-instrumental-cover','When we were young',5,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('HipHop','https://soundcloud.com/sharongabrieli/high-and-low-cinematic-epic-soundtrack-music-by-sharon-gabrieli-music-production','High and Low',500,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/disney-the-lion-king-can-you-feel-the-love-tonight-piano-instrumental-cover','Can you feel the love tonight',200,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/bethurner/un-owen-was-here-instrumental-guitar-piano-and-drums','UN Owen Was Here',450,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/van-morrison-have-i-told-you','Have I told you',5,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/ed-sheeran-photograph-piano-instrumental-cover','Photograph',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/disney-tarzan-youll-be-in-my-heart-piano-instrumental-cover','You''ll be in my heart',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/iuli-mai-mimimi/fine-weather-ambient-piano-instrumental','FINE WEATHER',450,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/sia-chandelier-piano-instrumental-cover','Chandelier',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('HipHop','https://soundcloud.com/plutotracks/better-hip-hop-beat-piano-and-guitar-instrumental-chill-ambient-relaxing-background-music','BETTER ',700,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/disney-the-little-mermaid-part-of-your-world-piano-instrumental-cover','Mermaid part of your world',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/jessie-j-flashlight-piano-instrumental-cover','Flashlight',10,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/ronaldkah/piano-beat','Piano beat',450,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/beatles-here-comes-the-sun','HERE COMES THE SUN',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/adele-someone-like','Someone like you',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/charlie-puth-one-call-away-piano-instrumental-cover','One call away',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/pocahontas-colours-of-the-wind-piano-instrumental-cover','Colours of the wind',10,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('HipHop','https://soundcloud.com/cjonthebeat/free-rap-hip-hop-piano-instrumental-beat-focus-free-rap-instrumentals','Focus',700,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/prince-purple-rain-piano-instrumental-cover','PURPLE RAIN',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/alcaknight/forgotten-voices','Forgotten Voices',450,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/eng-reemo/a-song-from-a-secret-garden','A Song From A Secret Garden',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/disney-tangled-i-see-the-light-piano-instrumental-cover','I see the light',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/adele-to-make-you-feel-my-love-piano-instrumental-cover','To make you feel my love',20,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/naoya-sakamata/until-that-time-emotional-piano-instrumental','until that time',450,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/coldplay','PARADISE',250,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('HipHop','https://soundcloud.com/plutotracks/pluto-tracks-beach-chill-hip-hoprb-piano-instrumental','Beach ',700,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/disney-aladdin-a-whole-new-world-piano-instrumental-cover','A whole new world',15,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/coldplay-everglow-piano-instrumental-cover','Everglow',400,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/aries4rce/blurred','Blurred',550,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/sara-bareilles-gravity-piano-instrumental-cover','Gravity',400,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/robbie-williams-angels-piano','Angels',400,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('HipHop','https://soundcloud.com/user-290367978/free-sad-piano-smooth-hip-hop-instrumental-beat54-dreary','Beat54',20,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/kongsingwei/let-me-love-you-mario-piano','Let me love you',400,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/itspaolopv/want-you-gone-piano-cover','Want you gone',550,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/adele-remedy-piano-instrumental-cover','Remedy',400,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/phil-collins-another-day-in-paradise','Another day in paradise',30,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/nathan-sykes-over-and-over-again-piano-instrumental-cover','Over and over again',700,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/unseenmusic/upliftingpianoacousticepic-boyextended-version','Boy',550,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/finding-nemo-nemo-egg-piano-instrumental-cover','NEMO EGG',700,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/ben-folds-the-luckiest','THE LUCKIEST',700,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/strange-day/piano','Piano',35,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/josh-groban-the-prayer','The prayer',800,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/inceptofficial/droeloe-sunburn-piano-cover-midi','Sunburn ',800,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/pianocurve/garageband-bob1-apples-mp3','Cheerful tune',550,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('HipHop','https://soundcloud.com/user-290367978/free-hip-hop-instrumental-beat47-piano','Beat47',700,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/bennymartinpianist/sia-helium-piano-instrumental-cover','helium',40,4,'FALSE','FALSE','diamand');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Instrumental','https://soundcloud.com/geekygeek/give-me-everything-piano-cover','Give me everything',800,4,'FALSE','FALSE','coin');

                INSERT INTO song (genre, url, title, price, speed, liked, owned, currency)
                VALUES ('Soundtrack','https://soundcloud.com/pianocurve/garageband-alt1-apple','Galaxy',550,4,'FALSE','FALSE','coin');";
    }
        #endregion


}