using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABaoScript : MonoBehaviour
{
    // Start is called before the first frame update
    enum STATE
    {
        IDLE, WALK
    }
    STATE currentState = STATE.IDLE;
    NavMeshAgent nav;
    Animator anim;
    float speed = 1.5f;
    LifeBao life;
    InflamacionColl inflamacion;
    public bool sh = false;
    public bool onOffAux = true;
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
        inflamacion = GameObject.Find("Inflamacion").GetComponentInChildren<InflamacionColl>();
        life = GameObject.Find("Basofilo").GetComponentInChildren<LifeBao>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = STATE.WALK;
        //nav.SetDestination(transform.position + new Vector3(0, 0, 2*speed*Time.deltaTime));
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
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Inf" && sh == true)
        {
            life.lifeBao = life.lifeBao - inflamacion.forcee;
        }
    }
    private void OnTriggerExit(Collider cl)
    {
        if (cl.tag == "Inf")
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
                //Idle(); //Correr método Idle
                break; // Parar
            case STATE.WALK: // Si el estado es WALK
                Walk(); //Correr método Walk
                break; // Parar
        }
    }
    void Walk() //Método caminar
    {
        anim.SetInteger("States", 1);
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
