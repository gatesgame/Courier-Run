using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnergy : MonoBehaviour {

    public float TimeMinToSpawnEnergy;
    public float TimeMaxToSpawnEnergy;
    public float MinPosSpawnEnergy;
    public float MaxPosSpawnEnergy;

    [SerializeField]
    private GameObject Energy;

    void Start()
    {
        StartCoroutine(SpawnEnergy());
    }

    IEnumerator SpawnEnergy()
    {
        float timeToSpawnEnergy = Random.Range(TimeMinToSpawnEnergy, TimeMaxToSpawnEnergy);
        yield return new WaitForSeconds(timeToSpawnEnergy);
        Vector3 posSpawnEnergy = transform.position;
        posSpawnEnergy.y = Random.Range(MinPosSpawnEnergy, MaxPosSpawnEnergy);
        Instantiate(Energy, posSpawnEnergy, Quaternion.identity);
        StartCoroutine(SpawnEnergy());
    }
}
