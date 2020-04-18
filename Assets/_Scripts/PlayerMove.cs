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
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = transform.GetChild(0);
    }

    void Update()
    {
        
        _isGrounded = Physics.CheckSphere(grounded.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
            //rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        
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
        
        rb.MovePosition(rb.position + _inputs * Speed * Time.fixedDeltaTime);
    }

}
