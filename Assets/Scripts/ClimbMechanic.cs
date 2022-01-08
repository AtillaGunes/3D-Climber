using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClimbMechanic : MonoBehaviour
{
    public LayerMask clickable;
    private UnityEngine.AI.NavMeshAgent agent;
    

    void Start()
    {
        agent = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(myRay, out hitInfo, 100, clickable)) {
                agent.SetDestination(hitInfo.point);
            }

        }
          
    }

    void OnCollisionEnter(Collision collision)
    {
 
        if (collision.gameObject.tag == "Wall")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (collision.gameObject.tag == "final")
        {
            SceneManager.LoadScene("Climb");
        }
    }
}
