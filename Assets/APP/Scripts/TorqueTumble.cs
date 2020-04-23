using UnityEngine;

public class TorqueTumble : MonoBehaviour
{
    public float tumble = 1f;

    public void Tumble()
    {
        GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * tumble);
            // sample: // transform.localScale = Vector3.one * Mathf.Lerp(minScale, maxScale, curveValue);
    }

}
