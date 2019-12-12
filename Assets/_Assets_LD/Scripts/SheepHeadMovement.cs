using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHeadMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float loRanTime = 5f;
    public float hiRanTime = 50f;
    public Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play();
    }
}
