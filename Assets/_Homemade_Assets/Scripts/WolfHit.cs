using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WolfHit : MonoBehaviour
{

  public AudioSource source;
  public AudioClip[] die;

  public AudioMixerGroup mixerGroup;

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
      source.rolloffMode = AudioRolloffMode.Linear;
      source.outputAudioMixerGroup = mixerGroup;
      source.PlayOneShot(die[Random.Range(0, die.Length)]);
      Destroy(col.gameObject, 0.5f);
      Destroy(transform.parent.gameObject, 0.5f);
    }

  }

}
