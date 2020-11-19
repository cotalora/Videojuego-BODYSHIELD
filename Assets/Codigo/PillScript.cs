using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillScript : MonoBehaviour
{
    // Start is called before the first frame update
    LifeNeu lifeNeu;
    LifeBao lifeBao;
    LifeLin lifeLin;
    FaseCountScript faseCount;
    LifeMon lifeMon;
    LifeEos lifeEos;
    void Start()
    {
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        lifeMon = GameObject.Find("Monocito").GetComponent<LifeMon>();
        lifeEos = GameObject.Find("Eosinofilo").GetComponent<LifeEos>();
        lifeNeu = GameObject.Find("Neutrofilo").GetComponent<LifeNeu>();
        lifeBao = GameObject.Find("Basofilo").GetComponent<LifeBao>();
        lifeLin = GameObject.Find("Linfosito").GetComponent<LifeLin>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Neu" && lifeNeu.lifeNeu < 1)
        {
            lifeNeu.lifeNeu += 1f - lifeNeu.lifeNeu;
            Destroy(this.gameObject);
        }
        else if (col.tag == "Lin" && lifeLin.lifeLin < 1)
        {
            lifeLin.lifeLin += 1f - lifeLin.lifeLin;
            Destroy(this.gameObject);
        }
        else if (col.tag == "Mon" && lifeMon.life < 1)
        {
            lifeMon.life += 1f - lifeMon.life;
            Destroy(this.gameObject);
        }
        else if (col.tag == "Eos" && lifeEos.life < 1)
        {
            lifeEos.life += 1f - lifeEos.life;
            Destroy(this.gameObject);
        }
        else if (col.tag == "Bao" && lifeBao.lifeBao < 1)
        {
            lifeBao.lifeBao += 1f - lifeBao.lifeBao;
            Destroy(this.gameObject);
        }
    }
}
