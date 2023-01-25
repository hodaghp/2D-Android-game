using UnityEngine;
using System.Collections;

public class RadioButtonManager : MonoBehaviour {
    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private Animator anim;
    private bool isEnable = false;
    #endregion

    #region Public Methods
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
