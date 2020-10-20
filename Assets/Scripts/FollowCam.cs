using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ;

    void Awake() {
        camZ = this.transform.position.z;
    }

    void FixedUpdate () {
    //    if (POI == null) return;

        // get pos of the poi
    //    Vector3 destination = POI.transform.position;

        Vector3 destination;

        if (POI == null) {
            // if there is no poi, return to P:[0, 0, 0]
            destination = Vector3.zero;
        } else {
            // get the position of the poi
            destination = POI.transform.position;

            // If poi is a projectile, check to see if it's at rest
            if (POI.tag == "Projectile" ) {
                // if it is sleeping (not moving)
                if (POI.GetComponent<Rigidbody>().IsSleeping() ) {
                    // return to default value
                    POI = null;
                    // in the next update
                    return;
                }
            }
        }

        // Limit the X & Y to minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        // Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing);
        // Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        // Set the camera to be the destination
        transform.position = destination;
        // Set the orthographicSize of the Camera to keep Ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }
}
