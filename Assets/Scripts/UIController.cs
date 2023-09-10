using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winnerPanel;
    [SerializeField] GameObject[] livesImg;
    [SerializeField] Text gameTimeText;
    [SerializeField] AudioClip buttonPress;
    [SerializeField] GameObject pauseMenu;

    public void ActivateLosePanel() { 
        losePanel.SetActive(true);
    }

    public void ActivateWinnerPanel(float gameTime) { 
        winnerPanel.SetActive(true);
        gameTimeText.text = "Game Time: " + Mathf.Floor(gameTime) + "s";
        Console.WriteLine("Sleep for 3 seconds.");
        Thread.Sleep(3000);
        // TODO: Despues de esperar los 3 segundos, llamamos a la escena del siguiente nivel
        // Hay que ver como poder llamar al siguiente nivel desde el nivel en el que nos encontramos
        // Para no tener que crear un metodo para cada nivel
    }

    public void RestartCurrentScene() {
        FindObjectOfType<AudioController>().PlaySfx(buttonPress);
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu() {
        FindObjectOfType<AudioController>().PlaySfx(buttonPress);
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

    public void PauseMenu() { 
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }

    public void Resume() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void ResetLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitGame() {
        Application.Quit();
    }

}
