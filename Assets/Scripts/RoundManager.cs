using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class RoundManager : NetworkBehaviour
{
    //private CubeSpawner _cubeSpawner;
    public CubeSpawner cubeSpawner;
    
    // Start is called before the first frame update
    void Start()
    {
        //_cubeSpawner = GameObject.Find("CubeManager").GetComponent<CubeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewRound()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            cube.GetComponent<CubeDestroyer>().DestroyMe();
        }
        ResetPoints();
    }

    [ClientRpc]
    private void ResetPoints()
    {
        cubeSpawner.destroyedCubeCounter = 0;
    }

}
