using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using OVR;

public class OculusInput : MonoBehaviour
{
  public Bow m_Bow = null;

  public GameObject player;
  private GameObject m_OppositeController;
  private OVRInput.Controller m_Controller;


  private void Awake()
  {
    if (player == null)
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }
  }

  private void Update()
  {
    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
      m_Bow.Pull(m_OppositeController.transform);

    if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
      m_Bow.Release();
  }


  private void _pickController()
  {
    if (player)
    {

    }
  }

}
