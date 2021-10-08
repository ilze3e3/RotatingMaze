using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Teleporter destination;
    public float rotationSpeed;
    public float angleToTurn;
    public bool justTeleported;
    [Tooltip("Is the ball being teleported between mazes.")] public bool betweenMazes; 
    IEnumerator RotateEffect()
    {
        while(true)
        {
            this.transform.Rotate(this.transform.forward * angleToTurn * rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator CountdownUntilNextTeleport()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            break;
        }

        justTeleported = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RotateEffect");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!destination.justTeleported)
        {
            Debug.Log(collision.name + "Triggered Teleporter");
            
            if(betweenMazes)
            {
                collision.transform.parent = destination.transform.parent;
                collision.GetComponent<BallController>().attractedTo = destination.transform.parent.gameObject;
            }
            collision.transform.position = destination.transform.position;
            justTeleported = true;
            
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine("CountdownUntilNextTeleport");
    }
}
