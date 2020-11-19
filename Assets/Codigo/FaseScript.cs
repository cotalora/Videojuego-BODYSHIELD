using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    TimerScript timer;
    FaseCountScript faseCount;

    public float time = 2;
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<TimerScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
    }

    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;
        if (time <= 0)
        {
            if (timer.countBacterias == 0 && timer.countVirus == 0 && timer.countHekkes == 0 && timer.countParasitos == 0 && timer.countInfla == 0 && timer.countZombies == 0)
            {
                faseCount.fase = faseCount.fase + 1;
                //----------------NEU-----------------------------
                faseCount.AumlifeNeu = faseCount.AumlifeNeu + 0.005f;
                faseCount.AumforceNeu = faseCount.AumforceNeu + 2;
                //----------------BAO-----------------------------
                faseCount.AumlifeBao = faseCount.AumlifeBao + 0.005f;
                //----------------LIN-----------------------------
                faseCount.AumlifeLin = faseCount.AumlifeLin + 0.005f;
                faseCount.AumforceLin = faseCount.AumforceLin + 3;
                //----------------EOS-----------------------------
                faseCount.AumlifeEos = faseCount.AumlifeEos + 0.005f;
                faseCount.AumforceEos = faseCount.AumforceEos + 3.5f;
                //----------------MON-----------------------------
                faseCount.AumlifeMon = faseCount.AumlifeMon + 0.005f;
                //----------------Bacteria---------------------------------
                faseCount.AumlifeBacteria = faseCount.AumlifeBacteria + 0.005f;
                faseCount.AumforceBacteria = faseCount.AumforceBacteria + 3.5f;
                faseCount.AumScoreBacteria = faseCount.AumScoreBacteria + 2;
                //----------------Parasito---------------------------------
                faseCount.AumlifeParasito = faseCount.AumlifeParasito + 0.005f;
                faseCount.AumforceParasito = faseCount.AumforceParasito + 3.5f;
                faseCount.AumScoreParasito = faseCount.AumScoreParasito + 1;
                //----------------Hekke------------------------------------
                faseCount.AumlifeHekke = faseCount.AumlifeHekke + 0.005f;
                faseCount.AumforceHekke = faseCount.AumforceHekke + 3.5f;
                faseCount.AumScoreHekke = faseCount.AumScoreHekke + 3;
                //----------------Virus------------------------------------
                faseCount.AumlifeVirus = faseCount.AumlifeVirus + 0.005f;
                faseCount.AumforceVirus = faseCount.AumforceVirus + 3.5f;
                faseCount.AumScoreVirus = faseCount.AumScoreVirus + 3;
                //----------------Inflamacion-----------------------------
                faseCount.AumforceInfla = faseCount.AumforceInfla + 3.5f;
                faseCount.AumScoreInfla = faseCount.AumScoreInfla + 2;

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
