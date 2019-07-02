using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeScript : MonoBehaviour
{
    SpriteRenderer rend;
    Color startColor;
    private void Awake()
    {
        if (GetComponent<SpriteRenderer>())
        {
            rend = GetComponent<SpriteRenderer>();
            startColor = rend.color;
            startColor.a = 0;
            rend.color = startColor;
        }
        else if(GetComponent<Image>())
        {
            startColor = GetComponent<Image>().color;
            startColor.a = 0;
            GetComponent<Image>().color = startColor;
        }else if (GetComponent<TMP_Text>())
        {
            startColor = GetComponent<TMP_Text>().color;
            startColor.a = 0;
            GetComponent<TMP_Text>().color = startColor;
        }

    }
    public void FadeIn(float time,float delay, iTween.EaseType easetype)
    {
        var endColor = startColor;
        endColor.a = 1;
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("from", startColor);
        tweenParams.Add("to", endColor);
        tweenParams.Add("time", time);
        tweenParams.Add("delay", delay);
        tweenParams.Add("easetype", easetype);
        tweenParams.Add("onupdate", "OnColorUpdated");
 
        iTween.ValueTo(gameObject, tweenParams);
    }

    private void OnColorUpdated(Color color)
    {
        if (rend)
        {
            rend.color = color;
        }
        else if (GetComponent<Image>())
        {
            GetComponent<Image>().color = color;

        }
        else if (GetComponent<TMP_Text>())
        {
            GetComponent<TMP_Text>().color = color;
        }
    }

    public void FadeOut(float time, float delay, iTween.EaseType easetype)
    {
        var endColor = startColor;
        endColor.a = 0;
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("from", startColor);
        tweenParams.Add("to", endColor);
        tweenParams.Add("time", time);
        tweenParams.Add("delay", delay);
        tweenParams.Add("easetype", easetype);
        tweenParams.Add("onupdate", "OnColorUpdated");

        iTween.ValueTo(gameObject, tweenParams);
    }
}
