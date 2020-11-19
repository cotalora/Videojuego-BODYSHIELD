using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBacteria : MonoBehaviour
{
    public float life = 1;
    public float force = 14f;
    BacteriaScript bacteria;
    ScoreScript score;
    FaseCountScript faseCount;
    public int scoreB = 10;
    bool aux = false;

    // Start is called before the first frame update
    void Start()
    {
        bacteria = GetComponent<BacteriaScript>();
        score = GameObject.Find("AllScore").GetComponent<ScoreScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        life = life + faseCount.AumlifeBacteria;
        force = force + faseCount.AumforceBacteria;
        scoreB = scoreB + faseCount.AumScoreBacteria;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= -173.34f)
        {
            bacteria.onOffAux = false;
            bacteria.val = false;
            transform.gameObject.tag = "zombie";
            this.gameObject.GetComponent<Animator>().SetInteger("States", 3);
            if (aux == false)
            {
                score.scoree = score.scoree + scoreB;
                aux = true;
            }
        }
    }
}
