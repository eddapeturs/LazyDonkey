using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Sheep : Target
{
  public BoxCollider Box;

  protected override void Awake()
  {
    base.Awake();
    Box = gameObject.GetComponent(typeof(BoxCollider)) as BoxCollider;
  }

  // Start is called before the first frame update
  protected override void Start()
  {
    base.Start();
  }

  void Update()
  {

  }

  protected override void Die()
  {
    Debug.Log("Aww man, the sheeps died");
  }

}
