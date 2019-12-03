using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Assets")]
    public GameObject m_ArrowPrefab = null;


    [Header("Bow")]
    public float m_GrabThreshold = 0.15f;
    public Transform m_Start = null;
    public Transform m_End = null;
    public Transform m_Socket = null;


    private Transform m_PullingHand = null;         // Close to the notch when trigger is pulled
    private Arrow m_CurrentArrow = null;            // 
    private Animator m_Animator = null;

    private float m_PullValue = 0.0f;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(CreateArrow(0.0f));
    }

    private void Update()
    {
        // Testing purposes
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X pressed");
            m_PullValue = 0.75f;
            Release();
        }

        // Hand not pulling or an arrow doesn't exist
        if(!m_PullingHand || !m_CurrentArrow)   
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
        GameObject arrowObject = Instantiate(m_ArrowPrefab, m_Socket);

        // Orient - end of arrow sitting on string
        arrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrowObject.transform.localEulerAngles = Vector3.zero;

        // Set
        m_CurrentArrow = arrowObject.GetComponent<Arrow>();
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
        if (m_PullValue > 0.25f)
        {
            FireArrow();
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
        m_CurrentArrow.Fire(m_PullValue);
        m_CurrentArrow = null;
    }


}
