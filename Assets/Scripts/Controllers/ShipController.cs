using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
    #region public Variables  
    public GameObject bulletPrefab;
    public GameObject [] guns; //for location of bullets
    public int Health { get { return _health; } } // this property is for just reading _health variable without changing its value by other scripts.
    //public int InitHealth { get { return initHealth; } } //**********new**********
    public Animator flameAnimator;    
    #endregion

    #region private Variables
    private float speed; //speed of ship
    private float fireRate = 0;
    [SerializeField]
    private int _health;
    private float lastShot = 0;
    private const string FLAME_ANIMATION = "speed";
    private float h; // for horizontal axis
    private float v; // for vertical axis
    private GameController gameController;//refrence to GameController
    private int numOfBullets = 0;//number of bullets that Shooted by player
    private int initHealth; // it is fixed number and it's initial health
    #endregion

    #region public
    public int GetBulletFired()
    {
        return numOfBullets;
    }
    public void Init(float _speed,float _fireRate,int _h)
    {
        speed = _speed;
        fireRate = _fireRate;
        _health = _h;
        initHealth = _health;
    }
    public void FireBullet()
    {
        Fire();
    }
    public void MoveUp()
    {
        v = 1;
    }
    public void MoveDown()
    {
        v = -1;
    }
    public void MoveRight()
    {
        h = 1;
    }
    public void MoveLeft()
    {
        h = -1;
    }
    public void StopMoving()
    {
        v = 0;
        h = 0;
    }
    public int GetHealthPercent()
    {
        if (initHealth == _health) return 100;
        //float reminderHealth = initHealth - _health;
        float reminderHealth = _health;
        //Debug.Log(reminderHealth);
        float p = (reminderHealth / initHealth) * 100;
        return (int) p;
    }
    #endregion

    #region private Methods
    // Use this for initialization
    private void Start()
    {
        numOfBullets = 0;
        //initHealth = _health;
        //myTransform = GetComponent<Transform>();
        gameController = GameObject.FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    private void Update()
    {
       
        //h = Input.GetAxis("Horizontal");
        // v = Input.GetAxis("Vertical");
        //Debug.Log(h);
        // transform.position += new Vector3(speed * h * Time.deltaTime, speed * v * Time.deltaTime, 0);
        CheckKeyboardInput();
        Vector3 move = new Vector3(h, v, 0) * speed * Time.deltaTime;
        transform.position += move;
        flameAnimator.SetFloat(FLAME_ANIMATION, move.sqrMagnitude); // this is for checking speed fo animationing flame of rocket
        CheckSpaceShipOutOfBounds();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Fire
            Fire();
        }
    }

    // this function is for keyboard input
    private void CheckKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopMoving();
        }
    }

    private void Fire()
    {
        //1(Time.time) 0.3+0 = 0.3 => 1>0.3
        //1 0.3+1 = 1.3 => 1>\1.3
        //1.1
        //1.3
        //1.4 => again we can shot
        if(Time.time > fireRate + lastShot && gameController.HasBullet())
        {
            for(int i = 0; i < guns.Length; i++)
            {
                numOfBullets += 1;
                Instantiate(bulletPrefab, guns[i].transform.position, Quaternion.identity);
                gameController.popBullet();
            }
            lastShot = Time.time;

        }
        
        
    }

    private void CheckSpaceShipOutOfBounds()
    {
        transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -7.24f, 7.24f),
                    Mathf.Clamp(transform.position.y, -4.24f, 3.31f),
                    transform.position.z
                    );
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet_enemy")
        {
            _health -= col.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
        else if(col.gameObject.tag == "asteroid")
        {
            _health -= col.gameObject.GetComponent<AsteroidController>().health;
            CheckHealth();
        }
        else if(col.gameObject.tag == "enemy_ship")
        {
            _health -= col.gameObject.GetComponent<EnemyShipController>().power;
            CheckHealth();

        }
        

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "coin")
        {
            //Debug.Log("You Get Coin");
            col.gameObject.GetComponent<CoinController>().DestroyIt();
            //Destroy(col.gameObject);//coin will destroy
            gameController.AddCoin();
        }
    }
    private void CheckHealth()
    { 
        if (_health <= 0)
        {
            gameController.GameOver(numOfBullets);
            // TO DO:Need improve
            Destroy(gameObject);
        }
    }
    #endregion
    //Transform myTransform;

}
