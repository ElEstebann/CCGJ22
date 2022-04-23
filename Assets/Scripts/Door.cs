using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D box;
    public Sprite openSprite;
    public Sprite closedSprite;
    
    void Start()
    {
        box = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        Debug.Log("Door Opened");
        box.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
    }

    public void Close()
    {
        Debug.Log("Door Closed");
        box.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = closedSprite;
    }
}
