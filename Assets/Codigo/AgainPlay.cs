using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AgainPlay : MonoBehaviour
{
    FaseCountScript fase;
    ScoreScript score;
    public Image image;
    public Image button;
    void Start()
    {
        score = GameObject.Find("AllScore").GetComponent<ScoreScript>();
        fase = GameObject.Find("Fase").GetComponent<FaseCountScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void StartGameAgain()
    {
        fase.fase = 1;
        score.scoree = 0;
        SceneManager.LoadScene("SampleScene");        
    }
    public void EnableCredits()
    {
        image.enabled = true;
        button.enabled = true;
    }
    public void DisableCredits()
    {
        image.enabled = false;
        button.enabled = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
