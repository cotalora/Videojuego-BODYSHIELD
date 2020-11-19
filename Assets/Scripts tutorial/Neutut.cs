using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutut : MonoBehaviour
{
     enum STATE
    {
        IDLE, WALK, RUN, PUNCH, KICK, DEFENCE
    }
    STATE currentState = STATE.IDLE;
    Animator anim;
    float speed = 0;
    float turnSpeed = 400f;
    float translation;
    float rotation;
    public float force = 0.45f;
    
    LifeBacteriatut ba;
    
    public bool onOffAux = true;
    public bool val = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        ba = GameObject.Find("BacteriaT").GetComponent<LifeBacteriatut>();
    }
     void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
         if (onOffAux == true)
        {
            Movement();
        }
        CheckConditions();
        MakeBehaviour();
    }
    private void OnTriggerEnter(Collider col)
    {
     
    }
    void Movement()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
    void CheckConditions() //Conocer condición
    {
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            if (Input.GetKey(KeyCode.W)) //Si presiono la tecla "W"
            {
                speed = 6f;
                currentState = STATE.RUN;
                if ((anim.GetCurrentAnimatorStateInfo(0).IsTag("Punch") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsTag("Kick") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsTag("Defence") != true))
                {
                    onOffAux = true;
                }
            }
        }
        else if (Input.GetKey(KeyCode.W)) //Si presiono la tecla "W"
        {
            currentState = STATE.WALK;
            speed = 4f;
            if ((anim.GetCurrentAnimatorStateInfo(0).IsTag("Punch") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsTag("Kick") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsTag("Defence") != true))
            {
                onOffAux = true;
            }
        }
        else if (Input.GetKey(KeyCode.A)) //Si presiono la tecla "W"
        {
            currentState = STATE.WALK;
            speed = 4f;
            if ((anim.GetCurrentAnimatorStateInfo(0).IsTag("Punch") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsTag("Kick") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsTag("Defence") != true))
            {
                onOffAux = true;
            }
        }
        else if (Input.GetKey(KeyCode.D)) //Si presiono la tecla "W"
        {
            currentState = STATE.WALK;
            speed = 4f;
            if ((anim.GetCurrentAnimatorStateInfo(0).IsTag("Punch") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsTag("Kick") != true) && (anim.GetCurrentAnimatorStateInfo(0).IsTag("Defence") != true))
            {
                onOffAux = true;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            currentState = STATE.PUNCH;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            currentState = STATE.KICK;
        }
        else if (Input.GetMouseButton(2))
        {
            currentState = STATE.DEFENCE;
        }
        else
        {
            currentState = STATE.IDLE;
            speed = 2f;
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
}
