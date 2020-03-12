using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class downloadInterface : MonoBehaviour
{
    public Text persantageText;
    public Image persantageImage;

    private YieldInstruction fadeInstruction = new YieldInstruction();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fillprgress(persantageImage, persantageText));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator fillprgress(Image progressImage, Text progreetext)
    {
        float elapsedTime = 0.0f;
        // Color c = image.color;
        while (elapsedTime < .95f)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime / 8;
            progressImage.fillAmount = elapsedTime;
            string s = (elapsedTime * 100).ToString();
            // Debug.Log(s.Substring(0,s.Length >= 2 ? 2 : s.Length));
            progreetext.text = s.Substring(0,s.Length >= 2 ? 2 : s.Length);
        }
        // background2.sprite = oldSprite;
    }
}
