using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rb2D;
    public float speed = 1f;
    public Vector2 vsl;

    public int leftPlayerScore = 0;
    public int rightPlayerScore = 0;

    public TextMeshProUGUI leftPlayerText;
    public TextMeshProUGUI rightPlayerText;

    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

        ResetBall();
        SendBallToRandomDirection();

        leftPlayerText.text = "0";
        rightPlayerText.text = "0";
        
    }

    void Update()
    {

        if (rb2D.velocity.magnitude < .1f && Input.GetKeyUp(KeyCode.Space))
        {
            SendBallToRandomDirection();
        }


    }


    private void ResetBall()
    {

        rb2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;

    }

    private void SendBallToRandomDirection()
    {

        rb2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
        vsl = rb2D.velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        rb2D.velocity = Vector2.Reflect(vsl, collision.contacts[0].normal);
        vsl = rb2D.velocity;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (transform.position.x < 0)
        {
            rightPlayerScore += 1;

        }


        if (transform.position.x > 0)
        {
            leftPlayerScore += 1;

        }


        leftPlayerText.text = leftPlayerScore.ToString();
        rightPlayerText.text = rightPlayerScore.ToString();
        ResetBall();
        //SendBallToRandomDirection();

    }

}
