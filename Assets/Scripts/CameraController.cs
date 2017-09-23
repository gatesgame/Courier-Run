using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float CameraSpeed;

    private Transform Target;
    private Vector3 Offset;
    private Vector3 CameraPosition;

    void Start()
    {
        Vector3.Lerp(transform.position, Target.position, CameraSpeed * Time.deltaTime);
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - Target.position;
        
    }

    void LateUpdate()
    {
        if (Target != null)
        {
            CameraPosition = Target.position + Offset;
            CameraPosition.z = -10f;
            CameraPosition.y = 0f;
            transform.position = Vector3.MoveTowards(transform.position,CameraPosition, CameraSpeed * Time.deltaTime);
        }
        else
        {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
