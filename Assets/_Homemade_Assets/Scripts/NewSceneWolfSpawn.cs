using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSceneWolfSpawn : MonoBehaviour
{
    [Header("Assets")]
    public GameObject m_WolfPrefab = null;

    Vector3 center;
    public float loRanTime = 5f;
    public float hiRanTime = 50f;

    private Vector3[] spawnPoints = new Vector3[4]
    {
        new Vector3(-2, 2, 58),
        new Vector3(-27, 2, 48),
        new Vector3(42, 2, 36),
        new Vector3(-59, 2, 6)
    };
    private float _timer;

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
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            CreateWolf();
            GetRandomTimer();
        }
    }

    private void CreateWolf()
    {
        int a = Random.Range(0, 4);
        GameObject wolf;
        Vector3 pos = spawnPoints[a];
        //wolf = Instantiate(m_WolfPrefab, gameObject.transform, false);
        wolf = Instantiate(m_WolfPrefab, pos, Quaternion.identity);
        //wolf.transform.position = new Vector3(pos.x + xAdd, pos.y + 1, pos.z + xAdd);
        wolf.transform.Rotate(new Vector3(-90, 0, 0));
        wolf.transform.parent = transform;
    }
    
    void GetRandomTimer()
    {
        _timer = Random.Range(loRanTime, hiRanTime);
    }
}