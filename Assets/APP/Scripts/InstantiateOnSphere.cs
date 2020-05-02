using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
public class InstantiateOnSphere : MonoBehaviour
{
    KoreographyEvent eventPayloadText;

    [Tooltip("Add mini-solarsystem GameObjects that will be spawned by this script.")]
    [SerializeField] GameObject[] miniSolarSystems;
    //public Vector3 spawnValues;
    public int solarSystemCount = 10;
    public float spawnWait = 1f;
    public float startWait = 2f;
    public float waveWait = 5f;
    public float spawnSphereMinMultiplier = 100f;
    public float spawnSphereMaxMultiplier = 400f;

    private Vector3 m_parentVector3;

    // This may not be needed
    // [SerializeField] ParticleSystem _PSsolarSystem;
    // private Collider m_collider;
    // private Vector3 spawnPosition;

    private bool m_activateSpawn = true;

    void Start()
    {
        // This added to Start() for testing purposes only
        // StartCoroutine(SpawnMiniSolarSystems());

        Koreographer.Instance.RegisterForEvents("songregions_ktrack", MusicResponse);

        m_parentVector3 = GetComponent<Transform>().position;
    }

    void OnDestroy()
    {
        // Sometimes the Koreographer Instance gets cleaned up before hand.
        // No need to worry in that case.
        if (Koreographer.Instance != null)
        {
            Koreographer.Instance.UnregisterForAllEvents(this);
        }
    }

    private void Update()
    {
        if (Debug.isDebugBuild)
        {
            // use for debug purposes
            if (Input.GetKeyDown("n"))
            { StartCoroutine(SpawnMiniSolarSystems()); }
        }
    }

    IEnumerator SpawnMiniSolarSystems()
    {
        // Wait this many seconds before starting spawn
        yield return new WaitForSeconds(startWait);
        while (m_activateSpawn)
        {
            for (int i = 0; i < solarSystemCount; i++)
            {
                GameObject miniSolarSystem = miniSolarSystems[Random.Range(0, miniSolarSystems.Length)];

                // spawnPosition = GetRandomPointInCollider();

                Quaternion spawnRotation = Quaternion.identity;

                GameObject newObject = Instantiate(miniSolarSystem, m_parentVector3 + Random.onUnitSphere * Random.Range(spawnSphereMinMultiplier, spawnSphereMaxMultiplier), Random.rotation) as GameObject;

                // Wait this many seconds before continuing to the next 'i' in array of gameobjects
                yield return new WaitForSeconds(spawnWait);
            }

            // Wait this many seconds before restarting the 'for loop'
            yield return new WaitForSeconds(waveWait);

            // stop while loop after a single pass. 
            m_activateSpawn = false;
        }
    }

    private void MusicResponse(KoreographyEvent evt)
    {
        eventPayloadText = evt;

        switch (eventPayloadText.GetTextValue())
        {
            case "outro":
                if (!m_activateSpawn)
                {
                    m_activateSpawn = true;
                }
                StartCoroutine(SpawnMiniSolarSystems());
                break;
        }
    }
}
