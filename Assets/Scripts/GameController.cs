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
    private static string intro;
    [SerializeField] public int currentLevel = 0;
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
            AudioManager.instance.Play("MainTheme");
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

    void Awake(){
        if(thisScene=="")
        {
            thisScene = SceneManager.GetActiveScene().name;
        }
        
        if(currentLevel > 0)
        {
            intro = "Level" + currentLevel.ToString() + "Open";
            AudioManager.instance.Play(intro);
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
        AudioManager.instance.Stop(intro);
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
        if(player)
        {
            /* 
             * Not needed if died via laser, but current lose path from barrel explosion 
             * still allows player to move, so I put this here - Vincent
             */
            player.Stop();
        }
        
        AudioManager.instance.Stop("MainTheme");
        AudioManager.instance.Stop(intro);
        string deathSound = "Death" + (1 + numDeaths%14).ToString();
        //Debug.Log(deathSound);
        AudioManager.instance.Play(deathSound);
        numDeaths++;
        gameOver = true;
        isPlayingSong = false;
    }

    public void Restart()
    {
        AudioManager.instance.PlayOneShot("Button");
        AudioManager.instance.Stop(intro);
        if(thisScene!="")
        {
            isPlayingSong = false;
            SceneManager.LoadScene(thisScene);
        }
    }

    public void Menu()
    {
        AudioManager.instance.PlayOneShot("Button");
        AudioManager.instance.Stop("MainTheme");
        AudioManager.instance.Stop(intro);
        if(menuScene!="")
        {
            SceneManager.LoadScene(menuScene);
        }
            
    }

    public void Next()
    {
        AudioManager.instance.PlayOneShot("Button");
        AudioManager.instance.Stop(intro);
        if(nextScene!="")
        {
            SceneManager.LoadScene(nextScene);
        }
    }


    public void Pause()
    {
        AudioManager.instance.Pause(intro,true);
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
        AudioManager.instance.Pause(intro,false);
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
