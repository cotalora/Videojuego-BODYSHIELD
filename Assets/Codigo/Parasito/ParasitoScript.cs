using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParasitoScript : MonoBehaviour
{
    enum STATE
    {
        IDLE, RUN, ATTACK, DIYING
    }
    STATE currentState = STATE.RUN;
    NavMeshAgent nav;
    Animator anim;
    LifeParasito life;
    LifeEos eos;
    GameObject particle;
    float speed = 2f;
    public bool onOffAux = true;
    public bool val = true;
    public bool part = false;
    void Start()
    {
        float x = Random.Range(-49.6f, 49.6f);
        float z = Random.Range(-40.8f, 40.8f);
        transform.position = new Vector3(x, 0, z);
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        life = GameObject.Find(this.gameObject.name).GetComponent<LifeParasito>();
        eos = GameObject.Find("Eosinofilo").GetComponent<LifeEos>();
        particle = GameObject.Find(this.gameObject.name + "/Spiral_02.5.1 Tentacle point");
    }

    void Update()
    {
        if (onOffAux == true)
        {
            Move();
        }
        MakeBehaviour();
        particle.SetActive(part);
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
            else if (cl.tag == "HitRecibedEos")
            {
                life.life = life.life - eos.force;
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
            else if (cl.tag == "Eos")
            {
                float distance = Vector3.Distance(cl.transform.position, transform.position);
                transform.LookAt(cl.transform);
                part = true;
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
                //life.life -= 0.05f;
            }
            else if (cl.tag == "dead")
            {
                onOffAux = true;
                currentState = STATE.RUN;
                speed = 1f;
            }
        }
    }
    private void OnTriggerExit(Collider cl)
    {
        if (val == true)
        {
            if (cl.tag == "Blood" || cl.tag == "Eos")
            {
                part = false;
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
            case STATE.ATTACK:
                Attack(); //Correr método Walk
                break; // Parar
            case STATE.DIYING: // Si el estado es WALK
                Dying(); //Correr método Walk
                break; // Parar
        }
    }
    void Run() //Método caminar
    {
        anim.SetInteger("States", 3);
    }
    void Attack() //Método caminar
    {
        anim.SetInteger("States", 1);
    }
    void Idle()
    {
        anim.SetInteger("States", 0);
    }
    void Dying()
    {
        anim.SetInteger("States", 2);
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
