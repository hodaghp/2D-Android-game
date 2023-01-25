using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    #region public Variables
    public int Score { get { return score; }}
    public HUDTOPLEFTManager hudTopLeftManager;
    public HUDBulletManager hudBulletManager;
    public GameObject pauseButton;
    public CoinRepository coinRepo;
    public ScoreRepository scoreRepo;
    public ShipRepository shipRepos;
    public JoyStick joyStick;
    public WinGameOverPanelManager winGameOverPanel;
    public LevelRepository levelRepo;
    public GameLog gameLog;
    #endregion

    #region private Variables
    private int score;//score of player
    [SerializeField]
    private int bullet;//bullets
    private int coins = 0;//coins of player  that collect
    private int destroyedItems = 0;//number of destroyed items in this level 
    private ShipStruct ship;
    private int bulletOutOfBounds = 0;
    private ShipController shipController; //edited "added private"
    #endregion

    #region public Methods
    public int GetHealthPercent()
    {
        return shipController.GetHealthPercent();
    }
    public void Win()
    {
        if (winGameOverPanel.gameObject.activeInHierarchy == false)
        {
            coinRepo.push(coins);
            scoreRepo.push(score);
            levelRepo.OpenNextLevel();
            joyStick.Detach();
            hudBulletManager.Deactive();
            hudTopLeftManager.Deactive();
            pauseButton.SetActive(false);
            winGameOverPanel.gameObject.SetActive(true);
            winGameOverPanel.Init(true, score, GetBulletsOnTargetPercent(shipController.GetBulletFired()), destroyedItems, coins);
        }

    }
    public void GameOver(int numOfBullets)
    {
        coinRepo.push(coins);
        scoreRepo.push(score);
        joyStick.Detach();
        hudBulletManager.Deactive();
        hudTopLeftManager.Deactive();
        pauseButton.SetActive(false);
        //Debug.Log("Game Over");
        winGameOverPanel.gameObject.SetActive(true);
        winGameOverPanel.Init(false,score,GetBulletsOnTargetPercent(numOfBullets), destroyedItems,coins);
    }
    public void GameObjectDeactivator(GameObject ob)
    {
        if(ob.tag == "bullet_player"){

            bulletOutOfBounds += 1;
            gameLog.AddBulletOutOfBounds();
        }
        Destroy(ob.gameObject);
    }
    public void AddScore(int s)
    {
        if( s > 0)
        {
            score += s;
            hudTopLeftManager.SetScoreText(score);//whenever score changed call this method to edit scor txt
        }

    }
    public bool HasBullet()
    {
        if (bullet > 0) return true;
        else return false;
    }
    public void popBullet()
    {
        bullet = bullet - 1;
        hudBulletManager.SetBullet(bullet);
    }
    public void AddCoin()
    {
        coins += 1;
        gameLog.AddCoin();
    }
    public void AddDestroyedItems(string tag)
    {
        if(tag == "asteroid")
        {
            gameLog.AddAstroiedDestroied();
        }
        if(tag == "enemy_ship")
        {
            gameLog.AddUnitMotherShipDestroied();
        }
        destroyedItems += 1;
    }
    #endregion

    #region private Methods
    private void Start()
    {
        ship = shipRepos.GetCurrentShip();//return us shipStructure
        GameObject shipObject = (GameObject)Instantiate(ship.ship, Vector3.zero, Quaternion.identity);//this will creat ship at scene and will save at shipObject
        shipController = shipObject.GetComponent<ShipController>();
        shipController.Init(ship.speed, ship.fireRate, ship.health);
        joyStick.Attach(shipController);
        score = 0;
        //bullet = 100;
        coins = 0;
        destroyedItems = 0;
        hudTopLeftManager.SetScoreText(score);
        hudBulletManager.SetBullet(bullet);
        //Debug.Log("Last Score is: "+ scoreRepo.GetLastScore() + " High Score is: "+ scoreRepo.GetHighScore());
        winGameOverPanel.gameObject.SetActive(false); // this panel is hidden in the begining of game
    }
    private void Update()
    {
        //if(coins > 10 && destroyedItems >= 5)
        //{
        //    // for activating just once
        //    if (winGameOverPanel.gameObject.activeInHierarchy == false)
        //    {
        //        Win();
        //    }
        //}
        
    }
    //this function will save data of game with PlayerOrefs
    private void OnApplicationQuit() 
    {
        //coins += PlayerPrefs.GetInt("coin");
        //PlayerPrefs.SetInt("coin", coins);
        //coinRepo.push(coins);
        //scoreRepo.push(score);
        Debug.Log("Last score is: " + scoreRepo.GetLastScore() + " and High score is : " + scoreRepo.GetHighScore());
    }
    private int GetBulletsOnTargetPercent(int total)
    {
        float OnTarget = total - bulletOutOfBounds;
        float p = (OnTarget / total) * 100;
        int intp = (int)p;
        return Mathf.Clamp(intp,0,100);
    }
 
    #endregion
}
