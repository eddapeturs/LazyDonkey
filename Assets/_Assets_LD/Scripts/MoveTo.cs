// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    //public Transform goal;
    //public GameObject goalObject;
    private NavMeshAgent agent;
    private bool flip = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        //if (GameManager.instance.IsStarted)
        //{
            if (flip) { agent.destination = new Vector3(0, 0, 0); flip = false; }
        //}
    }

}