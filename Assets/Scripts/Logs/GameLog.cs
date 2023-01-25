using UnityEngine;
using System.Collections;

public class GameLog : MonoBehaviour {

    #region Public Variables
    public int bulletShots;
    public int bulletOutOfBounds;
    public int bulletOnTarget;
    public int astroidDestoried;
    public int astroidCrossed;
    public int unitEnemyShipDestroyed;
    public int unitEnemyShipCrossed;
    public int motherEnemyShipDestroyed;
    public int motherEnemyShipCrossed;
    public int coins;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    public void AddBullet()
    {
        bulletShots += 1;
    }

    public void AddBulletOnTarget()
    {
        bulletOnTarget += 1;
    }

    public void AddBulletOutOfBounds()
    {
        bulletOutOfBounds += 1;
    }

    public void AddAstroiedDestroied()
    {
        astroidDestoried += 1;
    }
    public void AddAstroiedCrossed()
    {
        astroidCrossed += 1;
    }
    public void AddUnitEnemyShipDestroied()
    {
        unitEnemyShipDestroyed += 1;
    }
    public void AddUnityEnemyShipCrossed()
    {
        unitEnemyShipCrossed += 1;
    }
    public void AddUnitMotherShipDestroied()
    {
        motherEnemyShipDestroyed += 1;
    }
    public void AddUnitMotherShipCrossed()
    {
        motherEnemyShipCrossed += 1;
    }
    public void AddCoin()
    {
        coins += 1;
    }
    #endregion

    #region Private Methods
    #endregion
}
