using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public int requiredTriggers = 0;
    public int currentTriggers = 0;
    Collider2D box;
    public Sprite openSprite;
    public Sprite closedSprite;
    public bool startOpen = false;
    private bool isOpen = false;
    
    void Start()
    {
        box = GetComponent<Collider2D>();
        //requiredTriggers = 0;
        Debug.Log(requiredTriggers);
        if(startOpen)
        {
            Open();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        if(!isOpen)
        {
            Debug.Log("Door Opened");
            AudioManager.instance.PlayOneShot("DoorOpen");
            box.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
            isOpen = true;
        }
    }

    public void Close()
    {
        if(isOpen)
        {
            Debug.Log("Door Closed");
            AudioManager.instance.PlayOneShot("DoorClose");
            box.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = closedSprite;
            isOpen = false;
        }
    }

    public void Activated(bool door)
    {
        if(door)
        {
            currentTriggers++;
            
        }
        else
        {
            currentTriggers--;
        }
        updateTriggers();
    }

    private void updateTriggers()
    {
        if(currentTriggers >= requiredTriggers)
        {
            if(!startOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
        else
        {
            if(!startOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }
    
}
