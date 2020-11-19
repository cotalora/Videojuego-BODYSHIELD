using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflamacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-49.6f, 49.6f);
        float z = Random.Range(-40.8f, 40.8f);
        transform.position = new Vector3 (x,0,z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
