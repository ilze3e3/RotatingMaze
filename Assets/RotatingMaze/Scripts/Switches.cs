using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    [System.Serializable]
    public class Wall
    {
        public GameObject wall;
        public string dir;
        public float angleToTurn;
        public float currAngle;
        public bool rotateStat;
        
        public Wall(GameObject _wall, string _dir, float _angle)
        {
            wall = _wall;
            dir = _dir;
            angleToTurn = _angle;
            currAngle = 0;
            rotateStat = false;
        }
    }

    List<Wall> wallsAffected;
    Vector3 rotatePoint;
    bool isTriggered = false;
    float angleToTurn;
    bool isWallOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        rotatePoint = this.GetComponentInParent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered && !isWallOpen)
        {
            foreach (Wall w in wallsAffected)
            {
                if (!w.rotateStat)
                {
                    w.currAngle += angleToTurn * Time.deltaTime;
                    if (w.dir.Contains("Right")) w.wall.transform.Rotate(Vector3.back * angleToTurn * Time.deltaTime);
                    else if (w.dir.Contains("Left")) w.wall.transform.Rotate(Vector3.forward * angleToTurn * Time.deltaTime);
                    if (w.currAngle >= angleToTurn)
                    {
                        w.rotateStat = true;
                        isWallOpen = true;
                        isTriggered = false;
                    }
                    else
                    {
                        isWallOpen = false;
                    }
                }                
            }
        }
        else if(isTriggered && isWallOpen)
        {
            foreach (Wall w in wallsAffected)
            {
                if (w.rotateStat)
                {
                    w.currAngle += angleToTurn * Time.deltaTime;
                    if (w.dir.Contains("Right")) w.wall.transform.Rotate(Vector3.forward * angleToTurn * Time.deltaTime);
                    else if (w.dir.Contains("Left")) w.wall.transform.Rotate(Vector3.back * angleToTurn * Time.deltaTime);
                    if (w.currAngle >= angleToTurn)
                    {
                        w.rotateStat = false;
                        isWallOpen = false;
                        isTriggered = false;
                    }
                    else
                    {
                        isWallOpen = true;
                    }
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isTriggered) isTriggered = true;
        if (isTriggered) isTriggered = false;
    }
}
