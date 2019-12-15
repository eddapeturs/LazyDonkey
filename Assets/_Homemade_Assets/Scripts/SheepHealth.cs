using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHealth : MonoBehaviour
{
    private GameManager manager;
    private int wolfMultiplier = 0;

    private bool coroutineStarted = false;

  // Start is called before the first frame update
  void Start()
  {
      manager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }

  void Update()
  { 
    wolfMultiplier = gameObject.transform.childCount;
  }

  void OnTriggerEnter(Collider col){
    if(col.gameObject.tag == "Wolf"){

      col.gameObject.transform.parent = gameObject.transform;
      StartCoroutine(startDamage());
      //wolfMultiplier = gameObject.transform.childCount;
      Debug.Log("Wolf multiplier : " + wolfMultiplier);
    }
  }

  IEnumerator startDamage(){
    Debug.Log("Start damage : " + wolfMultiplier);
    if(!coroutineStarted){
        while(wolfMultiplier > 0){
          yield return new WaitForSeconds(1f);
          updateHealth();
          coroutineStarted = true;
      }
    }

   
  }

  void updateHealth(){
    manager.updateSheepHealth(wolfMultiplier);
  }


}
