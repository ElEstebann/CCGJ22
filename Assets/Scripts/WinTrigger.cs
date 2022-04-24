using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController controller;
    void Start()
    {
        controller = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("YOU WIN!");
            controller.Win();
        }
    }
}
