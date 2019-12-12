using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Required componentes:
[RequireComponent(typeof(UnityEngine.UI.Slider))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public abstract class Target : MonoBehaviour
{

  public UnityEngine.UI.Slider Healthbar;
  public float Health;
  private float _currentHealth;
  public AudioSource Audio;
  public Animation Anim;
  // Needs these + texture render;
  public MeshRenderer MeshRender;
  public MeshFilter Model;
  public bool Dead = false;

  // Start is called before the first frame update
  protected virtual void Awake()
  {
    Healthbar = gameObject.GetComponent(typeof(UnityEngine.UI.Slider)) as UnityEngine.UI.Slider;
    Audio = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
    Anim = gameObject.GetComponent(typeof(Animation)) as Animation;
    Model = gameObject.GetComponent(typeof(MeshFilter)) as MeshFilter;
    MeshRender = gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
  }


  protected virtual void Start()
  {
    _currentHealth = Health;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public float TakeDamage(float dmg)
  {
    _currentHealth -= dmg;
    Healthbar.value = _currentHealth;
    if (_currentHealth <= 0)
    {
      Dead = true;
      Die(); // Maybe not needed
      return dmg - Math.Abs(_currentHealth);
    }
    return dmg;
  }

  protected abstract void Die();


}
