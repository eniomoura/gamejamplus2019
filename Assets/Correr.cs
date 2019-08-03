using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correr : MonoBehaviour
{
    public float runSpeed;
    public float jumpStrength;
    public int direction;
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
        Vector3 movement = new Vector3(runSpeed*direction,0f,0f);
        tr.position += movement;
    }

    public void OnCollisionStay(Collision other) {
        if(Input.GetAxis("Jump")!=0){
            rb.velocity=new Vector3(rb.velocity.x, jumpStrength, rb.velocity.y);
        }
    }
}
