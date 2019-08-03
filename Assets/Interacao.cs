﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao : MonoBehaviour
{
    public GameObject player;
    public GameObject monstro;
    public GameObject ObjNormal;
    public Transform transformMonstro;
    public Transform transformPlayer;
    public bool interage;
    public bool andaMonstro;
    public float monsterSpeed;
    void Start()
    {
       transformMonstro = monstro.GetComponent<Transform>();
       transformPlayer = player.GetComponent<Transform>();
    }

    void Update()
    {
        if(interage)
        {
            if( correParaEsquerda() == true)
            {

            }else
            {
                interage = false;
            }

        }
    }
    public void OnTriggerStay(Collider other) 
    {
       if(other.gameObject.tag.Equals("Normal"))
       {
           if(Input.GetKey(KeyCode.E))
           {
               interage = true;
               andaMonstro = true;
               monstro.SetActive(true); 
               player.GetComponent<Mover>().enabled = false;
           }   

       }else
       {
           interage = false;
       }
       
    }

        public bool correParaEsquerda()
    {
        if(andaMonstro == true)
        {
            //anda monstro
            Vector3 movement = new Vector3(-(0.2f) * monsterSpeed,0f,0f);
            transformMonstro.position += movement; 

            //anda player
            transformPlayer.position += movement;
        }
        return andaMonstro;
    }
   
}
