using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private CameraBounds Bounds;

    private void Start()
    {
        Bounds = GetComponent<CameraBounds>();
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        if(Bounds!= null)
        {
            Bounds.BoundUpdate();
        }


    }

}
