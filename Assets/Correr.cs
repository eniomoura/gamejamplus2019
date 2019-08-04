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
        if(tag.Equals("Player")){
            rb=GetComponent<Rigidbody>();
        }
        rb.sleepThreshold=0;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(runSpeed*direction,0f,0f);
        tr.position += movement;
        if(name.Equals("Monstro")){
            GameObject.Find("Shadow").transform.parent = transform;
            GameObject.Find("Shadow").transform.localPosition = new Vector3(0f,0f,-8);
            GameObject.Find("Shadow").transform.localScale = new Vector3(350,200,1);
        }
    }

    public void OnCollisionStay(Collision other) {
        if(Input.GetAxis("Jump")!=0&&tag=="Player"){
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
