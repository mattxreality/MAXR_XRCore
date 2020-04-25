using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/* I should use SOs for this function. I could use the scene manager to
 * store the target scene index in an SO and retrieve it for use by this script. 
 * 
 * 
 */

public class SceneLoading : MonoBehaviour
{
    public static SceneLoading singleton;

    [SerializeField]
    private Image progressBar;
    
    // call this from the scene manager to set the load scene
    public int sceneIndexToLoad = 2;

    private void Awake()
    {
        if (singleton && singleton != this)
        {
            Destroy(this);
        }
        else
        {
            singleton = this;
        }
        // DontDestroyOnLoad(gameObject);

        // sceneIndexToLoad = 2; // first scene to load is mainmenu
    }

    void Start()
    {
        // start async operation
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {

        yield return new WaitForSeconds(3f);

        //create an async operation
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(sceneIndexToLoad);
        
            while (gameLevel.progress < 1)
        {
            // The progress bar fill = async operation progress
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame(); // let program breath
        }

        // when finished, load the game scene
        yield return new WaitForEndOfFrame(); // let program breath
    }
}
