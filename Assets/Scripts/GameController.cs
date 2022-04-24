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
    public PlayerMovement player;
    void Start()
    {
        winOverlay = GameObject.Find("Win Overlay");
        if(winOverlay)
        {
            winOverlay.SetActive(false);
        }
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
    
    public void Lose()
    {

    }

    public void Restart()
    {

    }

    public void Menu()
    {

    }

}
