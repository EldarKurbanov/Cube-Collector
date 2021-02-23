using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMovement : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public Transform player;
    public Transform parent;
 
    public float height = 1f;
    public float distance = 2f;
     
    private Vector3 offsetX;
    private Vector3 offsetY;
     
    void Start () {
 
        offsetX = new Vector3 (0, height, distance);
        offsetY = new Vector3 (0, 0, distance);
    }
     
    void LateUpdate()
    {
        /*if (!isLocalPlayer)
            return;*/
        offsetX = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offsetY;
        transform.position = player.position + offsetX; 
        transform.LookAt(player.position);
        player.rotation = transform.rotation;
    }
}
