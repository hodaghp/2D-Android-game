using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

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
    private void Update()
    {
        if (gameLog.coins > 2 && gameLog.astroidDestoried >= 1)
        {
            gameController.Win();
        }
    }
    #endregion
}
