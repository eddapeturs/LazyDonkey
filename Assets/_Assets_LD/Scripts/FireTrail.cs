using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireTrail : MonoBehaviour
{
  public bool Left;
  public bool Right;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (!Left || !Right)
    {
      throw new NotImplementedException();
    }
  }


}
