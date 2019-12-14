using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabBow : MonoBehaviour
{
  public GameObject m_bow; // Prefab

  private GameObject currBow;
  //private GameObject oldBow;

  private bool leftCollision;
  private bool rightCollision;

  public GameObject LeftHand;
  public GameObject RightHand;

  public GameObject OppositeHand = null;

  // Start is called before the first frame update
  void Start()
  {
    LeftHand = GameObject.FindGameObjectWithTag("LeftHand");
    RightHand = GameObject.FindGameObjectWithTag("RightHand");

    //Debug.Log("LeftHand: " + LeftHand.transform.name);
    //Debug.Log("RightHand: " + RightHand.gameObject.name);
  }

  // Update is called once per frame
  void Update()
  {
    if (leftCollision && OVRInput.GetDown(OVRInput.RawButton.Y))
    {
      spawnBow(LeftHand, RightHand);
    }
    else if (rightCollision && OVRInput.GetDown(OVRInput.RawButton.B))
    {
      spawnBow(RightHand, LeftHand);
    }
  }

  void OnTriggerEnter(Collider col)
  {
    if (col.gameObject.tag == "RightHand")
    {
      rightCollision = true;
      //oldBow = gameObject;
    }
    if (col.gameObject.tag == "LeftHand")
    {
      leftCollision = true;
      // oldBow = gameObject;
    }

  }

  void OnTriggerExit(Collider col)
  {
    if (col.gameObject.tag == "RightHand")
    {
      rightCollision = false;
    }
    else if (col.gameObject.tag == "LeftHand")
    {
      leftCollision = false;
    }
  }

  void spawnBow(GameObject hand, GameObject otherHand)
  {
    OppositeHand = otherHand;
    currBow = Instantiate(m_bow, hand.transform.position, hand.transform.rotation);
    currBow.transform.parent = hand.transform;
    hand.gameObject.transform.GetComponent<SphereCollider>().enabled = false;
    otherHand.gameObject.transform.GetComponent<SphereCollider>().enabled = true;

    // Delete old bow
    Destroy(gameObject);
  }
}
