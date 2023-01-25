using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonLevelController : MonoBehaviour {

    #region Public Variables
    public Image lockImage;
    public Text txtLevelNumber;

    #endregion

    #region Private Variables
    private bool isOpen;
    private int number;
    #endregion

    #region Public Methods
    public void Init(int num,bool open)
    {
        isOpen = open;
        if (isOpen)
        {
            txtLevelNumber.gameObject.SetActive(true);
            lockImage.gameObject.SetActive(false);
            txtLevelNumber.text = (num + 1).ToString();
            number = num;
            
        }
        else
        {
            txtLevelNumber.gameObject.SetActive(false);
            lockImage.gameObject.SetActive(true);
        }
    }

    public void Click()
    {
        if (isOpen)
        {
            // open the level
            string sceneName = "level " + number;
            SceneManager.LoadScene(sceneName);
        }
    }

    #endregion

    #region Private Methods
    #endregion
}
