using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        line.SetPosition(0,transform.position);
        //line.SetPosition(1,destination);
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        if(hit.collider)
        {
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "Wall")
            {
                Vector3 collisionLocation = new Vector3(hit.collider.transform.position.x,transform.position.y,0);
                line.SetPosition(1,collisionLocation);
            }
            
        }
        else{
            Vector3 destination = new Vector3(999999,transform.position.y,0);
            line.SetPosition(1,destination);
        }
    }
}
