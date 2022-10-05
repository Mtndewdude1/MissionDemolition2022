using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // Point of Interest

    [Header("Inscribed")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Dynamic")]
    public float camZ; // The desired Z pos of the camera

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        // Get the position of the POI
        Vector3 destination = Vector3.zero;

        if (POI != null)
        {
            // If it has a rigid body, is it sleeping (ie. not moving)
            Rigidbody poiRigid = POI.GetComponent<Rigidbody>();
            if ( (poiRigid != null) && (poiRigid.IsSleeping()))
            {
                POI = null;
            }

            if (POI != null)
            {
                destination = POI.transform.position;
            }
        }
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
        // Set the orthographic size of the camera to keep the ground in view of it
        Camera.main.orthographicSize = destination.y + 10;
    }
}
