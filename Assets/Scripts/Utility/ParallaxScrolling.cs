using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {
    #region Public Variables
    public Vector2 speed;
    #endregion

    #region Private Variables
    private Renderer myRender;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Awake()
    {
        myRender = GetComponent<Renderer>();
    }

    private void Update()
    {
        myRender.material.mainTextureOffset = Time.time * speed; //for moving stars
    }
    #endregion


}
