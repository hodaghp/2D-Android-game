using UnityEngine;
using System.Collections;

public class DeactivatorController : MonoBehaviour {

    #region Public Variables
    #endregion

    #region Private Variables
    private GameController gameController;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //whatever inter to trigger we report it to game controller
        gameController.GameObjectDeactivator(col.gameObject);
    }
    #endregion
}
