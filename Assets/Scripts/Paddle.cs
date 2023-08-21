using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

    }



    // Variable para gestionar la velocidad de la pala
    [SerializeField] float speed = 5;
    // Variable para gestionar el limite de movimiento de la pala en el eje x
    [SerializeField] float xLimit = 7.0f;
    
    GameManager gameManager;

    // Update is called once per frame
    void Update()
    {    

        // Control del movimiento de la pala
        // Se usa el Tiempo Delta para que el movimiento sea igual en todos los hardware

        if (Input.GetKey(KeyCode.D) && transform.position.x < xLimit) {
            transform.position += Time.deltaTime * Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit)
        {
            transform.position += Time.deltaTime * Vector3.left * speed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.BallOnPlay == false)
            {
                gameManager.BallOnPlay = true;
            }
            if (gameManager.GameStarted == false)
            {
                gameManager.GameStarted = true;
            }
        }

        if (Input.GetKey(KeyCode.Escape)) {
            //Debug.Log("Salimos del juego");
            Application.Quit();
        }

    }
}
