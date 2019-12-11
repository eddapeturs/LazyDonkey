using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using OVR;

public class OculusInput : MonoBehaviour
{
  private Bow m_Bow;
  private GameObject _bow;

  private GameObject player;
  private GameObject leftHand;
  private GameObject rightHand;
  private GameObject m_OppositeController;
  private OVRInput.Controller m_Controller;


  private void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    m_Bow = gameObject.GetComponent(typeof(Bow)) as Bow;
    _bow = GameObject.FindGameObjectWithTag("Bow");
    leftHand = GameObject.FindGameObjectWithTag("LeftHand");
    rightHand = GameObject.FindGameObjectWithTag("RightHand");
  }

  private void Update()
  {
    if (_pickController())
    {
      if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
        m_Bow.Pull(m_OppositeController.transform);

      if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
        m_Bow.Release();
    }
  }



  private bool _pickController()
  {
    if (_bow.transform.IsChildOf(leftHand.transform))
    {
      m_Controller = OVRInput.Controller.RTouch;
      m_OppositeController = rightHand;
      return true;
    }
    else if (_bow.transform.IsChildOf(leftHand.transform))
    {
      m_Controller = OVRInput.Controller.LTouch;
      m_OppositeController = leftHand;
      return true;
    }
    else return false;
  }

}
