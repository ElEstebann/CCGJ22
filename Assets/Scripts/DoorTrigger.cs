using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Door door;
    void Start()
    {
        door = GameObject.Find("Door").GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        if(door)
        {
            door.Activated(true);
        }
    }

    public void Unactivate()
    {
        if(door)
        {
            door.Activated(false);
        }
    }
}
