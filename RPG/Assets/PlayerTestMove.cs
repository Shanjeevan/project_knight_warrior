using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerTestMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public NavMeshAgent navMeshAgent;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse clicked");
            Ray ray= cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
