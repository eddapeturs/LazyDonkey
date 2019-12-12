// MoveTo.cs

using OVR.OpenVR;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    //public Transform goal;
    //public GameObject goalObject;
    private NavMeshAgent agent;
    private bool flip = true;
    private Vector3 location = new Vector3(1, 8, -22);
    //private GameObject target = new GameObject();

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        //target.transform.Translate(location);
    }

    void Update()
    {
        Vector3 direction = (location - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
        //if (GameManager.instance.IsStarted)
        //{
        if (flip)
        {
            agent.destination = location;
            flip = false;
        }

    }

}
/*
 private void RotateTowards (Transform target) {
    Vector3 direction = (target.position - transform.position).normalized;
    Quaternion lookRotation = Quaternion.LookRotation(direction);
    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
 */
//}