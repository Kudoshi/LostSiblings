using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenController : MonoBehaviour
{
    private Image screen;
    public float fadeInDuration;
    public float fadeOutDuration;
    void Start()
    {
        gameObject.SetActive(true);
        screen = gameObject.GetComponent<Image>();
        StartCoroutine(FadeImage(true));
       // gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        //Events.onLinkBreak += LinkBreak;
    }
    private void OnDisable()
    {
        //Events.onLinkBreak -= LinkBreak;
    }
    private void LinkBreak()
    {
        Invoke("FadeOut", 2.5f);
    }
    private void FadeOut()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeImage(false));
    }
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = fadeOutDuration; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                screen.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= fadeInDuration; i += Time.deltaTime)
            {
                // set color with i as alpha
                screen.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
