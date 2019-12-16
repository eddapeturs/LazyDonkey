using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


/*
  Gamemanager is not refreshed between scenes
*/
public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  // public string goofy = "Alex";
  //public bool IsStarted = true; // Is set when all bonfires get lid. // Think about having event trigger.

  public string levelName;

  // public GameObject LoadingScreen;
  public bool loadingScreenActive;
  //public GameObject loadingScreenTextObject;

  private float timeToDark = 3f;
  public float fadeWaitTime = 5f;
  private bool switchingLevel = false;

  public string loadingScreenText;

  // Sign variables 
  private int sheepHealth = 100;
  private int wolfKill = 0;    // Used for wolf sign text

  private float gameplayTimer = 300f; // Playtime for survival, 5 mins
 // private float gameplayTimer = 10f; // Playtime for survival, 5 mins

  private bool gameEnd = false;


  void Awake()
  {
    if (instance != null && instance != this)
    {
      Destroy(this.gameObject);
      return;
    }
    else
    {
      instance = this;
    }

    DontDestroyOnLoad(this.gameObject);
  }

  // Start is called before the first frame update
  void Start()
  {
    instance = this;
  }

  // Update is called once per frame
  void Update()
  {
    // Switching from main menu to first level
    if (switchingLevel)
    {
      fadeWaitTime -= Time.deltaTime;
      // loadingScreenTextObject.GetComponent<TextMeshPro>().text = Mathf.Ceil(fadeWaitTime).ToString();
      loadingScreenText = Mathf.Ceil(fadeWaitTime).ToString();
      if (fadeWaitTime < 0)
      {
        loadScene("NewMainScene");
      }
    } else if (gameEnd){
      fadeWaitTime -= Time.deltaTime;
      if(fadeWaitTime < 0){
        gameEnd = false;   
        loadScene("MainMenu");
      }
    }
  }

  void loadScene(string scene){
    switchingLevel = false;
    loadingScreenActive = false;
    loadingScreenText = "";
    fadeWaitTime = 5f;
    SceneManager.LoadScene(scene, LoadSceneMode.Single);
    Reset();
  }

  void levelSelection(string level)
  {
    levelName = level;
    switchingLevel = true;
    loadingScreenActive = true;
  }
  public string getLevelName()
  {
    return levelName;
  }

  public void updateSheepHealth(int amount)
  {
    sheepHealth -= amount;
    if (sheepHealth < 0)
    {
      sheepHealth = 0;
      stopGame("lose");
    }
  }

  public int getSheepHealth()
  {
    return sheepHealth;
  }

  public void updateWolfKill()
  {
    wolfKill++;
  }

  public int getWolfKills()
  {
    return wolfKill;
  }

  public float getGameplayTimer()
  {
    return gameplayTimer;
  }

  public void stopGame(string winOrLose)
  {
    // Stop the game!
    loadingScreenActive = true;
    loadingScreenText = "You " + winOrLose + "!";
    gameEnd = true;
  }

  void Reset(){
      sheepHealth = 100;
      wolfKill = 0;    // Used for wolf sign text 
      gameplayTimer = 300f; // Playtime for survival, 5 mins
  }

}
