using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonHealth : MonoBehaviour
{
    RectTransform rect;
    LifeMon lif;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        lif = GameObject.Find("Monocito").GetComponent<LifeMon>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.offsetMin = new Vector2(lif.life,0);
        rect.offsetMax = new Vector2(lif.life,0);
    }
}
