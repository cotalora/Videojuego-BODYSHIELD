using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FaseCountScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int fase = 1;
    //----------------NEU----------------
    public float AumlifeNeu = 0;
    public float AumforceNeu = 0;
    //----------------BAO----------------
    public float AumlifeBao = 0;
    //----------------LIN----------------
    public float AumlifeLin = 0;
    public float AumforceLin = 0;
    //----------------EOS----------------
    public float AumlifeEos = 0;
    public float AumforceEos = 0;
    //----------------MON----------------
    public float AumlifeMon = 0;
    //----------------BACTERIA-------------------
    public float AumlifeBacteria = 0;
    public float AumforceBacteria = 0;
    public int AumScoreBacteria = 0;
    //----------------PARASITO-------------------
    public float AumlifeParasito = 0;
    public float AumforceParasito = 0;
    public int AumScoreParasito = 0;
    //----------------HEKKE----------------------
    public float AumlifeHekke = 0;
    public float AumforceHekke = 0;
    public int AumScoreHekke = 0;
    //----------------VIRUS----------------------
    public float AumlifeVirus = 0;
    public float AumforceVirus = 0;
    public int AumScoreVirus = 0;
    //----------------INFLAMACION----------------
    public float AumforceInfla = 0;
    public int AumScoreInfla = 0;
    Text text;
    GameObject fasee;
    
    void Start()
    {
        text = GameObject.Find(this.gameObject.name + "/Canvas/FaseUI/Image/Text").GetComponent<Text>();
        fasee = GameObject.Find(this.gameObject.name + "/Canvas/FaseUI");
    }
    void Awake(){
        int count = FindObjectsOfType<FaseCountScript>().Length;
        if (count != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = fase.ToString();
        //Debug.Log(fase);
        if (SceneManager.GetActiveScene().name == "EndMenu")
        {
            fasee.SetActive(false);
        }
        else
        {
            fasee.SetActive(true);
        }
    }
}
