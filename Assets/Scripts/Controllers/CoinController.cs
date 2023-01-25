using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

    #region Public Variables
    public float speed;
    public AudioClip[] clips;
    //public AudioClip clipEatCoin;
    public AudioSource audioSourse; 
    #endregion

    #region Private Variables
    private Vector2 directiion;//  coins have Different speeds
    private AudioClip clip;
    #endregion

    #region Public Methods
    public void DestroyIt()
    {
        StartCoroutine(DestroyAfterSound());
    }
    #endregion

    #region Private Methods

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(clip.length);
        Destroy(gameObject);
    }
    private void Start()
    {
        clip = clips [Random.Range(0, clips.Length)];
        audioSourse.PlayOneShot(clip);
        directiion = Vector2.up;
        directiion.x = Random.Range(-4f, 4f);//for moving coins to left and right randomly
        Invoke("GoDown", 0.4f);//after 0.4s coins go down and direction will change

    }
    private void Update()
    {
        transform.Translate(directiion * speed * Time.deltaTime);// it's make coins move up and after 0.4 second coins go down and of course right and left!

    }
    private void GoDown()
    {
        directiion.y *= -1;
        directiion.x = 0;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            clip = clips[Random.Range(0, clips.Length)];
            audioSourse.PlayOneShot(clip);
        }
    }
    #endregion
}
