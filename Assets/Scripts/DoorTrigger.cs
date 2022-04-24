using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Door door;
    public bool activated = false;
    void Start()
    {
        door = GameObject.Find("Door").GetComponent<Door>();
        if(door)
        {
            door.requiredTriggers++;
            Debug.Log("Added 1 to reqtriggers");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        
        if(door && !activated)
        {
            door.Activated(true);
            activated = true;
        }
    }

    public void Unactivate()
    {
        if(door && activated)
        {
            door.Activated(false);
            activated = false;
        }
        
        
    }
}
