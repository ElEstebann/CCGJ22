using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string firstLevel = "LevelOne";
    public Button creditsButton;
    public Button returnButton;
    void Start()
    {
        AudioManager.instance.Play("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        AudioManager.instance.PlayOneShot("Button");
    }

    public void Begin()
    {
        
        SceneManager.LoadScene(firstLevel);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        Click();
        returnButton.Select();
    }
    public void Return()
    {
        Click();
        creditsButton.Select();
    }
}
