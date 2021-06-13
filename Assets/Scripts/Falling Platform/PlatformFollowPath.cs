using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollowPath : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1;
    Vector3 Move; 
    // Start is called before the first frame update
    void Start()
    {
        Move = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move.x += speed;
        this.transform.position = Move;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.CompareTag("Grounds"))
        {
            speed *= changeDirection;
        }
        if(collision.gameObject.tag =="Player") 
        {
            collision.transform.parent = transform;
        }
    }
    // public void OnCollisionEnter2D(Collision2D collision) 
    // {
    //     if(collision.gameObject.tag =="player") 
    //     {
    //         collision.transform.parent = transform;
    //     }
    // }
    public void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            collision.transform.parent = null;
        }
    }
}
