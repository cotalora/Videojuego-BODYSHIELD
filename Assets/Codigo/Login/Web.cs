using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    ControllerLoading controllerLoading;
    void Start()
    {
        StartCoroutine(GetUsers());
        //StartCoroutine(RegisterUser("Dagdas"));
        controllerLoading = GameObject.Find("Loading").GetComponent<ControllerLoading>();
    }
    IEnumerator GetUsers()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://bodyshield.dx.am/Game/GetUsers.php"))
        {
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                byte[] results = www.downloadHandler.data;
            }
        }
    }
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://bodyshield.dx.am/Game/Login.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "Login exitoso.")
                {
                    SceneManager.LoadScene("MainMenu");
                }
                else if (www.downloadHandler.text == "Usuario o contraseña incorrecta.")
                {
                    controllerLoading.activator = false;
                    controllerLoading.text.text = www.downloadHandler.text;
                }
                else if (www.downloadHandler.text == "Usuario no existe.")
                {
                    controllerLoading.activator = false;
                    controllerLoading.text.text = www.downloadHandler.text;
                }
            }
        }
    }
    public IEnumerator RegisterUser(string username, int score, int fase, int time)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("score", score);
        form.AddField("fase", fase);
        form.AddField("time", time);
        using (UnityWebRequest www = UnityWebRequest.Post("http://bodyshield.dx.am/Game/RegisterUsers.php", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
