using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public bool IsStarted = true; // Is set when all bonfires get lid. // Think about having event trigger.

  // Start is called before the first frame update
  void Start()
  {
    instance = this;
  }

  // Update is called once per frame
  void Update()
  {
    if (!IsStarted)
    {
      Checkfirepits();
    }
  }

  void Checkfirepits()
  {
    var objects = GameObject.FindGameObjectsWithTag("Firepit");
    if (objects == null) return;
    foreach (var item in objects)
    {
      if (!item.GetComponent<Firepit>().FireOn) return;
    }
    IsStarted = true;
  }

}
