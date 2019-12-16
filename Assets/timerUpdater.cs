using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerUpdater : MonoBehaviour
{

    private GameManager manager;
    public TextMeshPro textBox;
    private float gameplayTimer;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameplayTimer = manager.getGameplayTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameplayTimer >= 0){
            gameplayTimer -= Time.deltaTime;

            string minutes = Mathf.Floor(gameplayTimer / 60).ToString("00");
            string seconds = (gameplayTimer % 60).ToString("00");

            textBox.text = string.Format("{0}:{1}", minutes, seconds);
        } else {
            gameplayTimer = 0;
            manager.stopGame("Win");
        }
    }
}
