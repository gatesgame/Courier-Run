using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBackgrounds : MonoBehaviour {

    public GameObject BackGroundNight;
    public GameObject BackGroundDaytime;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "LimitBackground")
        {
            SpawnBackground();
        }
    }

    void SpawnBackground()
    {
        Instantiate(BackGroundDaytime, transform.position, Quaternion.identity);
    }
}
