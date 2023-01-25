using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinGameOverPanelManager : MonoBehaviour {

    #region Public Variables
    public Text txtWinMessage;
    public Text txtScore;
    public Text txtAccuracy;
    public Text txtDestroyed;
    public Text txtCoin;
    public GameObject btnReply;
    public GameObject btnNext;
    public AudioClip startClip;
    public AudioClip btnReplyClip;
    public AudioClip btnMainMenueClip;
    #endregion

    #region Private Variables
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private LevelRepository levelRepo;
    #endregion

    #region Const Variables
    private string winMessage = "kÄk{ ½kºoM Iµ{ ! ¦ÄoLU"; //تبریک ! شما برنده شدید
    private string gameOverMessage = "! ¸¨ Â÷w ½nIM»j ): ÂTiIM";//باختی :( دوباره سعی کن ! 
    #endregion

    #region Public Methods
    public void Init(bool isWin,int score,int accuracy,int destroyed,int coins)
    {
        SetButtons(isWin);
        SetWinMessage(isWin);
        txtScore.text = score.ToString();
        txtAccuracy.text = accuracy.ToString() + " %";
        txtDestroyed.text = destroyed.ToString();
        txtCoin.text = coins.ToString();
        audioSource.PlayOneShot(startClip);
        
    }
    public void ReplayGame()
    {
        audioSource.PlayOneShot(btnReplyClip);
        Invoke("ReplyGameAfterSound",0.5f);
        // Application.LoadLevel(Application.loadedLevel); // load Scene with index 0
        // Debug.Log("Currently Level Load: " + Application.loadedLevelName);     
        //Application.LoadLevel("Level 01");

    }
    // nees
    public void NextLevel()
    {
        //some code for openning next level and then i should set sound for the btn
        audioSource.PlayOneShot(btnReplyClip);
        Invoke("NextLevelAfterSound", 0.5f);
    }
    public void MainMenu()
    {
        audioSource.PlayOneShot(btnMainMenueClip);
        Invoke("MainMenueAfterSound", 0.8f);
    }
    #endregion

    #region Private Methods
    private void ReplyGameAfterSound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    /// <summary>
    /// need edit
    /// </summary>
    private void NextLevelAfterSound()
    {
        int NextLevelIndex = SceneManager.GetActiveScene().buildIndex - 2;
       
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(NextLevelIndex);
        if (levelRepo.IsLocked(NextLevelIndex) == false)
        {
            levelRepo.OpenLevel(NextLevelIndex);
        }
        SceneManager.LoadScene("level "+ NextLevelIndex);
    }
    private void MainMenueAfterSound()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void SetWinMessage(bool isWin)
    {
        if (isWin == true)
        {
            txtWinMessage.text = winMessage;
        }
        else txtWinMessage.text = gameOverMessage;
    }
    private void SetButtons(bool isWin)
    {
        if (isWin)
        {
            //if player winned just display Next Level Button
            btnNext.SetActive(true);
            btnReply.SetActive(false);
            Destroy(btnReply);
            
        }
        else
        {
            btnReply.SetActive(true);
            btnNext.SetActive(false);
        }

    }
    #endregion

}
