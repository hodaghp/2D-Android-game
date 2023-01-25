using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    #region public Variables
    public Vector3 speed;//for rotion in 3 axis x,y,z
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Update()
    {
        transform.Rotate( speed * Time.deltaTime);
    }
    #endregion
}
