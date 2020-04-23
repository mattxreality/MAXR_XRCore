using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    // sets movement values for x,y,z. Default 10f
    [SerializeField] Vector3 movementVector = new Vector3(10f, 0f, 0f);

    // time it takes to complete one full cycle
    [SerializeField] float period = 2f;

    // todo remove from inspector later
    [Range(0, 1)] // 0 for not moved, 1 for fully moved.
    [SerializeField]
    float movementFactor;

    Vector3 startingPos; // must be stored for absolute movement

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (period <= Mathf.Epsilon)
        {
            Debug.Log("cycle Not a Number (NaN)");
            return;
        }

        //Grows continually from zero
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        // set position of the Game Object this script is applied to
        transform.position = startingPos + offset;

        // print("rawSinWave" + rawSinWave);

    }
}
