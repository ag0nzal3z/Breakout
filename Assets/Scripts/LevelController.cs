using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{



    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void RestartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void RestartLevel3()
    {
        SceneManager.LoadScene("Level3");
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
