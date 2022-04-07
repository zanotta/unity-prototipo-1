using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool shouldRotate        = false;
    public bool shouldMove          = true;
    public string moveDirection     = "right";
    public float rotateSpeed        = 150f;
    public float moveSpeed          = 3f;
    private float currentX, currentY;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( shouldRotate )
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }

        if ( shouldMove )
        {
            currentX = this.transform.position.x;
            currentY = this.transform.position.y;


            switch ( moveDirection )
            {
                case "left":
                    rb2d.MovePosition(new Vector2(currentX - moveSpeed * Time.deltaTime, currentY));
                break;
                case "right":
                    rb2d.MovePosition(new Vector2(currentX + moveSpeed * Time.deltaTime, currentY));
                break;
                case "top":
                    rb2d.MovePosition(new Vector2(currentX, currentY + moveSpeed * Time.deltaTime));
                    break;
                case "bottom":
                    rb2d.MovePosition(new Vector2(currentX, currentY - moveSpeed * Time.deltaTime));
                break;
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ( collision.gameObject.tag == "Wall" )
        {
            switch (moveDirection)
            {
                case "left":    moveDirection = "right"; break;
                case "right":   moveDirection = "left"; break;
                case "top":     moveDirection = "bottom"; break;
                case "bottom":  moveDirection = "top"; break;
            }
        }
        
    }
}
