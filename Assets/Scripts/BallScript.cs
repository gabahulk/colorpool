using UnityEngine;
using System.Collections;
using EZCameraShake;

public class BallScript : MonoBehaviour
{
    private Color playerColor;
    public Color startColor;

    public Rigidbody2D _rb;
    CircleCollider2D col;
    public SpriteRenderer _renderer;
    public int forceMultiplier = 50;
    public float deformationAmplitude = 0.3f;
    public float deformationDuration = 0.3f;
    public DottedLine dottedLine;
    Vector3 originalScale;

    Vector3 initialPosition;
    Vector2 touchStartPosition;
    public GameController gc;
    bool hasLaunched = false;

    public ParticleSystem ps;
    private ParticleSystem.MainModule main;

    int numberOfCollisions = 0;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        main = ps.main;
        SetBallColor(startColor);
    }

    public void SetBallColor(Color color)
    {
        playerColor = color;
        main.startColor = color;
        _renderer.color = playerColor;
    }

    public Color GetBallColor()
    {
        return playerColor;
    }

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        col = GetComponent<CircleCollider2D>();
        initialPosition = this.transform.position;
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (hasLaunched)
        {
            return;
        }
        dottedLine.DrawDottedLine(this.transform.position, this.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            touchStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 ballDirection = touchStartPosition - endPosition;

            float radius = 2.5f;
            if (ballDirection.SqrMagnitude() > 0.12f)
            {
                if ((ballDirection.sqrMagnitude) > radius)
                ballDirection = ballDirection.normalized * radius;

                var force = ballDirection.sqrMagnitude / radius;
                force = Mathf.Max(.2f, force);
                _rb.AddForce(force * forceMultiplier * ballDirection.normalized, ForceMode2D.Impulse);
                hasLaunched = true;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 ballDirection = (endPosition - touchStartPosition);

            // Keep it in a certain radius
            float radius = 2.5f;
            if ((ballDirection.sqrMagnitude) > radius)
                ballDirection = ballDirection.normalized * radius;

            ballDirection = (Vector2)this.transform.position - ballDirection;
            dottedLine.DrawDottedLine(this.transform.position, ballDirection);
        }
    }

    public void DestroySequence(bool win)
    {
        var color = this.GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0);
        ps.Play();
        StopBall();
        gc.EndGame(win);
    }

    public void StopBall()
    {
        _rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gc.gameEnded)
        {
            return;
        }
        CameraShaker.Instance.ShakeOnce(.3f,10f,.1f,.1f);

        numberOfCollisions++;
        var colPoint = collision.GetContact(0);
        Vector2 colisionDirection = colPoint.normal;
        colisionDirection.x = Mathf.Pow(colisionDirection.x, 2);
        colisionDirection.y = Mathf.Pow(colisionDirection.y, 2);
        if (colisionDirection.x > colisionDirection.y)
        {
            iTween.ScaleTo(gameObject, iTween.Hash("x", originalScale.x * (1- deformationAmplitude), "y", originalScale.y*(1 + deformationAmplitude), "time", deformationDuration));
            iTween.ScaleTo(gameObject, iTween.Hash("x", originalScale.x, "y", originalScale.y, "delay", deformationDuration, "time", deformationDuration));
        }
        else if(colisionDirection.y > colisionDirection.x)
        {
            iTween.ScaleTo(gameObject, iTween.Hash("x", originalScale.x * (1 + deformationAmplitude), "y", originalScale.y * (1 - deformationAmplitude), "time", deformationDuration));
            iTween.ScaleTo(gameObject, iTween.Hash("x", originalScale.x, "y", originalScale.y, "delay", deformationDuration, "time", deformationDuration));
        }

        if (numberOfCollisions == 7 )
        {
            gc.ShowReloadText();
        }
    }
}
