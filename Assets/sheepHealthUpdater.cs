using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sheepHealthUpdater : MonoBehaviour
{
    private GameManager manager;
    public TextMeshPro textBox;

    private int sheepHealth;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        sheepHealth = manager.getSheepHealth();
        textBox.text = sheepHealth.ToString();
    }
}
