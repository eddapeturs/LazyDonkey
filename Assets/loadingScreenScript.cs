using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loadingScreenScript : MonoBehaviour
{
    private GameManager manager;
    public GameObject loadingScreenTextObject;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        loadingScreenTextObject.SetActive(manager.loadingScreenActive);
        loadingScreenTextObject.GetComponent<TextMeshPro>().text = manager.loadingScreenText;
    }



}
