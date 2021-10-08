using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_MazeController : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            initialDirection = GetMouseDirection();
            marker.transform.position = initialDirection;
            //marker.transform.forward = marker.transform.right;
        }
        if(Input.GetMouseButton(0))
        {
            //marker.transform.LookAt(this.transform, Vector2.up);
            directionWhileHolding = GetMouseDirection();
            angleToTurn = Vector2.SignedAngle(marker.transform.position, directionWhileHolding);
            
            this.transform.Rotate(this.transform.forward * angleToTurn * rotationSpeed *  Time.deltaTime);
            
        }
    }

    private Vector2 GetMouseDirection()
    {
        return main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;

    }
}
