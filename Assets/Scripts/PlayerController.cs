using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb2d;
    private bool canMove = true;
    public float initialX, initialY = 0f;

    public float moveHorizontal;
    public float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb2d.velocity   = Vector2.zero;

        if ( canMove )
        {

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector2.up * speed * Time.deltaTime);
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
