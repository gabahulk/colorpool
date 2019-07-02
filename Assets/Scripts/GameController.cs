using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float fadeDuration = 0.3f;
    public float fadeDelay = 0.1f;

    public List<GameObject> elements;
    public GameObject resetText;

    public bool gameEnded;

    private void ShuffleList<T>(ref List<T> list) {
        var count = list.Count;
        List<int> randomNumberGenerator = new List<int>(count);

        for (int i = 0; i < count; i++)
        {
            randomNumberGenerator.Add(i);
        }


        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, randomNumberGenerator.Count - 1);
            randomNumberGenerator.RemoveAt(randomIndex);
            var temp01 = list[randomIndex];
            var temp02 = list[i];
            list[i] = temp01;
            list[randomIndex] = temp02;
        }
    }

    private void Start()
    {
        //ShuffleList(ref elements);
        var totalDelay = -fadeDelay;
        foreach (var item in elements)
        {
            var color = item.GetComponent<SpriteRenderer>().color;
            totalDelay += fadeDelay;
            if (item.GetComponent<FadeScript>())
            {
                item.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
                item.GetComponent<FadeScript>().FadeIn(fadeDuration, totalDelay, iTween.EaseType.easeInCubic);
            }
        }
    }

    float _doubleTapTimeD;
 
    // Update is called once per frame
    void Update()
    {
        bool doubleTapD = false;
 
        #region doubleTapD
 
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time < _doubleTapTimeD + .3f)
            {
                doubleTapD = true;
            }
            _doubleTapTimeD = Time.time;
        }
 
        #endregion
 
        if (doubleTapD)
        {
            EndGame(false);
        }
    }

    IEnumerator WaitForAnimation(bool win)
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        if (win)
        {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
            GoToLevelLoader();
        }
        else
        {
            ReloadLevel();
        }
    }

    public void EndGame(bool win)
    {
        var totalDelay = -fadeDelay;
        for (int i = elements.Count-1; i >= 0; i--)
        {
            var item = elements[i];
            var color = item.GetComponent<SpriteRenderer>().color;
            totalDelay += fadeDelay;
            if (item.GetComponent<FadeScript>())
            {
                item.GetComponent<FadeScript>().FadeOut(fadeDuration, totalDelay, iTween.EaseType.easeInCubic);
            }
        }
        
        gameEnded = true;

        StartCoroutine("WaitForAnimation", win);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToLevelSelection()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void GoToLevelLoader()
    {
        SceneManager.LoadScene("LevelLoader");
    }

    public void ShowReloadText()
    {
        resetText.GetComponent<FadeScript>().FadeIn(fadeDuration, 0, iTween.EaseType.easeInOutBack);
    }
}
