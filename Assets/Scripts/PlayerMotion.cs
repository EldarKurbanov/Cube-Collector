using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMotion : NetworkBehaviour
{
    public float speed = 0.1f;
    public Transform sphere;
    public Transform camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        if (!isLocalPlayer)
            return;
    
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //        _transform.localPosition += _transform.right * h;
        //        _transform.localPosition += _transform.forward * v;

        Vector3 RIGHT = camera.TransformDirection(Vector3.right);
        Vector3 FORWARD = camera.TransformDirection(Vector3.forward);
        FORWARD.y = transform.rotation.eulerAngles.y;

        //var networkTransform = GetComponent<NetworkTransform>();
        transform.localPosition += RIGHT * h;
        transform.localPosition += FORWARD * v;
    }

    // Update is called once per frame
    /*void Update()
    {
        var verticalAxis = Input.GetAxis("Vertical") * speed;
        var horizontalAxis = Input.GetAxis("Horizontal") * speed;
        var transform1 = transform;
        var positionF = transform1.forward;
        transform1.forward = new Vector3(positionF.x + horizontalAxis, positionF.y, positionF.z + verticalAxis);
    }*/
    
    
}
