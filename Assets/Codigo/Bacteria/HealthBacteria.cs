using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBacteria : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rect;
    LifeBacteria lif;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        lif = GameObject.Find((((this.gameObject.transform.parent).parent).parent).parent.name).GetComponent<LifeBacteria>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.offsetMin = new Vector2(lif.life,0);
        rect.offsetMax = new Vector2(lif.life,0);
    }
}