using UnityEngine;
using System.Collections;

public class EnemyShipController : MonoBehaviour {
    #region Public Variables
    public float vSpeed; //vertical speed
    public float hSpead; //horizontal speed
    public GameObject bulletPrefab;
    public GameObject enemyChildPrefab;
    public Vector2 timeToFire;
    public Vector2 timeToGivingBirth;
    public GameObject gun;
    public GameObject enemy_child;    
    public int power;
    public GameObject firePrefab;
    public GameObject coinSpawner;
    public GameObject explosionPrefab;
    #endregion

    #region Privatte Variables
    private int direction = 0; // 1 -> right , 0 -> none , -1 -> left
    private GameController gameController;
    private int initPower;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        initPower = power;
        gameController = GameObject.FindObjectOfType<GameController>();
        InvokeRepeating("ChangeDirection", 1, 0.5f);
        InvokeRepeating("Fire", timeToFire.x, timeToFire.y);
        InvokeRepeating("EnemyChild", timeToGivingBirth.x, timeToGivingBirth.y);
    }
    private void Update()
    {
        Vector3 move = Vector3.down;
        move.x = direction * hSpead;
        move.y = move.y * vSpeed;
        transform.position +=  move * Time.deltaTime;
        CheckSpaceshipOutOfBounds();
        CheckEnemyChildOutOfBounds();
    }
    private void CheckSpaceshipOutOfBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -6, 6);
        transform.position = pos;
    }
    private void CheckEnemyChildOutOfBounds()
    {
        Vector3 pos = transform.position;
        if (pos.y < -4.7) Destroy(gameObject);
    }
    private void ChangeDirection()
    {
        direction = Random.Range(-1, 2);// -1 , 0 , 1 will created
    }
    private void Fire()
    {
        Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
        
    }

    private void EnemyChild()
    {
        Instantiate(enemyChildPrefab, enemy_child.transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (col.gameObject.tag == "Player")
        {
            power = power - 2;
        }
        else power = power - col.gameObject.GetComponent<BulletController>().power;
        
        CheckPwer();
    }
    private void CheckPwer()
    {
        if(power <= 0)
        {
            gameController.AddScore(initPower);
            gameController.AddDestroyedItems(gameObject.tag);
            //Debug.Log(gameObject.tag);
            Instantiate(firePrefab, transform.position, Quaternion.identity);
            Instantiate(coinSpawner, transform.position, Quaternion.identity);
            Destroy(gameObject);
            //Destroy(enemyChildPrefab);
            //DestroyImmediate(enemyChildPrefab, true);
        }
    }
    #endregion

}
