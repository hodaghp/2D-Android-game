using UnityEngine;
using System.Collections;
public enum BulletDirection
{
    UP,
    DOWN
}
public class BulletController : MonoBehaviour {

    #region Public Variables
    public float speed;
    public BulletDirection direction;
    public GameObject explosionPrefab;
    public int power;
    public Sprite[] sprites; //this is for coloring bullets
    #endregion

    #region Privatte Variables
    private Vector3 move = Vector3.down;
    [SerializeField] // for access and improve speed of game bc bullets obj are too many...
    private SpriteRenderer spRenderer; //for getting component
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        spRenderer.sprite = sprites[Random.Range(0,sprites.Length - 1)];
        if (direction == BulletDirection.DOWN)
        {
            move = Vector3.down;
        }
        else
        {
            move = Vector3.up;
        }
    }
    private void Update()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);

    }
    //col is asteroids
    private void OnCollisionEnter2D(Collision2D col)
    {
        //if(col.gameObject.name != "Spaceship")
        //{          
        //}
        Instantiate(explosionPrefab, col.contacts[0].point, Quaternion.identity); // creat animation
        //Destroy(col.gameObject); //Destroying Astroids depend on its health
        Destroy(gameObject);

    }
    #endregion
}
