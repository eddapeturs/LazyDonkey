using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfSpawn : MonoBehaviour
{
    [Header("Assets")]
    public GameObject m_WolfPrefab = null;

    Vector3 center;
    private float timer;

    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        GetRandomTimer();
        center = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            CreateWolf();
            GetRandomTimer();

        }
    }

    private void CreateWolf()
    {
        int a = Random.Range(1, 360);
        GameObject wolf;
        Vector3 pos = RandomCircle(50.0f , a);
        //wolf = Instantiate(m_WolfPrefab, gameObject.transform, false);
        wolf = Instantiate(m_WolfPrefab, pos, Quaternion.identity);
        //Vector3 pos = wolf.transform.position;
        //wolf.transform.position = new Vector3(pos.x + xAdd, pos.y + 1, pos.z + xAdd);
        wolf.transform.Rotate(new Vector3(-90,180, a));
        wolf.transform.parent = transform;
    }

    Vector3 RandomCircle(float radius, int a)
    {
        Debug.Log("Wolf no: " + counter++);
        Debug.Log("A: " + a);
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + 1;
        pos.z = center.z + radius* Mathf.Cos(ang * Mathf.Deg2Rad);
        //Debug.Log("Position: " + pos);
        return pos;
    }

    void GetRandomTimer()
    {
        timer = Random.Range(1f, 10f);
    }
}
