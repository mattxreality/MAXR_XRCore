using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateColumn : MonoBehaviour
{
  public float distanceMultiplier = .1f;
    public int columnCount = 720;

    public GameObject _sampleColumnPrefab;
    GameObject[] _sampleColumnArray;


    // Start is called before the first frame update
    void Start()
    {
        _sampleColumnArray = new GameObject[columnCount];
        for (int i = 0; i < columnCount; i++)
        {
            GameObject _instanceSampleColumn = (GameObject)Instantiate(_sampleColumnPrefab);
            _instanceSampleColumn.transform.position = this.transform.position;
            // make child of object where this class is running
            _instanceSampleColumn.transform.parent = this.transform;
            // name each cube
            _instanceSampleColumn.name = "SampleColumn" + i;

            // Rotation, number of samples divided by 360, make this formation into a circle
            this.transform.eulerAngles = new Vector3(0, -1f * i, 0);
            this.transform.position = new Vector3(transform.localPosition.x + distanceMultiplier, transform.localPosition.y, transform.localPosition.z + distanceMultiplier);


            // move position
            _instanceSampleColumn.transform.position = Vector3.forward * distanceMultiplier;
            //_instanceSampleColumn.transform.position = Vector3.right * distanceMultiplier;
            

            // set reference for subsequent instance of sampleCube
            _sampleColumnArray[i] = _instanceSampleColumn;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
