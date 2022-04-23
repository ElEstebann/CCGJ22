using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{

    private LineRenderer line;
    public int maxReflections = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
       
        line.SetPosition(0,transform.position);
        //line.SetPosition(1,destination);
    }
    */

    void FixedUpdate()
    {
        //Set first line point at transform position
        line.SetPosition(0,transform.position);
        Vector3 direction = transform.right;
        line.positionCount = 1;
        Debug.DrawRay(transform.position, direction, Color.green);
        
        //Setup ray and raycast to detect collisions    
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        Ray2D ray = new Ray2D(transform.position, direction);

        //For every index in line.position:
            //Set next position at collision
            //If collision is not a mirror, break
            //If no collision: break loop
        for(int i = 1; i <= maxReflections +1; i++)
        {
            line.positionCount = i+1;
            if(hit.collider)
            {
                line.SetPosition(i,hit.point);
                if(hit.collider.tag != "Mirror")
                {
                    if(handleOtherCollision(hit))
                    {
                        continue;
                    }
                    else{
                        break;
                    }
                    
                }
                
                
                //Debug.Log(ray.direction);
                Vector3 hitpoint = hit.point;
                direction = ray.direction;
                
                
                ray = new Ray2D(hitpoint,Vector3.Reflect(direction,hit.normal));
                ray = new Ray2D(ray.origin + ray.direction*.1f,ray.direction);
                Debug.DrawRay(ray.origin,ray.direction);
                hit = Physics2D.Raycast(ray.origin,ray.direction);
            }
            else
            {
                
                
                line.SetPosition(i,ray.origin + ray.direction*999);
                break;
            }
            
        }
           
            
    }

    //Handle Non-mirror collisions
    bool handleOtherCollision(RaycastHit2D hit)
    {
        switch (hit.collider.tag)
        {
            case "Player":
                //Debug.Log("Hit Player");
                PlayerMovement player = hit.collider.transform.gameObject.GetComponent<PlayerMovement>();
                player.Kill();
                return true;
                break;
            case "Wall":
                break;
            default:
                break;
        }
        return false;
    }
        
    

  
}
