using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wolfKillUpdater : MonoBehaviour
{
    // private GameObject manager;
    private GameManager manager;
    public TextMeshPro textBox;

    // Start is called before the first frame update
    void Start()
    {
         manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //  manager.GetComponent<GameManager>();
        // manager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "" + manager.getWolfKills();
    }



}
