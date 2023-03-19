using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class PlayerMove1 : MonoBehaviour
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

    private Vector3 sideCamera;
    private Vector3 backCamera;
    private Vector3 frontCamera;
    private Vector3 side2Camera;





    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
        backCamera = ct.m_FollowOffset;


        sideCamera.x = -6.77051f;
        sideCamera.y = 6.47f;
        sideCamera.z = 0.639105f;

        frontCamera.x = -0.1875448f;
        frontCamera.y = 6.355f;
        frontCamera.z = 6.985443f;

        side2Camera.x = 6.807478f;
        side2Camera.y = 5.95f;
        side2Camera.z = 2.418345f;

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

        if (Input.GetKey(KeyCode.Alpha1))
        {
            currPos = backCamera;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            currPos = sideCamera;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            currPos = frontCamera;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            currPos = side2Camera;
        }


        ct.m_FollowOffset = currPos;
    }
}
