using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDBulletManager : MonoBehaviour {
    #region public Variables
    public Text txtBullet;
    public int dangerBulletCount;
    public Sprite blueSprite;
    public Sprite redSprite;
    public Image mainHud;
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
    public void SetBullet(int bullet)
    {
        txtBullet.text = bullet.ToString();
        if(bullet >= dangerBulletCount)
        {
            mainHud.sprite = blueSprite;
        }
        else
        {
            mainHud.sprite = redSprite;
        }
    }
    #endregion

    #region private Methods
    private void Start()
    {
        
        //txtBullet.text = Random.Range(20, 50).ToString();
    }
    #endregion
}
