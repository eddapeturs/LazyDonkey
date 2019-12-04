using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public bool IsStarted;

  // Start is called before the first frame update
  void Start()
  {
    // Is set when all bonfires get lid.
    IsStarted = false;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
