using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//the main camera will follow the player when he is moving forward
public class CameraController : MonoBehaviour
{
    public Transform target; //target ==> player
    private Vector3 offset; //distance between camera and player
    void Start()
    {
        offset = transform.position - target.position;
    }
    // LateUpdate is always called after Update, 
    // meaning that Update will have been called on every script before the first LateUpdate is called.
    // LateUpdate is used as a method of staging code execution
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y ,offset.z+target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 10*Time.deltaTime); //(startpoint,endpoint,interpolant)
        //Lerp ==> Linearly interpolates between two points by the interpolant
        //interpolant ==> to move player gradually between those points
    }
}
