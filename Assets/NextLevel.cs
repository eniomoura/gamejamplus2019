using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
   public Vector3 nextLevelStart;
   
   public void OnTriggerEnter(Collider other) {
       if(other.tag.Equals("Player")){
           GameObject.Find("Player").transform.position=nextLevelStart;
       }
   }
}
