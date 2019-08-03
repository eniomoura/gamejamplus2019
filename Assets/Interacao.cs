using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao : MonoBehaviour
{
    public GameObject player;
    public GameObject monstro;
    public GameObject ObjNormal;
    public bool interage;
    void Start()
    {
       
    }

    void Update()
    {
         Debug.Log(interage);
        if(interage)
        {
            Debug.Log("dentro");
            if( ObjNormal.GetComponent<ObjetoNormal>().correParaEsquerda() == true)
            {
                Debug.Log("To indo");

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
               monstro.SetActive(true); 
               player.GetComponent<Mover>().enabled = false; 
           }   

       }else
       {
           interage = false;
       }
       
    }
   
}
