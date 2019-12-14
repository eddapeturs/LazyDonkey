using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHit : MonoBehaviour
{

  GameObject manager;
  // Start is called before the first frame update
  void Start()
  {
    manager = GameObject.Find("GameManager");
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "FireArrow")
    {

      manager.GetComponent<GameManager>().updateWolfKill();
      Destroy(col.gameObject, 0.2f);
      Destroy(transform.parent.gameObject, 0.2f);
    }

  }

}
