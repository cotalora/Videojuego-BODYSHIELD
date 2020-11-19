using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IALinScript : MonoBehaviour
{
    // Start is called before the first frame update
    enum STATE
    {
        IDLE, WALK, RUN, PUNCH, DEFENCE
    }
    STATE currentState = STATE.WALK;
    NavMeshAgent nav;
    Animator anim;
    float speed = 2f;
    LifeLin life;
    public bool onOffAux = true;
    public bool sh = false;
    LifeVirus vir;
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
        life = GameObject.Find("Linfosito").GetComponent<LifeLin>();
        vir = GameObject.Find("Virus").GetComponent<LifeVirus>();
    }

    // Update is called once per frame
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
        else if (cl.tag == "HitRecibedVirus" && sh != false)
        {
            life.lifeLin = life.lifeLin - vir.force;
        }
    }
    private void OnTriggerExit(Collider cl)
    {
        if (cl.tag == "Virus")
        {
            onOffAux = true;
            currentState = STATE.WALK;
        }
    }
    private void OnTriggerStay(Collider cl)
    {
        if (cl.tag == "Virus" && sh == true)
        {
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
    void Move()
    {
        nav.Move(transform.forward * speed * Time.deltaTime);
    }
    void Idle() //Método caminar
    {
        anim.SetInteger("States", 0);
    }
    void Walk() //Método caminar
    {
        anim.SetInteger("States", 1);
    }
    void Punch() //Método caminar
    {
        anim.SetInteger("States", 2);
    }
    void Defence() //Método caminar
    {
        anim.SetInteger("States", 3);
    }
    void Run() //Método caminar
    {
        anim.SetInteger("States", 4);
    }
    void MakeBehaviour() //Método hacer comportamiento
    {
        switch (currentState)
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
            case STATE.DEFENCE: // Si el estado es WALK
                Defence(); //Correr método Walk
                break; // Parar
            default: //Por defecto
                Idle(); //Correr método Idle
                break; // Parar
        }
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
