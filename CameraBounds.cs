using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private Vector2 velocity;

   

    public GameObject player;
    

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public void BoundUpdate()
    {
        

        //float posX = Mathf.SmoothDamp(transform.position.x, transform.position.y, ref velocity.x, smoothTimeX);

        //transform.position = new Vector3(posX, transform.position.y, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
            //Debug.Log("Camera position ="  + transform.position);
        }
    }


}
