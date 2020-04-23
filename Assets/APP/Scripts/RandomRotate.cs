using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    public Quaternion _tumble;
    void Update()
    {
        transform.rotation = Random.rotation * _tumble;

        
    }


}
