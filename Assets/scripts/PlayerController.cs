using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 100;
    public float jumpForce = .1f;

    private bool onGround = false;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.transform.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    //Jump
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    playerRigidBody.position = new Vector2(moveSpeed * Time.deltaTime,playerRigidBody.position.y);
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    playerRigidBody.position = new Vector2(- moveSpeed * Time.deltaTime, playerRigidBody.position.y);
        //}
        //else
        //{
        //   // playerRigidBody.velocity = Vector2.zero;
        //}
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(0,(float) Math.Ceiling(moveVertical));
        ////Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        if(onGround)
            rb2d.AddForce(movement * jumpForce);
        rb2d.velocity = new Vector2(moveHorizontal * speed * Time.deltaTime, rb2d.velocity.y);
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("walls"))
        {
            onGround = true;
            rb2d.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("walls"))
            onGround = false;
    }
}
