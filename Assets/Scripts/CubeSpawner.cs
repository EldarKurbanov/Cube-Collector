using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : NetworkBehaviour
{
    public Transform plane;
    public GameObject exampleCube;
    private float xMin, xMax, zMin, zMax;
    public int cubeLimit = 10;
    public int destroyedCubeCounter;
    private Text scoreShower;
    private GameObject children;

    public void incrementCubeCounter()
    {
        destroyedCubeCounter++;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreShower = GameObject.Find("ScoreShower").GetComponent<Text>();
        children = GameObject.Find("Children");
        if (isServer)
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
            //newCube.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
            newCube.SetActive(true);
            newCube.transform.position = new Vector3(Random.Range(xMin, xMax), transform.position.y + 0.5f, Random.Range(zMin, zMax));
            newCube.transform.parent = children.transform;
            NetworkServer.Spawn(newCube);
            //parentizeNewCube(newCube);
            cubeCounter++;
        }
    }

    /*[ClientRpc]
    public void parentizeNewCube(GameObject newCube)
    {
        Debug.Log("NewCube=" + newCube + " Chidren = " + children);
        newCube.transform.parent = children.transform;
    }
    */
}
