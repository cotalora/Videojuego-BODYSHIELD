using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMonScript : MonoBehaviour
{
    // Start is called before the first frame update
    enum STATE
    {
        IDLE, WALK, RUN, CLEAN, DEFENCE
    }
    STATE currentState = STATE.WALK;
    NavMeshAgent nav;
    Animator anim;
    float speed = 2f;
    LifeMon lif;
    public bool onOffAux = true;
    public bool sh = false;
    LifeHekke he;
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
        lif = GameObject.Find("Monocito").GetComponent<LifeMon>();
        he = GameObject.Find("Hekke").GetComponent<LifeHekke>();
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
        else if (cl.tag == "PunchHekke" && sh != false)
        {
            lif.life = lif.life - he.forcee;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Hekke" && sh == true)
        {
            speed = 4f;
            onOffAux = true;
            currentState = STATE.RUN;
        }
    }
    private void OnTriggerExit(Collider cl)
    {
        if (cl.tag == "Hekke")
        {
            onOffAux = true;
            currentState = STATE.WALK;
            speed = 2f;
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
    void Clean() //Método caminar
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
            case STATE.CLEAN: // Si el estado es WALK
                Clean(); //Correr método Walk
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
