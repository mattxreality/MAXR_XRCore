using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    // you must know the scene index you want to change to.
    public void LoadScene(int index)
    {
        Debug.Log("Button Press for LoadTruckRepair");
        SceneLoader.instance.LoadNextScene(index);
    }
}
