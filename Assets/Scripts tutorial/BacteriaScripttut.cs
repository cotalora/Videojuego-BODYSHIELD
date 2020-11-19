using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BacteriaScripttut : MonoBehaviour
{
    enum STATE
    {
        IDLE, RUN, WALK, ATTACK, FALLING
    }
    STATE currentState = STATE.WALK;
    NavMeshAgent nav;
    Animator anim;
    LifeBacteriatut life;
    Neutut lifee;
    Animator ne;
    float speed = 1f;
    public bool onOffAux = true;
    public bool val = true;
    public bool de = true;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        life = GameObject.Find(this.gameObject.name).GetComponent<LifeBacteriatut>();
        lifee = GameObject.Find("NeutrÃ³filo [pequeÃ±o)T").GetComponent<Neutut>();
    }

    void Update()
    {
        if (onOffAux == true)
        {
            Move();
        }
        else if (de == false)
        {
            currentState = STATE.FALLING;
        }
        MakeBehaviour();
    }
    private void OnTriggerEnter(Collider cl)
    {
        if (val == true)
        {
            if (cl.tag == "Golpe")
            {
                life.life = life.life - lifee.force;
            }
        }
    }
    private void OnTriggerStay(Collider cl)
    {
        if (val == true)
        {
            if (cl.tag == "Neu")
            {
                float distance = Vector3.Distance(cl.transform.position, transform.position);
                transform.LookAt(cl.transform);
                if (distance > nav.stoppingDistance)
                {
                    onOffAux = true;
                    currentState = STATE.RUN;
                    speed = 2f;
                }
                else if (distance <= nav.stoppingDistance)
                {
                    onOffAux = false;
                    currentState = STATE.ATTACK;
                }
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
