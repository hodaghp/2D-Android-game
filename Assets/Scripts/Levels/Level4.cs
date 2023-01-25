using UnityEngine;
using System.Collections;

public class Level4 : MonoBehaviour {

    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private GameLog gameLog;
    [SerializeField]
    private GameController gameController;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {

    }
    private void Update()
    {
        if (gameLog.coins > 25 && gameLog.astroidDestoried >= 15 && gameLog.motherEnemyShipDestroyed >= 1)
        {
            gameController.Win();
        }
    }
    #endregion
}
