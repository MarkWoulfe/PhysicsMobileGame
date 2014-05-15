﻿using UnityEngine;
using System.Collections;

public class Cannon_Pitch : MonoBehaviour
{

    public int rotateSpeed = 10;
    public GameObject cannonBall;

    float scaleValue = 0.01f;

    bool fired = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = transform.localEulerAngles;
        bool pitchedTurret = false;

        if (Input.GetKey("up") && (angle.z < 45.1f || angle.z > 359.9f))
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
            pitchedTurret = true;
        }
        if (Input.GetKey("down") && (angle.z < 45.1f || angle.z > 359.9f))
        {
            transform.Rotate(Vector3.forward, -rotateSpeed * Time.deltaTime);
            pitchedTurret = true;
        }
        if (Input.GetKeyDown("space") || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            fired = true;
        }

        angle = transform.localEulerAngles;

        if (angle.z > 45 && angle.z < 60)
        {
            angle.z = 45;
            pitchedTurret = false;
        }

        if (angle.z > 310 && angle.z < 360)
        {
            angle.z = 0;
            pitchedTurret = false;
        }

        transform.localEulerAngles = angle;

        if (pitchedTurret && Input.GetKey("up") && fired == false)
        {
            cannonBall.transform.RotateAround(transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if (pitchedTurret && Input.GetKey("down") && fired == false)
        {
            cannonBall.transform.RotateAround(transform.position, Vector3.forward, -rotateSpeed * Time.deltaTime);
        }

        if (scaleValue < 20 && fired == true)
            scaleValue += 2.0f;

        cannonBall.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }
}