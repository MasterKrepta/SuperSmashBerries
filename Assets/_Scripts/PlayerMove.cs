﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 15f;
    public float JumpHeight = 10f;
    [SerializeField] float fallMulti = 10f;
    [SerializeField] float lowJumpMulti = 2f;
    
    

    public float GroundDistance = 0.2f;
    
    public LayerMask Ground;

    private Rigidbody rb;
    private Vector3 input = Vector3.zero;
    private bool _isGrounded = true;
    private Transform grounded;

    Vector3 originalPos;
    Quaternion origRot;

      void Start()
    {
        originalPos = transform.position;
        origRot = transform.rotation;

        rb = GetComponent<Rigidbody>();
        grounded = transform.GetChild(0);
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(grounded.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 30;
        }
        else
        {
            Speed = 15;
        }

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    GameTriggers.OnGameEnd();
        //}


    }


    private void ModifyVelocityWhenJumping()
    {

        if (rb.velocity.y < 0)
        {

            rb.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {

            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMulti - 1) * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (_isGrounded == false)
        {
            ModifyVelocityWhenJumping();
        }

        //rb.MovePosition(rb.position + input * Speed * Time.fixedDeltaTime);
    }

}
