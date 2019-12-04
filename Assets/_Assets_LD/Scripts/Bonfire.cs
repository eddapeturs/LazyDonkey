using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bonfire : Target
{
  public float Damage;
  public float Multiplier;
  public float TickRate;
  private float _timer = 0f;

  protected override void Awake()
  {
    base.Awake();
  }

  // Start is called before the first frame update
  protected override void Start()
  {
    base.Start();
  }
  // Update is called once per frame
  void Update()
  {
    if (GameManager.instance.IsStarted)
    {
      if (!Dead)
      {
        _timer += Time.deltaTime;
        if (_timer >= TickRate)
        {
          TakeDamage(calcRespectedDmg());
          _timer -= TickRate;
        }
      }
    }
  }
  // Increases dmg done to bonfire, if one of the firetrails are out.
  float calcRespectedDmg()
  {
    return Damage;
    throw new NotImplementedException();
    /*
    FireTrail _left = FireTrails[0].GetComponent<FireTrail>();
    FireTrail _right = FireTrails[1].GetComponent<FireTrail>();


    if (!_left.Right) return Damage * Multiplier;
    else if (!_right.Left) return Damage * Multiplier;
    else return Damage;
    */
  }

  protected override void Die()
  {
    throw new NotImplementedException();
    /*
    // If random = 0, it sets the bool called 'Right' for the firetrail to the left of the bonfire,
    // If random = 1, it sets the bool called 'Left' for the firetrail to the right of the bonfire. 
    int random = UnityEngine.Random.Range(0, 1); // Might need another random seed.
    FireTrail _firetrail = FireTrails[random].GetComponent<FireTrail>();
    if (random == 0) _firetrail.Right = false;
    else _firetrail.Left = false;
    */
  }

  public void reKindle()
  {
    throw new NotImplementedException();
  }

}
