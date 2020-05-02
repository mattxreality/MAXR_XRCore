using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{


    public float distanceMultiplier = 100f;
    public float _maxScale = 2;
    public float _cubeSize = 1;

    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[64];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 64; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            // make child of object where this class is running
            _instanceSampleCube.transform.parent = this.transform;
            // name each cube
            _instanceSampleCube.name = "SampleCube" + i;

            // number of samples divided by 360, make this formation into a circle
            this.transform.eulerAngles = new Vector3(0, 1.1777777f * i, 0);

            // move position
            _instanceSampleCube.transform.position = Vector3.forward * distanceMultiplier;

            // set reference for subsequent instance of sampleCube
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<64; i++)
        {
            if (_sampleCube != null)
            {
                // change scale based on corresponding array[] audio spectrum sample
                _sampleCube[i].transform.localScale = new Vector3(_cubeSize, (AudioPeer._audioBand64[i] * _maxScale) + 2, _cubeSize); ;
            }
        }
    }
}
