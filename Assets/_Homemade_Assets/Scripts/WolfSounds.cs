using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using OVR;
using UnityEngine.Audio;
public class WolfSounds : MonoBehaviour
{

  public AudioMixerGroup MixerGroupRunning;
  public AudioMixerGroup MixerGroupHowl;
  public AudioClip[] running;
  public AudioClip[] howl;
  public AudioClip[] snare;

  public AudioClip[] growl;
  public NavMeshAgent agent;
  public AudioSource audioSource;

  public float AudioEmitFreq;


  private float _timer = 0;


  // Start is called before the first frame update

  void Awake()
  {
    audioSource.playOnAwake = false;
  }
  void Start()
  {
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.outputAudioMixerGroup = MixerGroupHowl;
    audioSource.PlayOneShot(howl[Random.Range(0, howl.Length)]);
  }

  // Update is called once per frame
  void Update()
  {
    if (agent.velocity != Vector3.zero)
    {
      if (!audioSource.isPlaying)
      {
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.outputAudioMixerGroup = MixerGroupRunning;
        audioSource.PlayOneShot(running[Random.Range(0, running.Length)]);
      }
    }
    else if (audioSource.isPlaying && audioSource.clip == (running[0] || running[1]))
    {
      audioSource.Stop();
    }

    AudioEmitFreq -= Time.deltaTime;
    if (AudioEmitFreq < 0)
    {
      playHowl();
      AudioEmitFreq = Random.Range(100, 500);
    }
  }

  void playHowl()
  {
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.outputAudioMixerGroup = MixerGroupHowl;
    audioSource.PlayOneShot(howl[Random.Range(0, howl.Length)]);
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
