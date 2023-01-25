using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    #region Public Variables
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    //for start Button
    public void StartGame()
    {
        SceneManager.LoadScene("LevelManager");
    }

    public void OpenLevelManager()
    {
        SceneManager.LoadScene("LevelManager");
    }
    public void SpaceShipShop()
    {
        SceneManager.LoadScene("SpaceShipShop");
    }
    #endregion

    #region Private Methods
    #endregion
}
