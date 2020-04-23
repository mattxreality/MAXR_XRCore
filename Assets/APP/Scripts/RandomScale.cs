using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    public float lowRange = .5f;
    public float highRange = 1.5f;
    private float m_randomNumber;

    void Start()
    {
        m_randomNumber = Random.Range(lowRange, highRange);
        this.transform.localScale *= m_randomNumber;
    }
}
