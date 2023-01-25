using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevelUtility : MonoBehaviour {

	public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
