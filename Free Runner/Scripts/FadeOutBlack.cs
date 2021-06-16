using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FadeOutBlack : MonoBehaviour
{
    public Image blackScreen;
    public float waitToFade = 2;
    public float fadeSpeed = 3;

    void Start()
    {
        
    }

    void Update()
    {
        if (waitToFade > 0)
        {
            waitToFade -= Time.deltaTime;
        }
        else
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
