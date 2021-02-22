using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    
    public GameObject cubeManager;
    private CubeSpawner _cubeSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        _cubeSpawner = cubeManager.GetComponent<CubeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Destroy(gameObject);
        _cubeSpawner.incrementCubeCounter();
    }
}
