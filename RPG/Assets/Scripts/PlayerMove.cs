using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class PlayerMove : MonoBehaviour
{

    private NavMeshAgent nav;
    //we need to talk with animator
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;
    private float x;
    private float z;
    private float velocitySpeed;
    private CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    //mouseposition
    private Vector3 pos;
    //current position
    private Vector3 currPos;
   


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //calculating velocity
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        //mouse position
        pos = Input.mousePosition;
      
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
            if (Physics.Raycast(ray,out hit)) 
            {         
                /*nav.SetDestination(hit.point);*/
                nav.destination = hit.point;
            }
        }

        if (velocitySpeed != 0)
        {
            anim.SetBool("sprinting", true);
        }

        if (velocitySpeed == 0)
        {
            anim.SetBool("sprinting", false);
        }

        if (Input.GetMouseButton(1))
        {
            if (pos.x != 0 || pos.y != 0)
            {
                currPos = pos / 200;
            }
        }

        ct.m_FollowOffset = currPos;
    }
}
