using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        Destroy(col.gameObject, 0.2f);
        Destroy(transform.parent.gameObject, 0.2f);
    }

}
