using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Variables para las fisicas
    [SerializeField] Rigidbody2D rigidbody2d;
    Vector2 moveDirection;
    Vector2 currentVelocity;
    [SerializeField] float speed = 3;
    GameManager gameManager;
    // Variables efectos sonido
    [SerializeField] AudioClip paddleBounce;
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
        
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void FixedUpdate()
    {
        currentVelocity = rigidbody2d.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidbody2d.velocity = moveDirection;

        if (collision.transform.CompareTag("DeathLimit")) {
            Debug.Log("Colision con el limite bajo");
            if (gameManager != null) {
                gameManager.PlayerLives--;
            }
        }

        if (collision.transform.CompareTag("Player")) {
            FindObjectOfType<AudioController>().PlatSfx(paddleBounce);
        }
    }

    public void LaunchBall() {
        transform.SetParent(null);
        rigidbody2d.velocity = Vector2.up * speed;
    }

    public void ResetBall() {
        rigidbody2d.velocity = Vector3.zero;
        Transform paddle = GameObject.Find("Paddle").transform;
        transform.SetParent(paddle);

        Vector2 ballPosition = paddle.position;
        ballPosition.y += 0.3f;
        transform.position = ballPosition;

        gameManager.BallOnPlay = false;
    }
}
