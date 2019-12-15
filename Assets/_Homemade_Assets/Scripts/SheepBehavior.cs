using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehavior : MonoBehaviour
{
    public int angle;

    public Vector3 origin;

    public float timer;

    public float distance;
    public int state;

    public bool tooFar;

    public Animator anim;
    //private Vector3 location;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        GetRandomTimer();
        origin = transform.position;
        origin.y = 7.6f;
        GetRandomDistance();
        state = 0;
        tooFar = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        distance -= Time.deltaTime;
        if (state == 0 && timer < 0)
        {
            state = 1;
        }
        
        if (state == 1 && !tooFar)
        {
            
            angle = Random.Range(1, 360);
            transform.Rotate(0,angle, 0, Space.World);
            GetRandomDistance();
            GetRandomTimer();
            state++;
        }
        else if (state == 1 && tooFar)
        {
            
            GetRandomDistance();
            GetRandomTimer();
            transform.LookAt(origin, Vector3.up);
            tooFar = false;
            state++;
        }
        else if (state == 2 && distance > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
            anim.Play("sheep_walking2");
            GetFiveSecTimer();
        }
        else if(state == 2 && distance < 0)
        {
            anim.Play("sheep_animation");
            //Debug.Log("bita gras");
            if (timer < 0)
            {
                //Debug.Log("time is over");
                state = 1;
            }
        }
        
        
        if (Vector3.Distance(transform.position, origin) > 2)
        {
            tooFar = true;
        }

    }

    void GetRandomTimer()
    {
        timer = Random.Range(5f, 10f);
    }

    void GetRandomDistance()
    {
        distance = Random.Range(0.5f, 2f);
    }

    void GetFiveSecTimer()
    {
        timer = 4.8f;
    }

    public void SwitchState()
    {
        state = 1;
    }
}
