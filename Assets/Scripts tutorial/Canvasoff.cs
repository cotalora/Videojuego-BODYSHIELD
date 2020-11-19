using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Canvasoff : MonoBehaviour
{
    public Canvas canvas;
    public GameObject TutCanvas;
    public Image imaa;
    public bool aux=false;
    // Start is called before the first frame update
    void Start()
    {
        imaa.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(TutCanvas.GetComponent<AnimatedText>().getLineaActual()==TutCanvas.GetComponent<AnimatedText>().getLastLine() && TutCanvas.GetComponent<AnimatedText>().getCheckNext() && Input.GetKey(KeyCode.Return))
        {
            canvas.enabled=false;
            aux=true;
           
        }
         
        
    }
}
