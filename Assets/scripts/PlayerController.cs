﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public float jumpForce;
    public CircleCollider2D groundChecker;
    public TopBarController topBarController;
    public BottomBarController bottomBarController;

    private bool onGround = false;
    private Rigidbody2D rb2d;
    private bool canOpenDoor = false;
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
        
        if (groundChecker.IsTouching(collision.collider))
        {
            onGround = true;
            rb2d.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("diamond"))
        {
            topBarController.addToScore(100);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("sphere"))
        {
            topBarController.addToScore(500);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("cup"))
        {
            topBarController.addToScore(1000);
            canOpenDoor = true;
            bottomBarController.showGoThroughTheDoorMessage();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("door") && canOpenDoor)
        {
            Debug.Log("Hurray, Level Finished");
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!groundChecker.IsTouching(collision.collider))
            onGround = false;
    }
}
