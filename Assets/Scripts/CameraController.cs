using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float CameraSpeed;

    private GameObject Target;
    private Vector3 CameraPosition;

    void LateUpdate()
    {
        if (Target != null)
        {
            CameraPosition = Target.transform.position;
            CameraPosition.z = -10f;
            CameraPosition.y = 0f;
            transform.position = Vector3.MoveTowards(transform.position, CameraPosition, CameraSpeed * Time.deltaTime);
        }
        else
        {
            Target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
