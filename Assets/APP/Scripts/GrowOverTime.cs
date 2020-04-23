using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOverTime : MonoBehaviour
{
    public float growTime = 27f;

    public float newScaleX = 1f;
    public float newScaleY = 1f;
    public float newScaleZ = 1f;

    private void OnEnable()
    {
        this.transform.localScale = new Vector3(.001f, .001f, .001f);
        StartCoroutine(IncreaseScaleOverTime(growTime));
    }

    public IEnumerator IncreaseScaleOverTime(float time)
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

    }
}
