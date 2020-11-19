using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlaying : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeCount = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
    }
}
