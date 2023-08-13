using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winnerPanel;
    [SerializeField] GameObject[] livesImg;
    [SerializeField] Text gameTimeText;

    public void ActivateLosePanel() { 
        losePanel.SetActive(true);
    }

    public void ActivateWinnerPanel(float gameTime) { 
        winnerPanel.SetActive(true);
        gameTimeText.text = "Game Time: " + Mathf.Floor(gameTime) + "s";
    }

    public void RestartCurrentScene() {
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
        
    public void UpdateUILives(byte currentLives) { 
        for (int i = 0; i < livesImg.Length; i++)
        {
            if(i >= currentLives)
            {
                livesImg[i].SetActive(false);
            }
        }
    }
}