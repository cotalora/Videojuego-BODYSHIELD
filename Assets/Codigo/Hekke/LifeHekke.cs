using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHekke : MonoBehaviour
{
    public float life = 1;
    public float force = 13f;
    public float forcee = 2f;
    FaseCountScript faseCount;
    HekkeScript hekke;
    ScoreScript score;
    public int scoreH = 10;
    bool aux = false;
    // Start is called before the first frame update
    void Start()
    {
        hekke = GetComponent<HekkeScript>();
        score = GameObject.Find("AllScore").GetComponent<ScoreScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        life = life + faseCount.AumlifeHekke;
        force = force + faseCount.AumforceHekke;
        scoreH = scoreH + faseCount.AumScoreHekke;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scoreH);
        if (life <= -181)
        {
            hekke.onOffAux = false;
            hekke.val = false;
            transform.gameObject.tag = "zombie";
            this.gameObject.GetComponent<Animator>().SetInteger("States",3);
            if (aux == false)
            {
                score.scoree += scoreH;
                aux = true;
            }
        }
    }
}
