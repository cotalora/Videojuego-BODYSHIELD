using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SelectorScript : MonoBehaviour
{
    enum CHARACTER
    {
        BAO, EOS, LIN, MON, NEU
    }
    CHARACTER currentCharacter = CHARACTER.NEU;
    public GameObject p1, p2, p3, p4, p5;
    public Image neu;
    public Image bao;
    public Image eos;
    public Image lin;
    public Image mon;
    public Image neuS;
    public Image baoS;
    public Image eosS;
    public Image linS;
    public Image monS;
    GameObject bSGameObjet;
    GameObject eSGameObjet;
    GameObject lSGameObjet;
    GameObject mSGameObjet;
    GameObject nSGameObjet;
    BaoScript bS;
    EosScript eS;
    LinScript lS;
    MonScript mS;
    NeuScript nS;

    // Start is called before the first frame update
    void Start()
    {
        bSGameObjet = GameObject.Find("Basofilo");
        eSGameObjet = GameObject.Find("Eosinofilo");
        lSGameObjet = GameObject.Find("Linfosito");
        mSGameObjet = GameObject.Find("Monocito");
        nSGameObjet = GameObject.Find("Neutrofilo");
        bS = p1.GetComponent<BaoScript>();
        eS = p2.GetComponent<EosScript>();
        lS = p3.GetComponent<LinScript>();
        mS = p4.GetComponent<MonScript>();
        nS = p5.GetComponent<NeuScript>();
        CameraFollow.target = p5.GetComponent<Transform>();
        MiniCam.target = p5.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCondition();
        ChangeChraacter();
    }
    void CheckCondition ()
    {
        if (Input.GetKeyDown("2"))
        {
            currentCharacter = CHARACTER.BAO;
        }
        else if (Input.GetKeyDown("3"))
        {
            currentCharacter = CHARACTER.EOS;
        }
        else if (Input.GetKeyDown("4"))
        {
            currentCharacter = CHARACTER.LIN;
        }
        else if (Input.GetKeyDown("5"))
        {
            currentCharacter = CHARACTER.MON;
        }
        else if (Input.GetKeyDown("1"))
        {
            currentCharacter = CHARACTER.NEU;
        }
    }
    void ChangeChraacter()
    {
        switch (currentCharacter) // Dependiendo del estado
        {
            case CHARACTER.BAO: // Si el estado es IDLE
                Bao(); //Correr método Idle
                break; // Parar
            case CHARACTER.EOS: // Si el estado es WALK
                Eos(); //Correr método Walk
                break; // Parar
            case CHARACTER.LIN: // Si el estado es WALK
                Lin(); //Correr método Walk
                break; // Parar
            case CHARACTER.MON: // Si el estado es WALK
                Mon(); //Correr método Walk
                break; // Parar
            case CHARACTER.NEU: // Si el estado es WALK
                Neu(); //Correr método Walk
                break; // Parar
            default: //Por defecto
                Neu(); //Correr método Idle
                break; // Parar
        }
    }
    void Bao()
    {
        neu.enabled = false;
        bao.enabled = true;
        eos.enabled = false;
        lin.enabled = false;
        mon.enabled = false;

        neuS.enabled = true;
        baoS.enabled = false;
        eosS.enabled = true;
        linS.enabled = true;
        monS.enabled = true;
        
        CameraFollow.target = p1.GetComponent<Transform>();
        MiniCam.target = p1.GetComponent<Transform>();
        bS.enabled = true;
        bSGameObjet.GetComponent<IABaoScript>().enabled = false;
        bSGameObjet.GetComponent<NavMeshAgent>().enabled = false;
        bSGameObjet.GetComponent<BoxCollider>().enabled = false;
        eS.enabled = false;
        eSGameObjet.GetComponent<IAEosScript>().enabled = true;
        eSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        eSGameObjet.GetComponent<BoxCollider>().enabled = true;
        lS.enabled = false;
        lSGameObjet.GetComponent<IALinScript>().enabled = true;
        lSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        lSGameObjet.GetComponent<BoxCollider>().enabled = true;
        mS.enabled = false;
        mSGameObjet.GetComponent<IAMonScript>().enabled = true;
        mSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        mSGameObjet.GetComponent<BoxCollider>().enabled = true;
        nS.enabled = false;
        nSGameObjet.GetComponent<IANeuScript>().enabled = true;
        nSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        nSGameObjet.GetComponent<BoxCollider>().enabled = true;
    }
    void Eos()
    {
        neu.enabled = false;
        bao.enabled = false;
        eos.enabled = true;
        lin.enabled = false;
        mon.enabled = false;

        neuS.enabled = true;
        baoS.enabled = true;
        eosS.enabled = false;
        linS.enabled = true;
        monS.enabled = true;

        CameraFollow.target = p2.GetComponent<Transform>();
        MiniCam.target = p2.GetComponent<Transform>();
        bS.enabled = false;
        bSGameObjet.GetComponent<IABaoScript>().enabled = true;
        bSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        bSGameObjet.GetComponent<BoxCollider>().enabled = true;
        eS.enabled = true;
        eSGameObjet.GetComponent<IAEosScript>().enabled = false;
        eSGameObjet.GetComponent<NavMeshAgent>().enabled = false;
        eSGameObjet.GetComponent<BoxCollider>().enabled = false;
        lS.enabled = false;
        lSGameObjet.GetComponent<IALinScript>().enabled = true;
        lSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        lSGameObjet.GetComponent<BoxCollider>().enabled = true;
        mS.enabled = false;
        mSGameObjet.GetComponent<IAMonScript>().enabled = true;
        mSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        mSGameObjet.GetComponent<BoxCollider>().enabled = true;
        nS.enabled = false;
        nSGameObjet.GetComponent<IANeuScript>().enabled = true;
        nSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        nSGameObjet.GetComponent<BoxCollider>().enabled = true;
    }
    void Lin()
    {
        neu.enabled = false;
        bao.enabled = false;
        eos.enabled = false;
        lin.enabled = true;
        mon.enabled = false;

        neuS.enabled = true;
        baoS.enabled = true;
        eosS.enabled = true;
        linS.enabled = false;
        monS.enabled = true;

        CameraFollow.target = p3.GetComponent<Transform>();
        MiniCam.target = p3.GetComponent<Transform>();
        bS.enabled = false;
        bSGameObjet.GetComponent<IABaoScript>().enabled = true;
        bSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        bSGameObjet.GetComponent<BoxCollider>().enabled = true;
        eS.enabled = false;
        eSGameObjet.GetComponent<IAEosScript>().enabled = true;
        eSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        eSGameObjet.GetComponent<BoxCollider>().enabled = true;
        lS.enabled = true;
        lSGameObjet.GetComponent<IALinScript>().enabled = false;
        lSGameObjet.GetComponent<NavMeshAgent>().enabled = false;
        lSGameObjet.GetComponent<BoxCollider>().enabled = false;
        mS.enabled = false;
        mSGameObjet.GetComponent<IAMonScript>().enabled = true;
        mSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        mSGameObjet.GetComponent<BoxCollider>().enabled = true;
        nS.enabled = false;
        nSGameObjet.GetComponent<IANeuScript>().enabled = true;
        nSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        nSGameObjet.GetComponent<BoxCollider>().enabled = true;
    }
    void Mon()
    {
        neu.enabled = false;
        bao.enabled = false;
        eos.enabled = false;
        lin.enabled = false;
        mon.enabled = true;

        neuS.enabled = true;
        baoS.enabled = true;
        eosS.enabled = true;
        linS.enabled = true;
        monS.enabled = false;

        CameraFollow.target = p4.GetComponent<Transform>();
        MiniCam.target = p4.GetComponent<Transform>();
        bS.enabled = false;
        bSGameObjet.GetComponent<IABaoScript>().enabled = true;
        bSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        bSGameObjet.GetComponent<BoxCollider>().enabled = true;
        eS.enabled = false;
        eSGameObjet.GetComponent<IAEosScript>().enabled = true;
        eSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        eSGameObjet.GetComponent<BoxCollider>().enabled = true;
        lS.enabled = false;
        lSGameObjet.GetComponent<IALinScript>().enabled = true;
        lSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        lSGameObjet.GetComponent<BoxCollider>().enabled = false;
        mS.enabled = true;
        mSGameObjet.GetComponent<IAMonScript>().enabled = false;
        mSGameObjet.GetComponent<NavMeshAgent>().enabled = false;
        mSGameObjet.GetComponent<BoxCollider>().enabled = false;
        nS.enabled = false;
        nSGameObjet.GetComponent<IANeuScript>().enabled = true;
        nSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        nSGameObjet.GetComponent<BoxCollider>().enabled = true;
    }
    void Neu()
    {
        neu.enabled = true;
        bao.enabled = false;
        eos.enabled = false;
        lin.enabled = false;
        mon.enabled = false;

        neuS.enabled = false;
        baoS.enabled = true;
        eosS.enabled = true;
        linS.enabled = true;
        monS.enabled = true;

        CameraFollow.target = p5.GetComponent<Transform>();
        MiniCam.target = p5.GetComponent<Transform>();
        bS.enabled = false;
        bSGameObjet.GetComponent<IABaoScript>().enabled = true;
        bSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        bSGameObjet.GetComponent<BoxCollider>().enabled = true;
        eS.enabled = false;
        eSGameObjet.GetComponent<IAEosScript>().enabled = true;
        eSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        eSGameObjet.GetComponent<BoxCollider>().enabled = true;
        lS.enabled = false;
        lSGameObjet.GetComponent<IALinScript>().enabled = true;
        lSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        lSGameObjet.GetComponent<BoxCollider>().enabled = true;
        mS.enabled = false;
        mSGameObjet.GetComponent<IAMonScript>().enabled = true;
        mSGameObjet.GetComponent<NavMeshAgent>().enabled = true;
        mSGameObjet.GetComponent<BoxCollider>().enabled = true;
        nS.enabled = true;
        nSGameObjet.GetComponent<IANeuScript>().enabled = false;
        nSGameObjet.GetComponent<NavMeshAgent>().enabled = false;
        nSGameObjet.GetComponent<BoxCollider>().enabled = false;
    }
}
