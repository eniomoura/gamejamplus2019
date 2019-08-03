using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoNormal : MonoBehaviour
{
    public float speed;
    public GameObject monstro;
    public GameObject player;
    public Transform tr;
    public Transform trPlayer;

    public bool andaMonstro;
    void Start()
    {
        tr = monstro.GetComponent<Transform>();
        trPlayer = monstro.GetComponent<Transform>();
    }

    void Update()
    {
        if(andaMonstro == true)
        {
            //anda monstro
            Vector3 movement = new Vector3(-(0.2f) * speed,0f,0f);
            tr.position += movement; 

            //anda player
            trPlayer.position += movement;
        }
    }

    public void OnTriggerEnter(Collider other) 
    {
       if(other.gameObject.name.Equals("Player"))
       {
           monstro.SetActive(true);
           andaMonstro = true;     
           player.GetComponent<Mover>().enabled = false;     
       }

    }
}
