using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private Animator anim;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        StartCoroutine(DestroyThis());
        
    }
    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length); //theis is return length of animation
        Destroy(gameObject); // animation will destroy
    }
    #endregion
}
