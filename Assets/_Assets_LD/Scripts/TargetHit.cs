using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetHit : MonoBehaviour
{
    public AudioClip ArrowStoppingInObject;
    public AudioClip SuccessfullHit;
    public GameObject counter;

    [Header("Effect")]
    public GameObject effect;
    //public Text counterText;
    TextMeshPro counterText;

    int hitCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Counter");
        counterText = counter.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "FireArrow")
        {
            Transform arrow = col.gameObject.transform;
            Debug.Log("Hit!");
            AudioSource.PlayClipAtPoint(ArrowStoppingInObject, transform.position);
            AudioSource.PlayClipAtPoint(SuccessfullHit, transform.position);
            counterText.SetText("{0}", ++hitCounter);

            //if (effect)
            //{
            Debug.Log("Effect");
            Instantiate(effect, arrow.position, arrow.rotation);
            //}
            
            //StartCoroutine(bubbleBurst());
        }

    }

    IEnumerator bubbleBurst()
    {
        Debug.Log("Bubble burst");
        yield return new WaitForSeconds(2);
        //bubbleEffect.SetActive(false);
    }
}
