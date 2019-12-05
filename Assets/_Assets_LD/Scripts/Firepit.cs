using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepit : MonoBehaviour
{
    public static Firepit instance;

    public AudioClip fireLitSound;

    private GameObject FullFire;
	private GameObject HalfFire;
	private GameObject Smoke;


    public float timer;
    public float initialTimer;

    // Called before start
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FullFire = gameObject.transform.Find("Fire").gameObject;
        HalfFire = gameObject.transform.Find("SmallerFire").gameObject;
        Smoke = gameObject.transform.Find("Smoke").gameObject;

        // Set random timer
        GetRandomTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            HalfFire.SetActive(false);
            Smoke.SetActive(true);

        }
        else if (timer < initialTimer / 2)
        {
            FullFire.SetActive(false);
            HalfFire.SetActive(true);
        }
        
    }

    void GetRandomTimer()
    {
        timer = Random.Range(10f, 20f);
        initialTimer = timer;
    }


    public void igniteFlame()
	{
        AudioSource.PlayClipAtPoint(fireLitSound, transform.position);
        Debug.Log("Inside ignite flame");
        Smoke.SetActive(false);
        HalfFire.SetActive(false);
        FullFire.SetActive(true);

        GetRandomTimer();
    }

}
