﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correr : MonoBehaviour
{
    public float runSpeed;
    public float jumpStrength;
    public int direction;
    public Transform tr;
    public Rigidbody rb;
    public RuntimeAnimatorController runningAnimator;
    public RuntimeAnimatorController idleAnimator;
    public AudioClip runningTheme;

    void Start()
    {
        tr=GetComponent<Transform>();
        if(tag.Equals("Player")){
            rb=GetComponent<Rigidbody>();
        }
        rb.sleepThreshold=0;
        runningTheme = GameObject.Find("Main Camera").GetComponent<Sound>().audioClips[2];
    }

    void FixedUpdate()
    {

        if(!name.Equals("Monstro")){
            if(direction>0){
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().runtimeAnimatorController = runningAnimator;
            }else{
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().runtimeAnimatorController = runningAnimator;
            }
        }
        Vector3 movement = new Vector3(runSpeed*direction,0f,0f);
        tr.position += movement;
        if(name.Equals("Monstro")){
            GameObject.Find("Shadow").transform.parent = transform;
            GameObject.Find("Shadow").transform.localPosition = new Vector3(0f,0f,-8);
            GameObject.Find("Shadow").transform.localScale = new Vector3(350,200,1);
        }
    }

    public void OnCollisionStay(Collision other) {
        if(Input.GetAxis("Jump")!=0&&tag=="Player"&&!other.gameObject.tag.Equals("Unclimbable")){
            rb.velocity=new Vector3(rb.velocity.x, jumpStrength, rb.velocity.y);
        }
    }

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Respawn")){
           GetComponent<Mover>().enabled = true;
           enabled = false;
        }
    }
}
