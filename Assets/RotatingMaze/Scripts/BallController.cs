using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BallController : MonoBehaviour
{
    public GameObject attractedTo;
    Rigidbody2D rb2D;
    public GameObject panel;
    public Vector3 spawnPoint;

    public void Awake()
    {
        spawnPoint = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(this.transform.position.y > 0)
        {
            rb2D.gravityScale = 1;
        }
        else if(this.transform.position.y < 0)
        {
            rb2D.gravityScale = -1;
        }
        */
        Vector3 moveDir = attractedTo.transform.position - transform.position;
        //Debug.Log(moveDir);
        rb2D.AddForce(moveDir * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("WinRegion"))
        {
            panel.SetActive(true);
        }
    }

    public void RespawnBall()
    {
        this.transform.position = spawnPoint;
    }
}
