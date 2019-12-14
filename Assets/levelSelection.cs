using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelection : MonoBehaviour
{
    public string levelName;
    public GameObject manager;

    // public GameObject fadeAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "FireArrow"){
            manager.SendMessage("levelSelection", levelName);
            // fadeAnimation.SendMessage("FadeOut");
        }
    
    }
}
