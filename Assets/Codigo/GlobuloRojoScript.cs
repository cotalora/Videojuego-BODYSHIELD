using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GlobuloRojoScript : MonoBehaviour
{
    enum STATE
    {
        WALK, RUN, TERRIFIED
    }
    STATE currentState = STATE.RUN;
    float currentDistance;
    NavMeshAgent nav;
    Animator anim;
    float speed = 1.2f;
    bool onOffAux = true;
    void Start()
    {
        float x = Random.Range(-49.6f, 49.6f);
        float z = Random.Range(-40.8f, 40.8f);
        transform.position = new Vector3 (x,0,z);
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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
        if (cl.tag == "Obstacle")
        {
            StartCoroutine(Rotate(Vector3.up, 90, 1.0f));
        }
        else if (cl.tag == "Wall")
        {
            int ram = Random.Range(89, 181);
            StartCoroutine(Rotate(Vector3.up, ram, 1.0f));
        }
        else if (cl.tag == "Inf")
        {
            int ram = Random.Range(89, 181);
            StartCoroutine(Rotate(Vector3.up, ram, 1.0f));
        }
    }
    private void OnTriggerStay(Collider cl)
    {
        if (cl.tag == "Enemy")
        {
            float distance = Vector3.Distance(cl.transform.position, transform.position);
            if (distance > nav.stoppingDistance)
            {
                speed = 1.2f;
            }
            else if (distance <= nav.stoppingDistance)
            {
                onOffAux = false;
                currentState = STATE.TERRIFIED;
            }
        }
        if (cl.tag == "Neu" || cl.tag == "Mon" || cl.tag == "Lin" || cl.tag == "Eos" || cl.tag == "Bao")
        {
            this.gameObject.transform.gameObject.tag = "gloaux";
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            onOffAux = true;
            currentState = STATE.RUN;
        }
        else if (col.tag == "Neu")
        {
            this.gameObject.transform.gameObject.tag = "Blood";
        }
        else if (col.tag == "Bao")
        {
            this.gameObject.transform.gameObject.tag = "Blood";
        }
        else if (col.tag == "Lin")
        {
            this.gameObject.transform.gameObject.tag = "Blood";
        }
        else if (col.tag == "Eos")
        {
            this.gameObject.transform.gameObject.tag = "Blood";
        }
        else if (col.tag == "Mon")
        {
            this.gameObject.transform.gameObject.tag = "Blood";
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
            case STATE.WALK:
                Walk();
                break;
            case STATE.RUN:
                Run();
                break;
            case STATE.TERRIFIED:
                Terrified(); //Correr método Walk
                break; // Parar
        }
    }
    void Run() //Método caminar
    {
        anim.SetInteger("States", 2);
    }
    void Terrified() //Método caminar
    {
        anim.SetInteger("States", 1);
    }
    void Walk()
    {
        anim.SetInteger("States", 0);
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
