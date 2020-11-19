using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    float timeCountPill = 0f;
    float timeCountRojo = 0f;
    float timeCountVirus = 0f;
    float timeCountBacteria = 0f;
    float timeCountParasito = 0f;
    float timeCountHekke = 0f;
    float timeCountInfla = 0f;

    public GameObject capsule;
    public GameObject virus;
    public GameObject bacteria;
    public GameObject parasito;
    public GameObject hekke;
    public GameObject infla;
    public GameObject rojo;
    int countSpawnPills = 0;
    int countSpawnVirus = 0;
    int countSpawnBacterias = 0;
    int countSpawnParasitos = 0;
    int countSpawnHekkes = 0;
    int countSpawnInfla = 0;
    int countSpawnRojo = 0;
    int virusR = 0;
    int bacteriaR = 0;
    int parasitoR = 0;
    int hekkeR = 0;
    int inflaR = 0;
    int rojoR = 0;
    //____________________________________________________
    GameObject[] getCountBacterias;
    public int countBacterias = 0;
    GameObject[] getCountVirus;
    public int countVirus = 0;
    GameObject[] getCountParasitos;
    public int countParasitos = 0;
    GameObject[] getCountHekkes;
    public int countHekkes = 0;
    GameObject[] getCountInfla;
    public int countInfla = 0;
    GameObject[] getCountZombies;
    public int countZombies = 0;
    float cantEnem = 0;
    float cantEnemMinus = 0;
    float res = 0;
    LifeBody healthBody;
    //GameObject capsuleClone;
    void Start()
    {
        virusR = Random.Range(3, 8);
        bacteriaR = Random.Range(9, 26);
        parasitoR = Random.Range(7, 16);
        hekkeR = Random.Range(3, 7);
        inflaR = Random.Range(3, 8);
        rojoR = Random.Range(10, 12);
        cantEnem = bacteriaR + virusR + parasitoR + hekkeR + inflaR;
        cantEnemMinus = (cantEnem - 1);
        healthBody = GameObject.Find("Bodyy").GetComponent<LifeBody>();
    }

    // Update is called once per frame
    void Update()
    {
        Pills();
        Virus();
        Bacteria();
        Parasito();
        Hekke();
        Inflamacion();
        Rojo();

        GetCountBacterias();
        GetCountVirus();
        GetCountParasitos();
        GetCountHekkes();
        GetCountInfla();
        GetCountZombies();


        //Debug.Log(cantEnem);
        //Debug.Log((cantEnemMinus*1115/cantEnem) / cantEnem);
    }
    void GetCountZombies()
    {
        getCountZombies = GameObject.FindGameObjectsWithTag("zombie");
        countZombies = getCountZombies.Length;
        //Debug.Log("Zombies: "+ countZombies);
    }
    void GetCountBacterias()
    {
        getCountBacterias = GameObject.FindGameObjectsWithTag("Bacteria");
        countBacterias = getCountBacterias.Length;
    }
    void GetCountVirus()
    {
        getCountVirus = GameObject.FindGameObjectsWithTag("Virus");
        countVirus = getCountVirus.Length;
    }
    void GetCountParasitos()
    {
        getCountParasitos = GameObject.FindGameObjectsWithTag("Parasito");
        countParasitos = getCountParasitos.Length;
    }
    void GetCountHekkes()
    {
        getCountHekkes = GameObject.FindGameObjectsWithTag("Hekke");
        countHekkes = getCountHekkes.Length;
    }
    void GetCountInfla()
    {
        getCountInfla = GameObject.FindGameObjectsWithTag("Inf");
        countInfla = getCountInfla.Length;
    }
    void Pills()
    {
        if (countSpawnPills < 4)
        {
            timeCountPill -= Time.deltaTime;
            if (timeCountPill <= 0)
            {
                timeCountPill = TimerPill();
            }
        }
    }
    int TimerPill()
    {
        Instantiate(capsule, transform.position, Quaternion.identity);
        Instantiate(capsule, transform.position, Quaternion.identity);
        countSpawnPills = countSpawnPills + 2;
        return 50;
    }
    //------------------------------------------------
    void Virus()
    {
        if (countSpawnVirus < virusR && countVirus > 0)
        {
            timeCountVirus -= Time.deltaTime;
            if (timeCountVirus <= 0)
            {
                timeCountVirus = TimerVirus();
            }
        }
    }
    int TimerVirus()
    {
        var clone = Instantiate(virus, transform.position, Quaternion.identity);
        countSpawnVirus = countSpawnVirus + 1;
        clone.name = "Virus " + countSpawnVirus;
        healthBody.life = healthBody.life - ((cantEnemMinus*1115/cantEnem) / cantEnem) + 1;
        return 40;
    }
    //------------------------------------------------
    void Parasito()
    {
        if (countSpawnParasitos < parasitoR && countParasitos > 0)
        {
            timeCountParasito -= Time.deltaTime;
            if (timeCountParasito <= 0)
            {
                timeCountParasito = TimerParasito();
            }
        }
    }
    int TimerParasito()
    {
        var clone = Instantiate(parasito, transform.position, Quaternion.identity);
        countSpawnParasitos = countSpawnParasitos + 1;
        clone.name = "Parasito " + countSpawnParasitos;
        healthBody.life = healthBody.life - ((cantEnemMinus*1115/cantEnem) / cantEnem) + 1;
        return 40;
    }
    //------------------------------------------------
    void Bacteria()
    {
        if (countSpawnBacterias < bacteriaR && countBacterias > 0)
        {
            timeCountBacteria -= Time.deltaTime;
            if (timeCountBacteria <= 0)
            {
                timeCountBacteria = TimerBacteria();
            }
        }
    }
    int TimerBacteria()
    {
        var clone = Instantiate(bacteria, transform.position, Quaternion.identity);
        countSpawnBacterias += 1;
        clone.name = "Bacteria " + countSpawnBacterias;
        healthBody.life = healthBody.life - ((cantEnemMinus*1115/cantEnem) / cantEnem) + 1;
        return 40;
    }
    //------------------------------------------------
    void Hekke()
    {
        if (countSpawnHekkes < hekkeR && countHekkes > 0)
        {
            timeCountHekke -= Time.deltaTime;
            if (timeCountHekke <= 0)
            {
                timeCountHekke = TimerHekke();
            }
        }
    }
    int TimerHekke()
    {
        var clone = Instantiate(hekke, transform.position, Quaternion.identity);
        countSpawnHekkes += 1;
        clone.name = "Hekke " + countSpawnHekkes;
        healthBody.life = healthBody.life - ((cantEnemMinus*1115/cantEnem) / cantEnem) + 1;
        return 40;
    }
    //------------------------------------------------
    void Inflamacion()
    {
        if (countSpawnInfla < inflaR && countInfla > 0)
        {
            timeCountInfla -= Time.deltaTime;
            if (timeCountInfla <= 0)
            {
                timeCountInfla = TimerInflamacion();
            }
        }
    }
    int TimerInflamacion()
    {
        var clone = Instantiate(infla, transform.position, Quaternion.identity);
        countSpawnInfla += 1;
        clone.name = "Inflamacion " + countSpawnInfla;
        healthBody.life = healthBody.life - ((cantEnemMinus*1115/cantEnem) / cantEnem) + 1;
        return 40;
    }
    //------------------------------------------------
    void Rojo()
    {
        if (countSpawnRojo < rojoR)
        {
            timeCountRojo -= Time.deltaTime;
            if (timeCountRojo <= 0)
            {
                timeCountRojo = TimerRojo();
            }
        }
    }
    int TimerRojo()
    {
        var clone = Instantiate(rojo, transform.position, Quaternion.identity);
        countSpawnRojo += 1;
        clone.name = "Globulo Rojo " + countSpawnRojo;
        return 1;
    }
}
