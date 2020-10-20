using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;

    [Header("Set Dynamically")]
    public float camZ;

    void Awake() {
        camZ = this.transform.position.z;
    }

    void FixedUpdate () {
        if (POI == null) return;

        // get pos of the poi
        Vector3 destination = POI.transform.position;
        // Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        // Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        // Set the camera to be the destination
        transform.position = destination;
    }
}
