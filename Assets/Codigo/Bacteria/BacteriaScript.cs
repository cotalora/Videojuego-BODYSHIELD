using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BacteriaScript : MonoBehaviour
{
    enum STATE
    {
        IDLE, RUN, WALK, ATTACK, FALLING
    }
    STATE currentState = STATE.WALK;
    NavMeshAgent nav;
    Animator anim;
    LifeBacteria life;
    LifeNeu lifee;
    Animator ne;
    float speed = 1f;
    public bool onOffAux = true;
    public bool val = true;
    void Start()
    {
        float x = Random.Range(-49.6f, 49.6f);
        float z = Random.Range(-40.8f, 40.8f);
        transform.position = new Vector3(x, 0, z);
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        life = GameObject.Find(this.gameObject.name).GetComponent<LifeBacteria>();
        lifee = GameObject.Find("Neutrofilo").GetComponent<LifeNeu>();
    }

    void Update()
    {
        if (onOffAux == true)
        {
            Move();
        }
        MakeBehaviour();
        //Debug.Log(onOffAux);
    }
    private void OnTriggerEnter(Collider cl)
    {
        if (val == true)
        {
            if (cl.tag == "Obstacle")
            {
                StartCoroutine(Rotate(Vector3.up, 90, 1.0f));
            }
            else if (cl.tag == "Wall")
            {
                int ram = Random.Range(89, 181);
                StartCoroutine(Rotate(Vector3.up, ram, 1.0f));
            }
            else if (cl.tag == "HitRecibedNeu")
            {
                life.life = life.life - lifee.forceNeu;
            }
        }
    }
    private void OnTriggerStay(Collider cl)
    {
        if (val == true)
        {
            
            if (cl.tag == "Blood")
            {
                float distance = Vector3.Distance(cl.transform.position, transform.position);
                transform.LookAt(cl.transform);
                if (distance > nav.stoppingDistance)
                {
                    currentState = STATE.RUN;
                    speed = 2f;
                }
                else if (distance <= nav.stoppingDistance)
                {
                    speed = 1f;
                    onOffAux = false;
                    currentState = STATE.ATTACK;
                }

            }
            else if (cl.tag == "Neu")
            {

                float distance = Vector3.Distance(cl.transform.position, transform.position);
                transform.LookAt(cl.transform);
                if (distance > nav.stoppingDistance + 0.2f)
                {
                    onOffAux = true;
                    currentState = STATE.RUN;
                    speed = 2f;
                }
                else if (distance <= nav.stoppingDistance + 0.2f)
                {
                    onOffAux = false;
                    currentState = STATE.ATTACK;
                }
            }
            else if (cl.tag == "dead")
            {
                onOffAux = true;
                currentState = STATE.WALK;
                speed = 1f;
            }
        }
    }
    private void OnTriggerExit(Collider cl)
    {
        if (val == true)
        {
            if (cl.tag == "Blood" || cl.tag == "Neu")
            {
                onOffAux = true;
            }
        }
    }

    void Move()
    {
        nav.Move(transform.forward * speed * Time.deltaTime);
    }
    void MakeBehaviour() //Método hacer comportamiento
    {
        switch (currentState) // Dependiendo del estado
        {
            case STATE.IDLE:
                Idle();
                break;
            case STATE.RUN:
                Run();
                break;
            case STATE.WALK:
                Walk(); //Correr método Walk
                break; // Parar
            case STATE.ATTACK: // Si el estado es WALK
                Attack(); //Correr método Walk
                break;
            case STATE.FALLING: // Si el estado es WALK
                Falling();
                break; // Parar
        }
    }
    void Run() //Método caminar
    {
        anim.SetInteger("States", 4);
    }
    void Walk() //Método caminar
    {
        anim.SetInteger("States", 1);
    }
    void Idle()
    {
        anim.SetInteger("States", 0);
    }
    void Attack()
    {
        anim.SetInteger("States", 2);
    }
    void Falling()
    {
        anim.SetInteger("States", 3);
    }
    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }
}
