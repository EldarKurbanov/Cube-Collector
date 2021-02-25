using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CubeDestroyer : NetworkBehaviour
{
    
    private CubeSpawner _cubeSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        _cubeSpawner = GameObject.Find("CubeManager").GetComponent<CubeSpawner>();
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

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
