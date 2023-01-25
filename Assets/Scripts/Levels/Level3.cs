using UnityEngine;
using System.Collections;

public class Level3 : MonoBehaviour {

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
        if (gameLog.coins > 15 && gameLog.astroidDestoried >= 10 && gameLog.motherEnemyShipDestroyed >= 1)
        {
            gameController.Win();
        }
    }
    #endregion
}
