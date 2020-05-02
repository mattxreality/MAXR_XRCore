using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EmissiveMatTriggerAction : MonoBehaviour
{
    [SerializeField] float _rate = 3f;
    [SerializeField] float _emissiveMultiplier = 20f;
    [SerializeField] Color _defaultColor;
    [SerializeField] Color _emissionColor;
    [SerializeField] string _triggerTag = "Activator";
    // We don't need these variables anymore :)
    //private Color m_currentColor;
    //private Color m_transitionColor;
    private Material m_material;
    private bool m_isActive = false;
    private void Awake()
    {
        // Let's put the GetComponent method in Awake, so even if the script is disabled, we still get script components
        m_material = GetComponent<MeshRenderer>().material;
    }
    void Start()
    {
        // Let's enable the material keyword on Start
        m_material.EnableKeyword("_EMISSION");
    }
    void Update()
    {
        // When _isActive is set to true, we set the emissive color to the defaul color
        if (m_isActive)
        {
            m_material.SetColor("_EmissionColor", Color.Lerp(m_material.GetColor("_EmissionColor"), _defaultColor, _rate * Time.deltaTime));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _triggerTag)
        {
            // When we enter the trigger, call the coroutine
            StartCoroutine(ChangeEmissionColor(_emissionColor));
        }
    }
    // By creating a Coroutine, we make it a bit easier to handle the toggling of variables
    private IEnumerator ChangeEmissionColor(Color newEmissionColor)
    {
        m_material.SetColor("_EmissionColor", newEmissionColor * _emissiveMultiplier);
        m_isActive = true;
        // The function WaitUntil is a way to wait until a condition is met. 
        // Here we are waiting for the emissive color to be equal to the default color
        yield return new WaitUntil(() => m_material.GetColor("_EmissionColor") == _defaultColor);
        m_isActive = false;
    }
}
