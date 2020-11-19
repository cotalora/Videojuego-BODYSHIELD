using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuHealth : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rect;
    LifeNeu life;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        life = GameObject.Find("Neutrofilo").GetComponent<LifeNeu>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.offsetMin = new Vector2(life.lifeNeu,0);
        rect.offsetMax = new Vector2(life.lifeNeu,0);
    }
}
