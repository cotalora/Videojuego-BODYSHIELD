using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EosHealth : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rect;
    LifeEos lif;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        lif = GameObject.Find("Eosinofilo").GetComponent<LifeEos>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.offsetMin = new Vector2(lif.life,0);
        rect.offsetMax = new Vector2(lif.life,0);
    }
}
