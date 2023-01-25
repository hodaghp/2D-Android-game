using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpaceShipShopController : MonoBehaviour {

    #region Public Variables
    public Text txtCoins;
    public Text txtModel;
    public GameObject pnlSpeed;
    public GameObject pnlHealth;
    public Text txtGunType;
    public GameObject pnlFireRate;
    public GameObject pnlGunCount;
    public GameObject pnlBulletPower;
    public Text txtprice;
    public Image shipSprite;
    public GameObject btnSelect;
    public GameObject btnBuy;
    public GameObject btnAddCoins;
    public LockController lockController;
    [Header("Repositories")]//just for good looking in unity environment
    public CoinRepository coinRepo;
    public ShipRepository shipRepo;
    #endregion

    #region Private Variables
    private ShipStruct currentShip;
    private int i = 0;
    #endregion

    #region Public Methods
    public void NextShip()
    {
        i += 1;
        if(i >= shipRepo.shipCount)
        {
            i = 0;
        }
        currentShip = shipRepo.GetShipByIndex(i);
        UpdateInformation(currentShip);
    }
    public void PrevShip()
    {       
        i -= 1;
        if (i < 0)
        {
            i = shipRepo.shipCount - 1;
        }
        currentShip = shipRepo.GetShipByIndex(i);
        UpdateInformation(currentShip);
    }

    public void SelectShip()
    {
        shipRepo.SetCurrnetShip((int)currentShip.key);
    }

    public void BuyShip()
    {
        if (coinRepo.pop(currentShip.price))
        {
            shipRepo.ActiveNewShip((int)currentShip.key);
            UpdateButtons(false, currentShip.price, coinRepo.Get());
            UpdateCoins();
        }
    }

    public void AddCoin()
    {
        coinRepo.push(200);
        UpdateCoins();
        UpdateButtons(currentShip.isLocked, currentShip.price, coinRepo.Get());
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    #region Private Methods
    private void Start()
    {
        UpdateCoins();
        i = 0;
        currentShip = shipRepo.GetShipByIndex(i);
        UpdateInformation(currentShip);
    }
    private void UpdateCoins()
    {
        txtCoins.text = coinRepo.Get().ToString();
        currentShip = shipRepo.GetCurrentShip();
        UpdateInformation(currentShip);
    }
    private void UpdateInformation(ShipStruct ship)
    {
        txtModel.text = ship.model;
        shipSprite.sprite = ship.sprite;
        SetGunType(ship.bulletType);
        SetPrice(ship.price);
        InitializeBars(pnlHealth, ship.health);
        InitializeBars(pnlSpeed, ship.speed);
        InitializeBars(pnlFireRate, (int) (ship.fireRate * 10));
        InitializeBars(pnlGunCount, ship.guns);
        InitializeBars(pnlBulletPower, ship.bulletPower);
        UpdateButtons(ship.isLocked,ship.price,coinRepo.Get());
        lockController.SetStatus(ship.isLocked);
    }

    private void SetGunType(BulletType type)
    {
        switch (type)
        {
            case BulletType.Bomb:
                txtGunType.text = "KµM"; // بمب
                break;
            case BulletType.Leaser:
                txtGunType.text = "nqÃ²"; // لیزر
                break;
            case BulletType.Rocket:
                txtGunType.text = "S¨Hn"; // راکت
                break;
        }
    }

    private void UpdateButtons(bool isLocked,int price,int coins)
    {
        btnAddCoins.gameObject.SetActive(false);
        btnBuy.gameObject.SetActive(false);
        btnSelect.gameObject.SetActive(false);
        if(isLocked == true && coins >= price)
        {
            btnBuy.gameObject.SetActive(true); // ship is lock and player has enough money
        }
        else if (isLocked == true && coins < price)
        {
            btnAddCoins.gameObject.SetActive(true);
        }
        else if(isLocked == false)
        {
            btnSelect.gameObject.SetActive(true);
        }
    }

    private void SetPrice(int price)
    {
        if (price == 0)
        {
            txtprice.text = "·I«ÄHn"; // رایگان
        }
        else
        {
            txtprice.text = price.ToString();
        }
    }
    //bottom function is for Enable and Disable radio button's child
    private void InitializeBars(GameObject panel,int count) // count is health number
    {
        int childCount = panel.transform.childCount;
        int lastChildIndex = childCount - 1;
        //child sort is reverse in unity
        for (int i = lastChildIndex; i>= 0; i--)
        {
            count -= 1;
            RadioButtonManager child = panel.transform.GetChild(i).GetComponent<RadioButtonManager>();
            if (count >= 0)
            {
                child.Enable();
            }
            else child.Disable();
        }
        

            
    } 
    #endregion
}
