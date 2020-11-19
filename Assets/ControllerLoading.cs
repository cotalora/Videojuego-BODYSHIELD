using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerLoading : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public Text text;
    public bool activator = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        image.enabled = activator;
    }
    public void Enable()
    {
        activator = true;
    }
}
