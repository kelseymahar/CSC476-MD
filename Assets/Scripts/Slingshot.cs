﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    // fields set in the Unity Inspector pane
    [Header("Set in Inspector")]

    public GameObject prefabProjectile;

    // fields set dynamically
    [Header("Set Dynamically")]

    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    void Awake() {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter() {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit() {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown() 
    {
        // the player has pressed the mouse button while over Slingshot
        aimingMode = true;
        // Instantiate a Projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // Start it at the launchPoint
        projectile.transform.position = launchPos;
        // Set it to the isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }
}
