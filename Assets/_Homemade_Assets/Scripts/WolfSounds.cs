using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using OVR;

public class WolfSounds : MonoBehaviour
{
  private SoundEmitter emitter;
  public AudioClip running;
  public AudioClip[] howl;
  public AudioClip[] snare;

  public AudioClip[] growl;
  public NavMeshAgent agent;
  public AudioSource audioSource;

  public float AudioEmitFreq;


  private float _timer = 0f;


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

    _timer += Time.deltaTime;
    if (_timer >= AudioEmitFreq)
    {
      //AudioClip sound = findSound();
      AudioClip sound = howl[Random.Range(0, howl.Length)];
      if (sound) audioSource.PlayOneShot(sound);
      _timer = 0;
    }
  }

  AudioClip findSound()
  {
    int soundtype = Random.Range(0, 2);

    switch (soundtype)
    {
      case 0:
        return howl[Random.Range(0, howl.Length)];
      case 1:
        return snare[Random.Range(0, snare.Length)];
      case 2:
        return growl[Random.Range(0, growl.Length)];
    }
    return null;
  }

}
