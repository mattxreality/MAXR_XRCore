using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalcAction : MonoBehaviour
{

    public float _multiplier;
    public float _materialMultiplier;

    private ParticleSystem _ps;

    public GameObject _protoStar;
    private float _dist;

    private float _eRate;
    private float _eRateMat;

    public Material _protoStarMaterial;

    // Child/attached Colliders to detect candidate grabbable objects.
    // [SerializeField] protected Collider[] m_grabVolumes = null;


    void Start()
    {

        _ps = GetComponent<ParticleSystem>();
        var emission = _ps.emission;
        emission.enabled = false;

        _protoStarMaterial.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        _dist = Vector3.Distance(_protoStar.transform.position, transform.position);
        _eRate = 4f / _dist;
        _eRateMat = _materialMultiplier / _dist;

        //print("Dist from Hand to Protostar is " + _dist);
        //print("DistMagnitude is " + _eRate);

        _protoStarMaterial.SetColor("_EmissiveColor", Color.cyan * (179 * _eRateMat));

        if (_dist < 1f)
        {

            var emission = _ps.emission;
            emission.enabled = true;
            emission.rateOverTime = _eRate;

            

            // make controller vibrate using an audio file
            //VibrationManager.singleton.TriggerVibration(shootingAudio,ovrGrabbable.grabbedBy.GetController());

            // make controller vibrate using manual frequency parameters
            //VibrationManager.singleton.TriggerVibrationManual(40, 2, 255, OVRInput.Controller.LTouch);
        }
        
        if (_dist >= 1f)
        {
            var emission = _ps.emission;
            emission.enabled = false;
        }
    }

}
