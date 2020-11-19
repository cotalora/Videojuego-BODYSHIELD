using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadData: MonoBehaviour
{
    LifeBody lifeBody = new LifeBody();
    Data data = new Data();
    // Start is called before the first frame update
    void Start()
    {
        Load();
        Debug.Log(data.score);
        StartCoroutine(Main.instance.web.RegisterUser(data.usuario,data.score,data.fase,data.time));
    }
    public void Load(){
        data = new Data();
        string json = ReadFromFile(lifeBody.file);
        JsonUtility.FromJsonOverwrite(json, data);
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
