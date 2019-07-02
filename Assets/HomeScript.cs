using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public List<FadeScript> fades;
    public float fadeTime;
    public float fadeDelay;
    // Start is called before the first frame update
    void Start()
    {
        var aux = 0;
        foreach (var item in fades)
        {
            item.FadeIn(fadeTime, aux *fadeDelay,iTween.EaseType.easeInCirc);
            aux++;
        }
    }

    public void FadeOut()
    {
        var aux = 0;
        foreach (var item in fades)
        {
            item.FadeOut(fadeTime, aux * fadeDelay, iTween.EaseType.easeInCirc);
            aux++;
        }
        StartCoroutine("WaitForAnimationAndLoad");
    }

    IEnumerator WaitForAnimationAndLoad()
    {
        yield return new WaitForSeconds(2);
        LoadLevelLoader();
    }

    void LoadLevelLoader()
    {
        SceneManager.LoadScene("LevelLoader");
    }
}
