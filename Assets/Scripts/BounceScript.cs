using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public Vector3 scaleAmount;
    Vector3 originalScale;
    public float time;
    public iTween.EaseType easeType;

    private void Start()
    {
        originalScale = this.transform.localScale;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            iTween.ScaleBy(gameObject,
               iTween.Hash(
                "amount", scaleAmount,
                "time", time/3,
                "easeType", easeType,
                "oncomplete", "BounceDown",
                "oncompletetarget", gameObject
               )
           );
        }
    }

    private void BounceBack()
    {
        iTween.ScaleTo(gameObject,
            iTween.Hash(
                "scale", originalScale,
                "time", time/3,
                "easeType", easeType
            )
        );
    }

    private void BounceDown()
    {
        iTween.ScaleBy(gameObject,
            iTween.Hash(
                "amount", new Vector3(0.8f, 0.8f),
                "time", time / 3,
                "easeType", easeType,
                "oncomplete", "BounceBack",
                "oncompletetarget", gameObject
            )
        );

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            iTween.ScaleBy(gameObject,
                iTween.Hash(
                    "amount", scaleAmount,
                    "time", time / 3,
                    "easeType", easeType,
                    "oncomplete", "BounceDown",
                    "oncompletetarget", gameObject
                )
            );
        }
    }
}
