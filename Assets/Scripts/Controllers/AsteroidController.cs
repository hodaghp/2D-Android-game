using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

    #region Public Variables
    public float speed;
    public float rotationSpeed;
    public int health;
    public GameObject explosionPrefab;
    public Sprite[] healthSprite;
    public GameObject coinSpawner;
    
    #endregion

    #region Private Variables
    private const string ANIMATION_NAME = "health";// this health is Animation parameter in Animator window
    private Animator anim;
    private SpriteRenderer spRender;
    private GameController gameControlle;
    private int initHealth;// this vgariable save initial health number to add it to score
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Awake()
    {
        
        initHealth = health;
        anim = GetComponent<Animator>();
        spRender = GetComponent<SpriteRenderer>();
        gameControlle = GameObject.FindObjectOfType<GameController>();
    }
    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
               
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "bullet_player") {
            health = health - col.gameObject.GetComponent<BulletController>().power;
        }
        else if(col.gameObject.tag == "Player")
        {
            //health = health - col.gameObject.GetComponent<ShipController>().Health;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        CheckHealth();
    }
    private void CheckHealth()
    {
        if (health <= 0)
        {
            gameControlle.AddScore(initHealth);
            gameControlle.AddDestroyedItems(gameObject.tag);
            //Debug.Log(gameObject.tag);
            int rnd = Random.Range(1, 3);
            if(rnd == 2) //after destroying asteroids if random number was 2 creat coins
            {
                Instantiate(coinSpawner, transform.position, Quaternion.identity);
            }
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            DoAnimationOrChangeSprite(); // this method says if you have animation component use of it and if you have not use changeSprite

        }
    }
    private void DoAnimationOrChangeSprite()
    {
        if(anim != null)
        {
            anim.SetInteger(ANIMATION_NAME, health);
        }
        else
        {
            changeSprite();
        }
    }
    private void changeSprite()
    {
        spRender.sprite = healthSprite[health-1];

    }
    #endregion
}
