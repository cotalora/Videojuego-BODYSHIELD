using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflamacionColl : MonoBehaviour
{
    // Start is called before the first frame update
    enum STATE
    {
        UP, DOWN
    }
    Animator anim;
    FaseCountScript faseCount;
    STATE currentState = STATE.UP;
    ScoreScript score;
    bool aux = false;
    public float force = 0.05f;
    public float forcee = 0.05f;
    public int scoreI = 10;
    void Start()
    {
        anim = GetComponent<Animator>();
        score = GameObject.Find("AllScore").GetComponent<ScoreScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        force = force + faseCount.AumforceInfla;
        scoreI = scoreI + faseCount.AumScoreInfla;
    }

    // Update is called once per frame
    void Update()
    {
        MakeBehaviour();
    }
    private void OnTriggerStay(Collider cl)
    {
        if (cl.tag == "Bao" && Input.GetMouseButtonDown(0))
        {
            currentState = STATE.DOWN;
            transform.gameObject.tag = "InfDown";
            if (aux == false)
            {
                score.scoree += scoreI;
                aux = true;
            }
        }
    }
    void MakeBehaviour() //Método hacer comportamiento
    {
        switch (currentState) // Dependiendo del estado
        {
            case STATE.UP: // Si el estado es IDLE
                Up(); //Correr método Idle
                break; // Parar
            case STATE.DOWN: // Si el estado es WALK
                Down(); //Correr método Walk
                break; // Parar
        }
    }
    void Up(){
        anim.SetInteger("States",0);
    }
    void Down(){
        anim.SetInteger("States",1);
    }
}
