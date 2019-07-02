using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadTextAnimation : MonoBehaviour
{
    public float enterTime;
    public float exitDelay;
    public float exitTime;
    public iTween.EaseType easeType;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        EnterAnimation();
    }

    void EnterAnimation()
    {
        iTween.MoveFrom(gameObject, iTween.Hash("position", new Vector3(transform.position.x, transform.position.y + 1280), "time", enterTime, "oncomplete", "MiddleAnimation", "onupdatetarget", gameObject, "easeType", easeType));
    }

    void MiddleAnimation()
    {
        iTween.MoveBy(gameObject, iTween.Hash("amount", new Vector3(0, 40), "time", 0.5, "oncomplete", "ExitAnimation", "oncompletetarget", gameObject, "easeType", iTween.EaseType.easeInOutBack));
    }

    void ExitAnimation()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position",new Vector3(transform.position.x, -1200),"time", exitTime, "delay", exitDelay, "easeType", easeType, "oncomplete", "LoadNextLevel", "oncompletetarget", canvas));
    }
}
