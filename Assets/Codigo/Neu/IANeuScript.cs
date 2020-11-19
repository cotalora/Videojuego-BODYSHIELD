using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IANeuScript : MonoBehaviour
{
    enum STATE
    {
        IDLE, WALK, RUN, PUNCH, KICK, DEFENCE
    }
    STATE currentState = STATE.WALK;
    NavMeshAgent nav;
    Animator anim;
    float speed = 4f;
    LifeNeu lif;
    public bool onOffAux = true;
    public bool sh = false;
    LifeBacteria ba;
    LifeHekke he;
    LifeNeu life;
    void OnEnable()
    {
        sh = true;
    }
    void OnDisable()
    {
        sh = false;
    }
    void Start()
    {
        float x = Random.Range(-49.6f, 49.6f);
        float z = Random.Range(-40.8f, 40.8f);
        transform.position = new Vector3(x, 0, z);
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ba = GameObject.Find("Bacteria").GetComponent<LifeBacteria>();
        he = GameObject.Find("Hekke").GetComponent<LifeHekke>();
        life = GameObject.Find("Neutrofilo").GetComponent<LifeNeu>();
    }

    void Update()
    {
        if (onOffAux == true)
        {
            Move();
        }
        MakeBehaviour();
    }
    private void OnTriggerEnter(Collider cl)
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
        else if (cl.tag == "HitRecibedBacteria" && sh != false)
        {
            life.lifeNeu = life.lifeNeu - ba.force;
        }
        else if (cl.tag == "PunchHekke" && sh != false)
        {
            life.lifeNeu = life.lifeNeu - he.force;
        }

    }
    private void OnTriggerStay(Collider cl)
    {
        if (cl.tag == "Bacteria" && sh == true)
        {
            nav.stoppingDistance = 0.7f;
            float distance = Vector3.Distance(cl.transform.position, transform.position);
            transform.LookAt(cl.transform);
            if (distance > nav.stoppingDistance)
            {
                currentState = STATE.RUN;
                speed = 4f;
            }
            else if (distance <= nav.stoppingDistance)
            {
                speed = 2f;
                onOffAux = false;
                currentState = STATE.PUNCH;
            }
        }
        else if (cl.tag == "Hekke" && sh == true)
        {
            nav.stoppingDistance = 1.5f;
            float distance = Vector3.Distance(cl.transform.position, transform.position);
            transform.LookAt(cl.transform);
            if (distance > nav.stoppingDistance)
            {
                currentState = STATE.RUN;
                speed = 4f;
            }
            else if (distance <= nav.stoppingDistance)
            {
                speed = 2f;
                onOffAux = false;
                currentState = STATE.PUNCH;
            }
        }
        else if (cl.tag == "zombie")
        {
            onOffAux = true;
            currentState = STATE.WALK;
        }
    }
    private void OnTriggerExit(Collider cl)
    {
        if (cl.tag == "Bacteria" || cl.tag == "Hekke")
        {
            onOffAux = true;
            currentState = STATE.WALK;
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
            case STATE.IDLE: // Si el estado es IDLE
                Idle(); //Correr método Idle
                break; // Parar
            case STATE.WALK: // Si el estado es WALK
                Walk(); //Correr método Walk
                break; // Parar
            case STATE.RUN: // Si el estado es WALK
                Run(); //Correr método Walk
                break; // Parar
            case STATE.PUNCH: // Si el estado es WALK
                Punch(); //Correr método Walk
                break; // Parar
            case STATE.KICK: // Si el estado es WALK
                Kick(); //Correr método Walk
                break; // Parar
            case STATE.DEFENCE: // Si el estado es WALK
                Defence(); //Correr método Walk
                break; // Parar
            default: //Por defecto
                Idle(); //Correr método Idle
                break; // Parar
        }
    }
    void Walk() //Método caminar
    {
        anim.SetInteger("States", 2);
    }
    void Idle() //Método caminar
    {
        anim.SetInteger("States", 0);
    }
    void Run() //Método caminar
    {
        anim.SetInteger("States", 1);
    }
    void Punch() //Método caminar
    {
        anim.SetInteger("States", 3);
    }
    void Kick() //Método caminar
    {
        anim.SetInteger("States", 4);
    }
    void Defence() //Método caminar
    {
        anim.SetInteger("States", 5);
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
