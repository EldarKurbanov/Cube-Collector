using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class ScriptEnabler : NetworkBehaviour
{
    // Start is called before the first frame update
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        var playerController = GetComponentInChildren<PlayerController>();
        playerController.enabled = true;
        var cameraMovement = GetComponentInChildren<CameraMovement>();
        cameraMovement.enabled = true;
        var audioListener = GetComponentInChildren<AudioListener>();
        audioListener.enabled = true;
        var camera1 = GetComponentInChildren<Camera>();
        camera1.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
