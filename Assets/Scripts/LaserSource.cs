using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{

    private LineRenderer line;
    public int maxReflections = 10;
    
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

    void Update()
    {
        line.SetPosition(0,transform.position);
        Vector3 direction = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        
        line.positionCount = 1;
        Debug.DrawRay(transform.position, direction, Color.green);
        
            
        
        Ray ray = new Ray(transform.position, transform.forward);
        for(int i = 1; i < maxReflections +1; i++)
        {
            line.positionCount = i+1;
            if(hit.collider)
            {
                line.SetPosition(i,hit.point);
                if(hit.collider.tag != "Mirror")
                {
                    break;
                }
                
                ray = new Ray(hit.point,Vector3.Reflect(ray.direction,hit.normal));
                Debug.DrawRay(hit.point, Vector3.Reflect(ray.direction,hit.normal), Color.green);
                hit = Physics2D.Raycast(hit.point,Vector3.Reflect(ray.direction,hit.normal));
            }
            else
            {
                
                
                line.SetPosition(i,ray.origin + ray.direction);
                break;
            }
            
        }
           
            
    }
        
    

  
}
