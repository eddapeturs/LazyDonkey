using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Firepit : MonoBehaviour
{
    public static Firepit instance;
    public bool LowFire = false;
    public bool FireOn;
    //public Light Light;

    private GameObject FullFire;
    private GameObject HalfFire;
    private GameObject Smoke;

    public AudioClip fireLitSound;
    public float timer;
    public float initialTimer;

    private NavMeshObstacle nmo;
    private Light light;

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

        // Finding and tracking lightsource
        light = gameObject.transform.Find("Point Light").gameObject.GetComponent<Light>();


        // Finding and adding Nav Mesh Object
        nmo = gameObject.GetComponent<NavMeshObstacle>();
        nmo.enabled = true;

        // Set random timer
        if (FireOn)
        {
            GetRandomTimer();
            FullFire.SetActive(true);
            Smoke.SetActive(false);
        }

        Smoke.SetActive(false);
        HalfFire.SetActive(false);
        FullFire.SetActive(true);
        //light.intensity = 10; // Initial lighsource intensity of 10
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            HalfFire.SetActive(false);
            Smoke.SetActive(true);
            nmo.enabled = false;

            //light.intensity = 0; // Initial lighsource intensity of 10
            light.enabled = false;
        }
        else if (timer < initialTimer / 2)
        {
            FullFire.SetActive(false);
            HalfFire.SetActive(true);
            LowFire = true;
            light.range = 5;
            //light.intensity = 5; // Initial lighsource intensity of 10
            //return;
        }
        //if (FireOn) setActiveFire();
    }

    void GetRandomTimer()
    {
        timer = Random.Range(10f, 100f);
        initialTimer = timer;
    }


    public void igniteFlame()
    {
        AudioSource.PlayClipAtPoint(fireLitSound, new Vector3(0, 0, 0));
        setActiveFire();
        GetRandomTimer();
    }

    private void setActiveFire()
    {   
        Smoke.SetActive(false);
        HalfFire.SetActive(false);
        FullFire.SetActive(true);
        LowFire = false;
        //Light.enabled = true;
    }

}
