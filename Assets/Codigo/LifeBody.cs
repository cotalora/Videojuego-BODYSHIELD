using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class LifeBody : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 1f;
    LifeBao bao;
    LifeMon mon;
    LifeLin lin;
    LifeEos eos;
    LifeNeu neu;
    UsuarioScript user;
    ScoreScript scoreScript;
    FaseCountScript faseCount;
    TimePlaying timePlaying;

    Data data = new Data();
    GameObject tex;
    float crono = 3f;
    public string file = "player.txt";
    void Start()
    {
        bao = GameObject.Find("Basofilo").GetComponent<LifeBao>();
        mon = GameObject.Find("Monocito").GetComponent<LifeMon>();
        lin = GameObject.Find("Linfosito").GetComponent<LifeLin>();
        eos = GameObject.Find("Eosinofilo").GetComponent<LifeEos>();
        neu = GameObject.Find("Neutrofilo").GetComponent<LifeNeu>();
        user = GameObject.Find("Usuario").GetComponent<UsuarioScript>();
        scoreScript = GameObject.Find("AllScore").GetComponent<ScoreScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        timePlaying = GameObject.Find("TimePlaying").GetComponent<TimePlaying>();
        tex = GameObject.Find("UI/GameOver");
        tex.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Load();
        Debug.Log(data.score);
        if (life <= -1048 || bao.lifeBao <= -281 || mon.life <= -283 || lin.lifeLin <= -281.5f || eos.life <= -281 || neu.lifeNeu <= -275.63f)
        {
            data.usuario = user.usuarioname;
            data.score = scoreScript.scoree;
            data.fase = faseCount.fase;
            data.time = Mathf.RoundToInt(timePlaying.timeCount);
            tex.SetActive(true);
            crono -= Time.deltaTime;
            if (crono <= 0)
            {
                Debug.Log(data.score);
                Save();
                StartCoroutine(Main.instance.web.RegisterUser(data.usuario,data.score,data.fase,data.time));
                SceneManager.LoadScene("EndMenu");
            }
        }
    }
    public void Save()
    {

        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }
    public void Load(){
        data = new Data();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }
    public void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }
    public string GetFilePath(string fileName)
    {
        Debug.Log(Application.dataPath + "/" + fileName);
        return Application.dataPath + "/" + fileName;
    }
    public string ReadFromFile(string fileName){
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        } else {
            Debug.Log("No encontrado");
        }
        return "";
    }

}
