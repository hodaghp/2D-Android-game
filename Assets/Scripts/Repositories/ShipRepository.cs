using UnityEngine;
using System.Collections;

public enum ShipEnums
{
    Green1,
    Green2,
    Green3,
    Red1,
    Red2,
    Red3,
    Blue1,
    Blue2,
    Blue3
}
public enum BulletType
{
    Leaser,
    Rocket,
    Bomb
}
[System.Serializable]
public struct ShipStruct{
    public ShipEnums key;//types of ship
    public GameObject ship;//ship prefab
    [Range(1, 10)]
    public int speed;//speed of ship
    [Range(1, 10)]
    public int health;//health of ship
    [Range(1, 3)] //this make just 3 choice in unity
    public int guns;//count of guns
    [Range(1, 3)]
    public int bulletPower;//power of bulllets
    public string model;//the name of ship
    public BulletType bulletType;//type of bullets
    [Range(0.0f,1f)]
    public float fireRate;
    public int price;//price of ship
    public bool isLocked;
    public Sprite sprite;//sprite of spaceship

}
public class ShipRepository : MonoBehaviour {
    #region Public Variables
    public ShipStruct[] ships;
    public int shipCount { get { return ships.Length; } } // return length of shipStruct[]
    #endregion

    #region Private Variables
    private const string currentShipRepo = "currentShipRepo";
    private const string shipsRepos = "shipsRepo"; //numbers will save like 1450 and it's mean spaceship number1 is active but number2,3 is not active
    #endregion

    #region Const Variables
    #endregion

    #region Public Methods
    public ShipStruct GetCurrentShip()
    {
        int index = PlayerPrefs.GetInt(currentShipRepo);      
        ships[index].isLocked = IsShipActive(index);       
        return ships[index];
    }

    public ShipStruct GetShipByIndex(int i)
    {
        ships[i].isLocked = !IsShipActive(i);
        return ships[i];
    }

    public void SetCurrnetShip(int i)
    {
        PlayerPrefs.SetInt(currentShipRepo, i);
    }
    // after shopping new spaceship this function will called
    public void ActiveNewShip(int i)
    {
        string s = RetriveShips();
        s = s + i.ToString();
        SaveShips(s);
    }
    #endregion

    #region Private Methods
    private void Awake()
    {
        // int rnd = Random.Range(0, 9);
        // PlayerPrefs.SetInt(currentShipRepo, rnd);
        Init();
    }
    // this is for first time of play
    private void Init()
    {
        if (PlayerPrefs.HasKey(shipsRepos) == false)
        {
            SetCurrnetShip(0);
            string s = "0";
            SaveShips(s);
        }

    }
    private void SaveShips(string s)
    {
        PlayerPrefs.SetString(shipsRepos, s);
    }

    private string RetriveShips()
    {
        return PlayerPrefs.GetString(shipsRepos);
    }
    private bool IsShipActive(int i)
    {
        string s = PlayerPrefs.GetString(shipsRepos);
        //Debug.Log(s);
        if (s.Contains(i.ToString()))
        {
            return true;
        }
        else return false;
    }
    #endregion
}
