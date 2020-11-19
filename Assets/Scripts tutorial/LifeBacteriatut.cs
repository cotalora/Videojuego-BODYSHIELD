using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeBacteriatut : MonoBehaviour
{
    public float life = 0;
    public float force = 14f;
    BacteriaScripttut bacteria;
    float timeDead = 4f;
    bool aux = false;

    // Start is called before the first frame update
    void Start()
    {
        bacteria = GetComponent<BacteriaScripttut>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= -3.59f)
        {
            bacteria.onOffAux = false;
            bacteria.val = false;
            bacteria.de=false;
            timeDead -= Time.deltaTime;
            if (timeDead <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}