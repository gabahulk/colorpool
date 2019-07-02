using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorBallScript : MonoBehaviour
{
    private ParticleSystem ps;
    public Color ballColor;

    void Awake()
    {
        this.GetComponent<SpriteRenderer>().color = ballColor;
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = ballColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ps.Play();
            var color = this.GetComponent<SpriteRenderer>().color;
            color.a = 0;
            collision.gameObject.GetComponent<BallScript>().SetBallColor(ballColor);
            this.GetComponent<Collider2D>().enabled = false;
            iTween.Pause(gameObject);
            this.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
