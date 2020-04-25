using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    
    [Tooltip("In seconds")][SerializeField] float loadDelay = 5f;

    [SerializeField] float levelLoadTime = 1f;
    int highestSceneIndex;
    int nextScene;
    int currentScene;  // create an integer variable for storing the current scene index

    void Awake()
    {
        // check if this is the only instance. If not, destroy this instance.
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        highestSceneIndex = SceneManager.sceneCountInBuildSettings - 1; // Build scene count - 1 = highestSceneIndex
        currentScene = SceneManager.GetActiveScene().buildIndex;  // get the active scene's index, stored as int
        print("currentScene = " + currentScene);
        print("highestSceneIndex = " + highestSceneIndex);
        Invoke("LoadNextScene", levelLoadTime);

    }

    void DebugGame()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextScene();
        }
    }

    private void Update()
    {
        if (Debug.isDebugBuild) { DebugGame(); } // debug controls for build settings

        //int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        //SceneManager.LoadScene(nextLevel);

        // This code is to advance the scene if you're on the first build scene. I don't know if I need this.
        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    if (CrossPlatformInputManager.GetButtonDown("Fire1") ||
        //        OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= Mathf.Epsilon)
        //    {
        //        LevelChanger.instance.FadeToLevel(1);
        //        Invoke("LoadFirstScene", 3f);
        //    }
        //}
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadNextScene()
    {
        // if on last scene in build, load first scene in build
        if (currentScene == highestSceneIndex)
        {
            currentScene = 0;
            SceneManager.LoadScene(0);
        }
        else
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
            nextScene = ++currentScene; // increase the current level integer by one
            SceneManager.LoadScene(nextScene); // load the next level, which is current level increased by 1
            print("currentScene = " + currentScene);
            print("nextScene = " + nextScene);
            print("totalScenes = " + highestSceneIndex);
        }
    }
}
