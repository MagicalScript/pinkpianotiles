using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class touchTile : MonoBehaviour
{
    Vector3 touchPosWorld;
    public float SPEED = 6.5f;
    public float backTimer = 0.5f;
    public ParticleSystem glassEffect;
    public ParticleSystem CoolEffect;
    bool tileScaped = false;
    public Text scoreText;
    public Text scoreOnlinePlayerText;
    public GameObject PlayBtn;
    public bool playing = false;
    public SpriteRenderer background1;
    public SpriteRenderer background2;
    public List<Sprite> spriteList;
    float timer = 0;
    Sprite oldSprite;
    int spriteIndex = 0;

    float fadeTime = 2;
    float backgroundChangeTime = 20;
    private YieldInstruction fadeInstruction = new YieldInstruction();

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;

    public void playBtn()
    {
        PlayBtn.SetActive(false);
        playing = true;
    }
    void Update()
    {
        if (timer < backgroundChangeTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spriteIndex = spriteIndex > spriteList.Count - 1 ? 0 : spriteIndex + 1;
            // background2.sprite = oldSprite;
            background2.color = new Color(255, 255, 255, 255);
            background1.sprite = spriteList[spriteIndex];
            // background2.sprite = spriteList[1];
            oldSprite = spriteList[spriteIndex];
            // background2.material.DOFade(0, 20f)
            // .OnComplete(() =>
            // {
            //     background2.sprite = oldSprite;
            // });
            StartCoroutine(FadeOut(background2));
        }

        if (!playing)
            return;

        if (tileScaped && backTimer > 0)
        {
            SPEED = -2;
            backTimer -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + SPEED * Time.deltaTime, -10);
        }
        else if (backTimer <= 0)
        {
            SPEED = 0;
            SceneManager.LoadScene("GameEnd");
            DataBank.playerDATA.Instance.saveSongScore(DataBank.playerDATA.currentSong.id,
                                                            DataBank.playerDATA.currentSong.diamand,
                                                            DataBank.playerDATA.currentSong.score,
                                                             DataBank.playerDATA.currentSong.starts,
                                                              DataBank.playerDATA.currentSong.starts < 4 ? 0 : DataBank.playerDATA.currentSong.starts - 3);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + SPEED * Time.deltaTime, -10);

            //We check if we have more than one touch happening.
            //We also check if the first touches phase is Ended (that the finger was lifted)
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
            {
                // Debug.Log("touche");
                //We transform the touch position into word space from screen space and store it.
                touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                //We now raycast with this information. If we have hit something we can process it.
                RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                if (hitInformation.collider != null)
                {
                    //We should have hit something with a 2D Physics collider!
                    GameObject touchedObject = hitInformation.transform.gameObject;
                    //touchedObject should be the object someone touched.
                    // Debug.Log("Touched " + touchedObject.transform.name);
                    DataBank.playerDATA.currentSong.score += 1;
                    scoreText.text = DataBank.playerDATA.currentSong.score.ToString();
                    scoreOnlinePlayerText.text = DataBank.playerDATA.currentSong.score.ToString();
                    glassEffect.Play();
                    CoolEffect.Play();
                }
            }
            // this for mouse
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero);

                if (cubeHit)
                {
                    // Debug.Log("We hit " + cubeHit.collider.name);
                    if (cubeHit.collider.gameObject.tag == "tile")
                    {
                        cubeHit.collider.gameObject.GetComponent<tile>().cubeHited = true;
                        DataBank.playerDATA.currentSong.score += 1;
                        scoreText.text = DataBank.playerDATA.currentSong.score.ToString();
                        scoreOnlinePlayerText.text = DataBank.playerDATA.currentSong.score.ToString();
                        glassEffect.Play();
                        CoolEffect.Play();
                        // Debug.Log("DataBank.playerDATA.currentSong.score " + DataBank.playerDATA.currentSong.score);
                    }
                    else if (cubeHit.collider.gameObject.tag == "obstacle")
                    {
                        SPEED = 0;
                        playing = false;
                        // cubeHit.collider.gameObject.GetComponent<tile>().setRedTile();
                        StartCoroutine(wrongtiletapped(cubeHit.collider.gameObject));

                    }
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == "tile")
        {
            // Debug.Log(o.gameObject.name);
            var v = o.gameObject.GetComponent<tile>();
            if (!v.cubeHited)
                tileScaped = true;
            else
                itsInside.eatedTiles--;
            // Debug.Log(itsInside.eatedTiles);            

        }
    }

    IEnumerator FadeOut(SpriteRenderer image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
        background2.sprite = oldSprite;
    }
    IEnumerator FadeIn(Image image)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
    }
    IEnumerator wrongtiletapped(GameObject obstacle)
    {
        float elapsedTime = 0.0f;
        float loopTime = 0.1f;
        obstacle.GetComponent<tile>().setRedTile();
        // Color c = image.color;
        while (elapsedTime < 1)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            loopTime -= Time.deltaTime;
            if (loopTime <= 0)
            {
                obstacle.GetComponent<tile>().setRedTile();
                loopTime = 0.1f;
            }
            // c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            // image.color = c;
        }
        // background2.sprite = oldSprite;
        DataBank.playerDATA.Instance.saveSongScore(DataBank.playerDATA.currentSong.id,
                                                        DataBank.playerDATA.currentSong.diamand,
                                                        DataBank.playerDATA.currentSong.score,
                                                         DataBank.playerDATA.currentSong.starts,
                                                          DataBank.playerDATA.currentSong.starts < 4 ? 0 : DataBank.playerDATA.currentSong.starts - 3);
        SceneManager.LoadScene("GameEnd");
    }
}