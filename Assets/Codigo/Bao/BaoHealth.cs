using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaoHealth : MonoBehaviour
{
    RectTransform rect;
    LifeBao life;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        life = GameObject.Find("Basofilo").GetComponent<LifeBao>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.offsetMin = new Vector2(life.lifeBao,0);
        rect.offsetMax = new Vector2(life.lifeBao,0);
    }
}
