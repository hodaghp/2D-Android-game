using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    public static bool gameIsPaused;
    public GameObject menu;

    public void pauseGame()
    {
        menu.SetActive(true);
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        //else
        //{
        //    Time.timeScale = 1;
        //}
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        gameIsPaused = !gameIsPaused;
        Time.timeScale = 1;
        menu.SetActive(false);
    }

}
