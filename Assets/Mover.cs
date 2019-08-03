using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float jumpStrength;
    public bool isJumping;
    public Transform tr;
    public Rigidbody rb;

    void Start()
    {
        tr=GetComponent<Transform>();
        rb=GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!isJumping){
            isJumping = true;
            rb.AddForce(new Vector3(0f, jumpStrength, 0f));
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed,0f,0f);
        tr.position += movement;
    }

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Terrain"){
            isJumping = false;
        }
    }
}