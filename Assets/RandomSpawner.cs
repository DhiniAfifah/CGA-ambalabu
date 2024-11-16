using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform obj;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        int indexNumber = Random.Range(0, spawnPoints.Length);
        obj.position = spawnPoints[indexNumber].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
