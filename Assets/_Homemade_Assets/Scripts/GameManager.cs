using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public string goofy = "Alex";
  //public bool IsStarted = true; // Is set when all bonfires get lid. // Think about having event trigger.

  private string levelName;

  public GameObject LoadingScreen;
  public GameObject loadingScreenTextObject;

  private float timeToDark = 3f;
  public float fadeWaitTime = 5f;
  private bool switchingLevel = false;
  public int wolfKill = 0;    // Used for wolf sign text

  void Awake()
  {
    if(instance != null && instance != this){
      Destroy(this.gameObject);
      return;
    } else {
      instance = this;
    }

    DontDestroyOnLoad(this.gameObject);
  }

  // Start is called before the first frame update
  void Start()
  {
    instance = this;
    // loadingScreenTextObject.GetComponent<TextMeshPro>().text = "Edda";
    // lightToFade = GameObject.Find("Directional Light").GetComponent<Light>();

  }

  // Update is called once per frame
  void Update()
  {
    if(switchingLevel){
      fadeWaitTime -= Time.deltaTime;
      loadingScreenTextObject.GetComponent<TextMeshPro>().text =  Mathf.Ceil(fadeWaitTime).ToString();
      if(fadeWaitTime < 0){
        SceneManager.LoadScene("NewMainScene", LoadSceneMode.Single);
        switchingLevel = false;
        fadeWaitTime = 5f;
      }
    }
  }


  void levelSelection(string level){
    Debug.Log("Hello from gameManager: " + level);
    //animator.SetTrigger("FadeOut");
    levelName = level;
    goofy = level;
    // StartCoroutine(fadeInAndOutRepeat(lightToFade, eachFadeTime, fadeWaitTime));
    FadeToLevel(1);
    switchingLevel = true;

  }

  public void FadeToLevel(int levelIndex){
    Debug.Log("Fade to level");
    LoadingScreen.SetActive(true);
  }

  public string getLevelName(){
    return levelName;
  }

  public void updateWolfKill(){
    wolfKill++;
    Debug.Log("WolfKill: " + wolfKill);
  }

  public int getWolfKills(){
    return wolfKill;
  }

}
