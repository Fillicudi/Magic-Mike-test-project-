using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float z_offset = -10f;
    [SerializeField] float y_offset = 3f;
    [SerializeField] float smooth = 0.3f;
    Transform Player;
    Vector3 velocity = Vector3.zero; 
    private enum MovementState { idle, runnig, jumping, falling}
    private MovementState state = MovementState.idle; 
    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Player !=null)
        {
            Vector3 targetPosition = new Vector3(Player.position.x, Player.position.y + y_offset, Player.position.z + z_offset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth); 
        }
    }
}
