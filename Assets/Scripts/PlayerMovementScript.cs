using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 1500f;
    public LayerMask obstacleMask;
    private Rigidbody2D rb;
    public enum Direction{ North, South, East, West}
    public Direction movingDirection;
    bool movingHorizontal, canCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (movingHorizontal){
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1.1f, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1.1f, obstacleMask)) {
                canCheck = true;
            } else {
                canCheck = false;
            }
        } else {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1.1f, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1.1f, obstacleMask)) {
                canCheck = true;
            } else {
                canCheck = false;
            }
        }

        Debug.Log(canCheck);

        if (true)
        {

            if (Input.GetAxisRaw("Horizontal") != 0 && canMove()){
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                movingHorizontal = true;
                if (Input.GetAxisRaw("Horizontal") > 0){
                    movingDirection = Direction.East;
                } else {
                    movingDirection = Direction.West;
                }

            } else if (Input.GetAxisRaw("Vertical") != 0 && canMove()){
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                movingHorizontal = false;
                if (Input.GetAxisRaw("Vertical") > 0){
                    movingDirection = Direction.North;
                } else {
                    movingDirection = Direction.South;
                }
            }
        }
    }

    void FixedUpdate() 
    {


        switch(movingDirection){

            case Direction.North:
                rb.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
                break;
            case Direction.South:
                rb.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
                break;
            case Direction.East:
                rb.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
                break;
            case Direction.West:
                rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
                break;
        }
    }


    bool canMove(){

        if (rb.velocity.magnitude < 0.01f) {
            return true;
        } else { return false;}

    }
}