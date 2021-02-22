using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
    public Transform plane;
    public GameObject exampleCube, children;
    private float xMin, xMax, zMin, zMax;
    public int cubeLimit = 10;
    private int destroyedCubeCounter = 0;
    public Text scoreShower;
    
    public void incrementCubeCounter()
    {
        destroyedCubeCounter++;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnNewCube", 1f, 1f);
        xMax = plane.transform.position.x + plane.transform.lossyScale.x * 2 + plane.transform.localScale.x * 2;
        xMin = -xMax;
        zMax = plane.transform.position.z + plane.transform.lossyScale.z * 2 + plane.transform.localScale.z * 2;
        zMin = -zMax;
    }

    // Update is called once per frame
    void Update()
    {
        scoreShower.text = destroyedCubeCounter.ToString();
    }

    void spawnNewCube()
    {
        var cubeCounter = children.transform.childCount;
        if (cubeCounter < cubeLimit)
        {
            var newCube = Instantiate(exampleCube);
            newCube.SetActive(true);
            newCube.transform.position = new Vector3(Random.Range(xMin, xMax), exampleCube.transform.position.y, Random.Range(zMin, zMax));
            newCube.transform.parent = children.transform;
            cubeCounter++;
        }
    }
    
}
