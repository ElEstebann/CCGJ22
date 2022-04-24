using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string nextScene;
    [SerializeField] string menuScene;
    [SerializeField] string thisScene;
    public GameObject winOverlay;
    public GameObject loseOverlay;
    public GameObject pauseOverlay;
    public PlayerMovement player;
    private bool gameOver = false;
    private bool isPaused = false;
    public static bool isPlayingSong = false;
    private static int numDeaths = 0;
    void Start()
    {
        winOverlay = GameObject.Find("Win Overlay");
        if(winOverlay)
        {
            winOverlay.SetActive(false);
        }
        loseOverlay = GameObject.Find("Lose Overlay");
        if(loseOverlay)
        {
            loseOverlay.SetActive(false);
        }
        pauseOverlay = GameObject.Find("Pause Overlay");
        if(pauseOverlay)
        {
            pauseOverlay.SetActive(false);
        }
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>();
        if(!isPlayingSong)
        {
            isPlayingSong = true;
            AudioManager.instance.PlayOneShot("MainTheme");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(!gameOver)
            {
                if(!isPaused)
                {
                    Pause();
                }
                else
                {
                    Unpause();
                }
                
            }
            
        }
        
    }
    public void Win()
    {
        if(winOverlay)
        {
            winOverlay.SetActive(true);
        }
        if(player)
        {
            player.Stop();
        }
        AudioManager.instance.Stop("MainTheme");
        AudioManager.instance.Play("Win");
        isPlayingSong = false;
        gameOver =true;
    }
    
    public void Lose()
    {
        if(isPaused)
        {
            Unpause();
        }
        if(loseOverlay)
        {
            loseOverlay.SetActive(true);
        }
        
        AudioManager.instance.Stop("MainTheme");
        string deathSound = "Death" + (1 + numDeaths%14).ToString();
        Debug.Log(deathSound);
        AudioManager.instance.Play(deathSound);
        numDeaths++;
        gameOver = true;
        isPlayingSong = false;
    }

    public void Restart()
    {
        if(thisScene!="")
        {
            SceneManager.LoadScene(thisScene);
        }
    }

    public void Menu()
    {
        if(menuScene!="")
        {
            SceneManager.LoadScene(menuScene);
        }
    }

    public void Next()
    {
        if(nextScene!="")
        {
            SceneManager.LoadScene(nextScene);
        }
    }


    public void Pause()
    {
        if(pauseOverlay)
        {
            pauseOverlay.SetActive(true);
        }
        if(player)
        {
            player.Stop();
        }
        isPaused = true;
        
        
    
    }
    public void Unpause()
    {
        if(pauseOverlay)
        {
            pauseOverlay.SetActive(false);
        }
        if(player)
        {
            player.Unstop();
        }
        isPaused = false;
        
        
    
    }

    

}
