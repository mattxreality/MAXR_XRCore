using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkOverTime : MonoBehaviour
{
    public float shrinkTime;

    public float newScaleX;
    public float newScaleY;
    public float newScaleZ;


    private void Start()
    {
        StartCoroutine(ReduceScaleOverTime(shrinkTime));
    }

    IEnumerator ReduceScaleOverTime(float time)
    {
        Vector3 originalScale = this.transform.localScale;
        Vector3 destinationScale = new Vector3(newScaleX, newScaleY, newScaleZ);

        float currentTime = 0.0f;

        do
        {
            this.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        Destroy(gameObject);

    }
}
