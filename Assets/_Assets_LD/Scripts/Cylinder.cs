using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
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
		Debug.Log("Something colliding! " + col.gameObject.name);
        if(col.gameObject.tag == "FireArrow")
        {
			Debug.Log("Hello from collider");
		}
		
	}
}
