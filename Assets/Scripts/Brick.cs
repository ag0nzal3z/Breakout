using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    //GameObject gameManagerObj;
    GameManager gameManager;

    void Start()
    {
        /*gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj == null) {
            Debug.Log("Objeto no encontrado");
        }
        else {
            gameManager = gameManagerObj.GetComponent<GameManager>();
            gameManager.bricksOnLevel++;
        }*/
        gameManager =FindObjectOfType<GameManager>();
        if( gameManager != null) {
            gameManager.BricksOnLevel++;
        }

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameManager != null) {
            gameManager.BricksOnLevel--;
        }

        Destroy(gameObject);
    }
}
