using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {
    #region Public Variables
    public Vector2 coinToSpawn;
    public GameObject coinPrefab;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        int countOfCoinsToSpawn = (int) Random.Range(coinToSpawn.x, coinToSpawn.y);
        for(int i=0; i < countOfCoinsToSpawn; i++)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    #endregion
}
