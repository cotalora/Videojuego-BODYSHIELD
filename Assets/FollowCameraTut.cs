using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraTut : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    void Start(){
        cam = GameObject.Find("Main Camerat").GetComponent<Camera>();
    }
    void Update()
    {
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
    }
}
