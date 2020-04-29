using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    
    [Tooltip("In seconds")][SerializeField] float loadDelay = 5f;

    [SerializeField] float levelLoadTime = 3f;
    private int highestSceneIndex;
    private int nextScene;
    private int currentScene;  // create an integer variable for storing the current scene index
    private bool m_spashScreenCompleted = false;

    private int m_mainMenuBuildIndex = 2;

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
        Invoke("SplashScreen", loadDelay);

    }

    void DebugGame()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            currentScene++;
            LoadNextScene(currentScene);
        }
    }

    private void Update()
    {
        // debug controls for build settings
        if (Debug.isDebugBuild) { DebugGame(); } 

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

    private void SplashScreen()
    {
        // Will execute if running this method from standard scene
        if (currentScene == 0 && !m_spashScreenCompleted)
        {
            m_spashScreenCompleted = true;
            SceneManager.LoadScene(m_mainMenuBuildIndex);
        }
    }
    public void LoadMainMenu()
    {
            SceneManager.LoadScene(m_mainMenuBuildIndex);
    }

    public void LoadNextScene(int index)
    {

            SceneManager.LoadScene(index);
        
        //else
        //{
        //    currentScene = SceneManager.GetActiveScene().buildIndex;
        //    nextScene = ++currentScene; // increase the current level integer by one
        //    SceneManager.LoadScene(nextScene); // load the next level, which is current level increased by 1
        //    print("currentScene = " + currentScene);
        //    print("nextScene = " + nextScene);
        //    print("totalScenes = " + highestSceneIndex);
        //}
    }
}
