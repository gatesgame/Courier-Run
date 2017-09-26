using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnergy : MonoBehaviour {

    private UIManager UiManager;
    private Transform AvatarIcon;

    void Start()
    {
        UiManager = FindObjectOfType<UIManager>();
        AvatarIcon = GameObject.FindGameObjectWithTag("Avatar").transform;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Vector3.MoveTowards(transform.position, AvatarIcon.position, 3 * Time.deltaTime);
            GameManager.Energys++;
            UiManager.SetEnergySpeedBoost(GameManager.Energys);
            //Destroy(col.gameObject);
        }
    }
}
