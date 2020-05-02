using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissiveMatTriggerAction : MonoBehaviour
{
    [SerializeField] Color _defaultColor;
    [SerializeField] float _rate = 3f;
    [SerializeField] float _defaultEmissive = 0f;
    [SerializeField] float _emissiveMultiplier = 2f;

    private Color _currentColor;
    private Material _material;
    private bool _isActive = false;
    private Color m_transitionColor;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        /* when trigger exit
         * start reducing emissive value until it returns to default
         * Stop reducing when isActive
        */
        
        if (!_isActive)
        {
            if (_currentColor != _defaultColor)
            {
                print("_currentColor != _defaultColor... Lerp Color");
                m_transitionColor = Color.Lerp(_currentColor, _defaultColor, _rate * Time.deltaTime);
                _material.SetColor("_EmissionColor", m_transitionColor);
                _currentColor = m_transitionColor;
                
                if(_currentColor == _defaultColor)
                {
                    _material.DisableKeyword("_EMISSION");
                }
            }

            //_material.SetColor("_EmissiveColor", _defaultColor * Mathf.Lerp(m_currentEmissive, _defaultEmissive, currentTime / _rate));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            _isActive = true;
            _material.EnableKeyword("_EMISSION");
            _currentColor = _defaultColor * _emissiveMultiplier;
            _material.SetColor("_EmissionColor", _currentColor);
            print("Trigger Enter - Emissive");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            _isActive = false;
            print("Trigger Exit - Emissive");
        }
    }
}
