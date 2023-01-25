using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {
    #region Public Variables
    #endregion

    #region Private Variables
    private GameObject[] objs;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Awake()
    {
        objs = findMusics();
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

  private  void Update()
    {
        objs = findMusics();
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
    }

   private GameObject [] findMusics()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        return objs;
    }
    #endregion
}
