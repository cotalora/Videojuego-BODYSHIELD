using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int scoree = 0;
    public static int scorer = 0;
    public Text text;
    GameObject bacteria;
    GameObject virus;
    GameObject Parasito;
    GameObject Hekke;
    GameObject score;
    void Start()
    {

        text = GameObject.Find(this.gameObject.name + "/Canvas/ScoreUI/Image (1)/Score").GetComponent<Text>();
        scorer = scoree;
        score = GameObject.Find(this.gameObject.name + "/Canvas/ScoreUI");
    }
    void Awake()
    {
        bacteria = GameObject.Find("Bacteria");
        Destroy(bacteria, 1f);
        virus = GameObject.Find("Virus");
        Destroy(virus, 1f);
        Parasito = GameObject.Find("Parasito");
        Destroy(Parasito, 1f);
        Hekke = GameObject.Find("Hekke");
        Destroy(Hekke, 1f);
        int count = FindObjectsOfType<ScoreScript>().Length;
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
        //Debug.Log("Puntaje: " + scoree);
        text.text = scoree.ToString();
        if (SceneManager.GetActiveScene().name == "EndMenu")
        {
            score.SetActive(false);
        }
        else
        {
            score.SetActive(true);
        }
    }
}
