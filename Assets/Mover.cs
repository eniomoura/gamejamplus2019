﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float jumpStrength;
    public Vector3 originalShadowScale;
    public GameObject monster;
    public GameObject shadow;
    public Transform tr;
    public Rigidbody rb;

    void Start()
    {
        tr=GetComponent<Transform>();
        rb=GetComponent<Rigidbody>();
        shadow = GameObject.Find("Shadow");
        originalShadowScale = shadow.transform.localScale;
        rb.sleepThreshold=0;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed,0f,0f);
        tr.position += movement;
        shadow.transform.parent = GameObject.Find("Player").transform;
        shadow.transform.localPosition = new Vector3(0f,0f,-8);
        shadow.transform.localScale = originalShadowScale;
    }

    void LateUpdate() {
        monster.SetActive(false);
    }

    public void OnCollisionStay(Collision other) {
        if(Input.GetAxis("Jump")!=0){
            rb.velocity=new Vector3(rb.velocity.x, jumpStrength, rb.velocity.y);
        }
    }
}