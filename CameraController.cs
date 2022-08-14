using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Start()
    {
       
    }
   
    // Update is called once per frame
    void Update()
    {
        var camX = player.position.x;
        var camY = player.position.y;
        var camZ = transform.position.z;
        transform.position = new Vector3(camX,camY,camZ); ;
    }
}
