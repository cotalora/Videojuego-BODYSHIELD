using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinHealth : MonoBehaviour
{
    RectTransform rect;
    LifeLin life;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        life = GameObject.Find("Linfosito").GetComponent<LifeLin>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.offsetMin = new Vector2(life.lifeLin,0);
        rect.offsetMax = new Vector2(life.lifeLin,0);
    }
}
