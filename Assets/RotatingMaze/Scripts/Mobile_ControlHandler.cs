using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mobile_ControlHandler : MonoBehaviour
{
    public float angleToTurn;
    public Vector2 initialDirection;
    public Vector2 directionWhileHolding;
    public float rotationSpeed = 5;
    public GameObject marker;
    Camera main;

    private void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                initialDirection = GetTouchDirection();
                marker.transform.position = initialDirection;
                //marker.transform.forward = marker.transform.right;
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                //marker.transform.LookAt(this.transform, Vector2.up);
                directionWhileHolding = GetTouchDirection();
                angleToTurn = Vector2.SignedAngle(marker.transform.position, directionWhileHolding);

                this.transform.Rotate(this.transform.forward * angleToTurn * rotationSpeed * Time.deltaTime);

            }
        }
    }

    private Vector2 GetTouchDirection()
    {
        return main.ScreenToWorldPoint(Input.touches[0].position) - this.transform.position;

    }
}
