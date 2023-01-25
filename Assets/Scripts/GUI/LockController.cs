using UnityEngine;
using System.Collections;

public class LockController : MonoBehaviour {

    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private Animator anim;
    private bool isEnable;
    #endregion

    #region Public Methods
    public void SetStatus(bool s)
    {
        if (s == true) Enable();
        else Disable();
    }
    public void Enable()
    {
        isEnable = true;
        anim.SetBool("isEnable", isEnable);
    }
    public void Disable()
    {
        isEnable = false;
        anim.SetBool("isEnable", isEnable);
    }
    #endregion

    #region Private Methods
    #endregion
}
