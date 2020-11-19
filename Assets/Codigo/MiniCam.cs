using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCam : MonoBehaviour
{
    // Start is called before the first frame update
    public static Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position = new Vector3(target.position.x,target.position.y + 20,target.position.z);
    }
}
