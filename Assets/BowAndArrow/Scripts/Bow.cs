﻿using System.Collections;
using UnityEngine;
using OculusSampleFramework;

public class Bow : MonoBehaviour
{

  [Header("Arrows")]
  public GameObject m_ArrowPrefab = null;
  public GameObject m_FireArrowPrefab = null;

  [Header("Sounds")]
  public AudioSource source;
  public AudioClip arrowFlySound;

  [Header("Bow")]
  public float m_GrabThreshold = 0.3f;
  public Transform m_Start = null;
  public Transform m_End = null;
  public Transform m_Socket = null;


  [Header("Hands")]
  private GameObject leftHand;
  private GameObject rightHand;


  private Transform m_PullingHand = null;         // Close to the notch when trigger is pulled
  private Arrow m_CurrentArrow = null;            // 
  private Animator m_Animator = null;

  private float m_PullValue = 0.0f;
  private int m_countToNextFireArrow;
  private int maxInterval = 10;


  private void Awake()
  {
    source.clip = arrowFlySound;
    m_Animator = GetComponent<Animator>();
    leftHand = GameObject.FindGameObjectWithTag("LeftHand");
    rightHand = GameObject.FindGameObjectWithTag("RightHand");
  }

  private void Start()
  {
    StartCoroutine(CreateArrow(0.0f));
    m_countToNextFireArrow = Random.Range(1, maxInterval);
  }

  private void Update()
  {
    // Testing purposes
    if (Input.GetKeyDown(KeyCode.X))
    {
      //Debug.Log("X pressed");
      m_PullValue = 1.0f;
      Release();
    }

    // Hand not pulling or an arrow doesn't exist
    if (!m_PullingHand || !m_CurrentArrow)
    {
      return;
    }

    m_PullValue = CalculatePull(m_PullingHand);
    m_PullValue = Mathf.Clamp(m_PullValue, 0.0f, 1.0f);

    m_Animator.SetFloat("Blend", m_PullValue);
  }


  // Check to see how much we're pulling back
  private float CalculatePull(Transform pullHand)
  {
    Vector3 direction = m_End.position - m_Start.position;
    float magnitude = direction.magnitude;

    direction.Normalize();
    Vector3 difference = pullHand.position - m_Start.position;

    // Return value between 0-1
    return Vector3.Dot(difference, direction) / magnitude;
  }

  private IEnumerator CreateArrow(float waitTime)
  {
    // Wait
    yield return new WaitForSeconds(waitTime);

    // Create, child to socket
    GameObject arrowObject = createArrowHelper();

    // Orient - end of arrow sitting on string
    arrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
    arrowObject.transform.localEulerAngles = Vector3.zero;

    // Set
    m_CurrentArrow = arrowObject.GetComponent<Arrow>();
  }


  private GameObject createArrowHelper()
  {
    GameObject arrow;
    //m_countToNextFireArrow--;
    //if(m_countToNextFireArrow <= 0)
    //{
    arrow = Instantiate(m_FireArrowPrefab, m_Socket);
    //    m_countToNextFireArrow = Random.Range(1, maxInterval);
    //    Debug.Log("Counter: " + m_countToNextFireArrow);
    //} else
    //{
    //    arrow = Instantiate(m_ArrowPrefab, m_Socket);
    //}

    return arrow;
  }


  // 
  public void Pull(Transform hand)
  {
    float distance = Vector3.Distance(hand.position, m_Start.position);

    // Is the pulling hand close enough to the notch to pull the string?
    // If too far away, do nothing
    if (distance > m_GrabThreshold)
    {
      return;
    }

    m_PullingHand = hand;

  }

  public void Release()
  {
    // Pulled a quarter of the way

    if (m_PullValue > 0.3f)
    {
      FireArrow();
      source.Play();
      // AudioSource.PlayClipAtPoint(arrowFlySound, transform.position, 0.1f);
    }

    m_PullingHand = null;

    m_PullValue = 0.0f;
    m_Animator.SetFloat("Blend", 0);

    if (!m_CurrentArrow)
    {
      StartCoroutine(CreateArrow(0.25f));
    }
  }

  private void FireArrow()
  {
    //Debug.Log("Fire Arrow: ", m_CurrentArrow);
    // TODO keeps getting nullreference error here
    m_CurrentArrow.Fire(m_PullValue);
    m_CurrentArrow = null;
  }


}
