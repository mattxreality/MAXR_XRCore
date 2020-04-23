using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTumbleRandomVelocity : MonoBehaviour
{
    public float speed;
    public float tumble;
    public float randomRangeMin = .8f;
    public float randomRangeMax = 1.2f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * speed * Random.Range(randomRangeMin,randomRangeMax);

        if (tumble != 0f)
        {
            GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        }
    }
}
