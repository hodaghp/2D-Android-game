using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour {

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
        if (gameLog.coins > 10 && gameLog.astroidDestoried == 10)
        {
            gameController.Win();
        }
    }
    #endregion
}
