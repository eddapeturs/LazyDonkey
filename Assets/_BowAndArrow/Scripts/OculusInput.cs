using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using OVR;

public class OculusInput : MonoBehaviour
{
  //public Bow m_Bow; // Reference to current bow (script)
  //public GameObject _bow; //

  //private GameObject player;
  private GameObject leftHand;
  private GameObject rightHand;
  private GameObject m_OppositeController;
  private OVRInput.Controller m_Controller;
  private Bow m_Bow;

  private OVRInput.Button trigger;


  private void Awake()
  {
   // player = GameObject.FindGameObjectWithTag("Player");
    m_Bow = this.gameObject.GetComponent<Bow>();   // Get bow script
    m_OppositeController = gameObject.GetComponent<grabBow>().OppositeHand;
  }

  private void Start(){
    if (m_OppositeController.CompareTag(("RightHand"))) {m_Controller = OVRInput.Controller.RTouch; trigger = OVRInput.Button.PrimaryIndexTrigger;} 
    if (m_OppositeController.CompareTag(("LeftHand"))) {m_Controller = OVRInput.Controller.LTouch; trigger = OVRInput.Button.SecondaryIndexTrigger;} 
  }

  private void Update()
  {
 
    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
      m_Bow.Pull(m_OppositeController.transform);

    if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
      m_Bow.Release();
  }
  

}
