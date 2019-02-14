﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 10;
    public float jump = 20;

    private bool isJumping;
    private float moveVelocity;
    public float threshold = 15.0f;
    public float downward = 20.0f;
    public static bool seed;
    public static bool plant;
    //private bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        seed = false;
        plant = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (!isJumping)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jump, 0);
                isJumping = true;
            }
        }

        moveVelocity = 0;

        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector3(moveVelocity, GetComponent<Rigidbody2D>().velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.P) && GameController.world1 == true)
        {
            plant = true;
        }
    }

    private void FixedUpdate()
    {
        if ((GetComponent<Rigidbody2D>().velocity.y) < threshold)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, -downward, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      isJumping=false; 

      }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seed"))
        {
            other.gameObject.SetActive(false);
            seed = true;
        }
        if (other.gameObject.CompareTag("PUWrld1"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.CompareTag("Jumpable"))
        {
            isJumping = false;
        }

    }
}
