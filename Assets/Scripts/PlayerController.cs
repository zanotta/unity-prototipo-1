using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.2f;
    private float currentX, currentY;
    private Rigidbody2D rb2d;
    private bool canMove = true;
    public float initialX, initialY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentX        = this.transform.position.x;
        currentY        = this.transform.position.y;
        //rb2d.velocity   = Vector2.zero;

        if ( canMove )
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb2d.MovePosition(new Vector2(currentX + speed, currentY));
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb2d.MovePosition(new Vector2(currentX, currentY + speed));
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb2d.MovePosition(new Vector2(currentX - speed, currentY));
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb2d.MovePosition(new Vector2(currentX, currentY - speed));
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                canMove = false;
                rb2d.MovePosition(new Vector2(initialX, initialY));
            break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMove = true;
    }
}
