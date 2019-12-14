using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using OVR;

public class WolfSounds : MonoBehaviour
{
  private SoundEmitter emitter;
  public AudioClip running;
  public AudioClip howl;
  public AudioClip snare;
  public NavMeshAgent agent;
  public AudioSource audioSource;



  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (agent.velocity != Vector3.zero)
    {
      if (!audioSource.isPlaying)
      {
        audioSource.clip = running;
        audioSource.Play();
      }
    }
    else if (audioSource.isPlaying && audioSource.clip == running)
    {
      audioSource.Stop();
    }
  }


}
