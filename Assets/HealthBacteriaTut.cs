using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBacteriaTut : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rect;
    LifeBacteriatut lif;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        lif = GameObject.Find((((this.gameObject.transform.parent).parent).parent).parent.name).GetComponent<LifeBacteriatut>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.offsetMin = new Vector2(lif.life,0);
        rect.offsetMax = new Vector2(lif.life,0);
    }
}