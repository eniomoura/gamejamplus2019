using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float jumpStrength;
    public Transform tr;
    public Rigidbody rb;

    void Start()
    {
        tr=GetComponent<Transform>();
        rb=GetComponent<Rigidbody>();
        rb.sleepThreshold=0;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed,0f,0f);
        tr.position += movement;
    }

    public void OnCollisionStay(Collision other) {
        if(Input.GetAxis("Jump")!=0){
            rb.velocity=new Vector3(rb.velocity.x, jumpStrength, rb.velocity.y);
        }
    }
}