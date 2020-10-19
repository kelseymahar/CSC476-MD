using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set Dynamically")]
    public float camZ;

    void Awake() {
        camZ = this.transform.position.z;
    }

    void FixedUpdate () {
        if (POI == null) return;

        // get pos of the poi
        Vector3 destination = POI.transform.position;
        // Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        // Set the camera to be the destination
        transform.position = destination;
    }
}
