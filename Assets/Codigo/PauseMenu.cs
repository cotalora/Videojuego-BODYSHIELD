using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    UsuarioScript user;
    ScoreScript scoreScript;
    FaseCountScript faseCount;
    TimePlaying timePlaying;

    // Update is called once per frame
    void Start()
    {
        user = GameObject.Find("Usuario").GetComponent<UsuarioScript>();
        scoreScript = GameObject.Find("AllScore").GetComponent<ScoreScript>();
        faseCount = GameObject.Find("Fase").GetComponent<FaseCountScript>();
        timePlaying = GameObject.Find("TimePlaying").GetComponent<TimePlaying>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Quit()
    {
        StartCoroutine(Main.instance.web.RegisterUser(user.usuarioname, scoreScript.scoree, faseCount.fase, Mathf.RoundToInt(timePlaying.timeCount)));
        Application.Quit();
    }
}
