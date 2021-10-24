using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    private int scoreValue = 0;
    private int Lives = 3;
    private int level2;
    public int Grounded;
    private SpriteRenderer mySpriteRenderer;

    public float speed;
    public Text score;
    public Text lives;
    public Text wintext;
    public AudioSource musicSource;
    public AudioClip NormalMusic;
    public AudioClip WinNoise;

    Animator anim;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Score: " + scoreValue.ToString();
        lives.text = "Lives: " + Lives.ToString();
        level2 = 2;
        musicSource.clip = NormalMusic;
        musicSource.Play();
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            {
                Application.Quit();
            }

        if (Grounded == 3)
        {
            anim.SetInteger("State", 2);
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("State", 1);
                mySpriteRenderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("State", 1);
                mySpriteRenderer.flipX = false;
            }
            else
            {
                anim.SetInteger("State", 0);
            }
        }
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        rd2d.AddForce(new Vector2(hozMovement * speed, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if (scoreValue == 4 & level2 == 2)
            {
                rd2d.transform.position = new Vector2(0, 0);
                Lives = 3;
                lives.text = "Lives: " + Lives.ToString();
                level2 = 3;
            }
            if (scoreValue >= 8)
            {
                wintext.text = "You win! Game created by Noah McArthur";
                musicSource.clip = WinNoise;
                musicSource.Play();
            }
        }

        if (collision.collider.tag == "Enemy")
        {
            Lives -= 1;
            lives.text = "Lives: " + Lives.ToString();
            Destroy(collision.collider.gameObject);
            if (Lives <= 0)
            {
                Destroy(gameObject);
                wintext.text = "You Lose!";
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
                Grounded = 3;
            }
            else
            {
                Grounded = 2;
            }
        }
        if (collision.collider.tag == "Walls")
        {
            Grounded = 2;
        }
    }
}