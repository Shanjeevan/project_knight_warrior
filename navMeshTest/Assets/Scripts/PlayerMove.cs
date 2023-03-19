using UnityEngine.AI;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    public Camera cam;
    private RaycastHit hit;
    public NavMeshAgent nav;
    private float x;
    private float z;
    private float velocitySpeed;
    // Update is called once per frame
    private void Start()
    {
        anim = GetComponent<Animator>();
        
        

    }
    void Update()
    {
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;
        if (Input.GetMouseButtonDown(0)) 
        {
           

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit))
            {
                nav.SetDestination(hit.point);
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

    }
}
