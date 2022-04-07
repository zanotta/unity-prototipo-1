using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
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

        currentX = this.transform.position.x;
        currentY = this.transform.position.y;

        if (canMove)
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
                GameController.instance.increaseDeath();
                rb2d.MovePosition(new Vector2(initialX, initialY));
            break;
            case "Goal":
                canMove = false;
                GameController.instance.nextLevel();
            break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMove = true;
    }
}