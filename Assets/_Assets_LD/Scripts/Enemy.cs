using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Required components
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Enemy : Target
{
  //public float Moverate;

  public float DPS;
  public float Damage;
  public Rigidbody Body;
  public MeshCollider Collider;
  private bool _isAttackingSheep = false;
  private float _timer = 0f;
  private GameObject _collisionWith;

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
    // Attacks sheep
    if (_isAttackingSheep)
    {
      _timer += Time.deltaTime;
      if (_timer >= DPS)
      {
        InflictDamage(Damage, _collisionWith);
        _timer -= DPS;
      }

    }

  }

  void OnTriggerEnter(Collider other)
  {
    Debug.Log("Heysan from collision");
    if (other.gameObject.name == "Sheeps")
    {
      _collisionWith = other.gameObject;
      _isAttackingSheep = true;
    }
  }

  void OnTriggerExit(Collider collision)
  {
    Debug.Log("Tihi");
  }


  void Move()
  {
    throw new NotImplementedException();
  }

  float InflictDamage(float dmg, GameObject other)
  {
    Debug.Log(String.Format("Did  {0} dmg", dmg));
    return other.GetComponent<Sheep>().TakeDamage(dmg);
  }


  protected override void Die()
  {
    Debug.Log("Aww man, wolfie died");
    // Destroy(this);
  }
}
