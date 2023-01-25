using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour {

    #region Public Variables
    public GameObject joyStickButton;
    public GameObject fireButton;
    #endregion

    #region Private Variables
    private ShipController ship;
    #endregion

    #region Public Methods
    public void Fire()
    {
        ship.FireBullet();
    }

    public void MoveUp()
    {
        ship.MoveUp();
    }
    public void MoveRight()
    {
        ship.MoveRight();
    }
    public void MoveDown()
    {
        ship.MoveDown();
    }
    public void MoveLeft()
    {
        ship.MoveLeft();
    }
    public void StopMoving()
    {
        ship.StopMoving();
    }
    //Attach will set ship on the script
    public void Attach(ShipController s)
    {
        ship = s;
        GUIActivator(true);

    }
    public void Detach()
    {
        ship = null;
        GUIActivator(false);

    }
    #endregion

    #region Private Methods
    private void GUIActivator(bool active)
    {
        joyStickButton.gameObject.SetActive(active);
        fireButton.SetActive(active);
    }

    private void Start()
    {
        if(ship == null)
        {
            GUIActivator(false);
        }
    }

    #endregion
}
