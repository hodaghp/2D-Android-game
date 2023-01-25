using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDTOPLEFTManager : MonoBehaviour {
    #region public Variables
    public Text txtHealthPercent;
    public Text txtScore;
    //public GameController gameController;
    //public int dangerHealthCount;
    public Sprite blueSprite;
    public Sprite redSprite;
    public Image mainImage;
    public GameController gameController;
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
    public void SetScoreText(int score)
    {
        txtScore.text = score.ToString();
    }

    #endregion

    #region private Methods
    private void Start()
    {
       
        //txtScore.text = Random.Range(100, 3000).ToString();

    }
    private void LateUpdate()
    {
        int healthPercent = gameController.GetHealthPercent();
        txtHealthPercent.text = healthPercent.ToString();
        if(healthPercent > 60)
        {
            mainImage.sprite = blueSprite;
        }
        else
        {
            mainImage.sprite = redSprite;
        }

    }
    #endregion
}
