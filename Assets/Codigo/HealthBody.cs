using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBody : MonoBehaviour
{
    RectTransform rect;
    LifeBody lif;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        lif = GameObject.Find("Bodyy").GetComponent<LifeBody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rect.offsetMin = new Vector2(lif.life,0);
        rect.offsetMax = new Vector2(lif.life,0);
    } 
    
}
