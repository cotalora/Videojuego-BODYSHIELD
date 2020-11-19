using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public Image button;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");        
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialBodyShield");
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
