using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeVirus : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 1;
    public float force = 13f;
    VirusScript virus;
    ScoreScript score;
    FaseCountScript faseCount;
    public int scoreV = 10;
    bool aux = false;
    
    void Start()
    {
        virus = GetComponent<VirusScript>();
        score = GameObject.Find("AllScore").GetComponent<ScoreScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        life = life + faseCount.AumlifeVirus;
        force = force + faseCount.AumforceVirus;
        scoreV = scoreV + faseCount.AumScoreVirus;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= -176)
        {
            virus.onOffAux = false;
            virus.val = false;
            transform.gameObject.tag = "zombie";
            this.gameObject.GetComponent<Animator>().SetInteger("States",3);
            if (aux == false)
            {
                score.scoree += scoreV;
                aux = true;
            }
        }
    }
}
