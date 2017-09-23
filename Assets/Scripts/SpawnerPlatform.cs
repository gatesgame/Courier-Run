using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlatform : MonoBehaviour    
{

    public float TimeMinToSpawnPlatform;
    public float TimeMaxToSpawnPlatform;
    public float MinPosSpawnPlatform;
    public float MaxPosSpawnPlatform;

    [SerializeField]
    private GameObject[] PlatformGround;

    void Start()
    {
        StartCoroutine(SpawnPlatform());
    }

    //spawn platform random: time , position , type platform in prefab
    IEnumerator SpawnPlatform()
    {
        float timeToSpawn = Random.Range(TimeMinToSpawnPlatform, TimeMaxToSpawnPlatform);
        yield return new WaitForSeconds(timeToSpawn);
        Vector3 posSpawnPlatform = transform.position;
        posSpawnPlatform.y = Random.Range(MinPosSpawnPlatform, MaxPosSpawnPlatform);
        int RandomNumber = Random.Range(0, PlatformGround.Length - 1);
        Instantiate(PlatformGround[RandomNumber], posSpawnPlatform, Quaternion.identity);
        StartCoroutine(SpawnPlatform());
    }
}
