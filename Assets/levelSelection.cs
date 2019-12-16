using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelection : MonoBehaviour
{
    public string levelName;
    private GameManager manager;

    // public GameObject fadeAnimation;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
