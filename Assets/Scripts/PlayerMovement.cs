using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private float x;
    private float z;
    private CharacterController controller;
    private Vector3 move;
    private float speed = 10f;
    private Vector3 velocity;
    private float gravity = -9.8f;

    private void Start(){
        controller = GetComponent<CharacterController>();
    }

    private void Update(){
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}