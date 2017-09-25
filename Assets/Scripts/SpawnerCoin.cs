using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    public float TimeMinToSpawnCoin;
    public float TimeMaxToSpawnCoin;
    public float MinPosSpawnCoin;
    public float MaxPosSpawnCoin;

    [SerializeField]
    private GameObject Coin;

    void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnCoin()
    {
        float timeToSpawnCoin = Random.Range(TimeMinToSpawnCoin, TimeMaxToSpawnCoin);
        yield return new WaitForSeconds(timeToSpawnCoin);
        Vector3 posSpawnCoin = transform.position;
        posSpawnCoin.y = Random.Range(MinPosSpawnCoin, MaxPosSpawnCoin);
        Instantiate(Coin, posSpawnCoin, Quaternion.identity);
        StartCoroutine(SpawnCoin());
    }
}
