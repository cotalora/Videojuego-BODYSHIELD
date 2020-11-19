using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeParasito : MonoBehaviour
{
    public float life = 1;
    public float force = 2f;
    ParasitoScript parasito;
    ScoreScript score;
    FaseCountScript faseCount;
    public int scoreP = 8;
    bool aux = false;
    // Start is called before the first frame update
    void Start()
    {
        force = force*Time.deltaTime;
        parasito = GetComponent<ParasitoScript>();
        score = GameObject.Find("AllScore").GetComponent<ScoreScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        life = life + faseCount.AumlifeParasito;
        force = force + faseCount.AumforceParasito;
        scoreP = scoreP + faseCount.AumScoreParasito;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= -176)
        {
            parasito.onOffAux = false;
            parasito.val = false;
            parasito.part = false;
            transform.gameObject.tag = "zombie";
            this.gameObject.GetComponent<Animator>().SetInteger("States", 2);
            if (aux == false)
            {
                score.scoree += scoreP;
                aux = true;
            }
        }
    }
}
