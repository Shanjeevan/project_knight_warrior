using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class testPlayerMove : MonoBehaviour
{

    private NavMeshAgent nav;
   
    private Ray ray;
    private RaycastHit hit;
   


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

       
    }

    // Update is called once per frame
    void Update()
    {
      
    
      
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
            if (Physics.Raycast(ray,out hit)) 
            {         
                /*nav.SetDestination(hit.point);*/
                nav.destination = hit.point;
            }
        }

    
    }
}
