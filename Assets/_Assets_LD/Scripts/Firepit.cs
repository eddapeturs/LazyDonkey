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
    private float lightRange;


    // Called before start
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FullFire = transform.Find("Fire").gameObject;
        HalfFire = transform.Find("SmallerFire").gameObject;
        Smoke = transform.Find("Smoke").gameObject;

        // Finding and tracking lightsource
        light = transform.Find("Point Light").gameObject.GetComponent<Light>();
        lightRange = light.range;

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
            FireOn = false;
            //light.intensity = 0; // Initial lighsource intensity of 10
            light.enabled = false;
        }
        else if (timer < initialTimer / 2)
        {
            FullFire.SetActive(false);
            HalfFire.SetActive(true);
            LowFire = true;
            light.range = 4;
            //light.intensity = 4;
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
        light.enabled = true;
        nmo.enabled = true;
        FireOn = true;
        light.range = lightRange;
        setActiveFire();
        GetRandomTimer();
    }

    private void setActiveFire()
    {
        Debug.Log("Setting fire for : " + gameObject.name);
        Smoke.SetActive(false);
        HalfFire.SetActive(false);
        FullFire.SetActive(true);
        LowFire = false;
        //Light.enabled = true;
    }

}
