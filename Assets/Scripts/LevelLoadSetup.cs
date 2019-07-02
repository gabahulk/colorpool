using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoadSetup : MonoBehaviour
{
    public TextMeshProUGUI tensNumber;
    public TextMeshProUGUI unitNumber;

    int animationsEnded = 0;

    // Start is called before the first frame update
    void Awake()
    {
        var level = PlayerPrefs.GetInt("Level",1);
        tensNumber.text = "" + Mathf.FloorToInt(level / 10);
        unitNumber.text = "" + (level%10);
    } 
    

    public void LoadNextLevel()
    {
        if (animationsEnded <= 0)
        {
            animationsEnded++;
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("Level", 1))
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));
            }
        }
    }
}
