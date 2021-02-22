using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Transform plane;
    public GameObject exampleCube, children;
    private float xMin, xMax, zMin, zMax;
    public int cubeLimit = 10;
    private int cubeCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnNewCube", 1f, 1f);
        xMax = plane.transform.position.x + plane.transform.localScale.x / 2;
        xMin = -xMax;
        zMax = plane.transform.position.z + plane.transform.localScale.z / 2;
        zMin = -zMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnNewCube()
    {
        if (cubeCounter < cubeLimit)
        {
            var newCube = Instantiate(exampleCube);
            newCube.transform.position = new Vector3(Random.Range(xMin, xMax), exampleCube.transform.position.y, Random.Range(zMin, zMax));
            newCube.transform.parent = children.transform;
            cubeCounter++;
        }
    }
    
}
