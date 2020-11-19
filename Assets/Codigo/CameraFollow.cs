using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static Transform target;

    public float smothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + (new Vector3(4.14f, 3.61f, 3.55f));
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
