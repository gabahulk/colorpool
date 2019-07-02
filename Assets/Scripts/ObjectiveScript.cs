using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    public Color wallColor;
    private Color playerColor;

    void Awake()
    {
        this.GetComponent<SpriteRenderer>().color = wallColor;
        playerColor = GameObject.Find("PlayerBall").GetComponent<BallScript>().startColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<BallScript>().GetBallColor() != playerColor)
            {
                bool result = false;
                collision.gameObject.GetComponent<BallScript>().ps.Play();
                if (collision.gameObject.GetComponent<BallScript>().GetBallColor() == wallColor)
                {
                    // win!
                    result = true;
                }
                collision.gameObject.GetComponent<BallScript>().StopBall();
                collision.gameObject.GetComponent<BallScript>().DestroySequence(result);
            }
        }
    }
}
