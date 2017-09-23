using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float MoveSpeed;
    public float SpeedUp = 30;

    private float Timer;

    void Update()
    {
        transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        SpeedUpTheMove();
    }

    //tang do kho trong game bang cach tang toc do
    void SpeedUpTheMove()
    {
        Timer += Time.deltaTime;
        if(Timer >= SpeedUp)
        {
            MoveSpeed++;
            Timer = 0f;
        }
    }
}
