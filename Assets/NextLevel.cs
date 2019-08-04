using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
   public Vector3 nextLevelStart;

   public void OnTriggerEnter(Collider other) {
       if(other.tag.Equals("Player")){
           GameObject.Find("Player").transform.position=nextLevelStart;
           GameObject.Find("Terrain Endless").GetComponent<GenerateEndlessRunner>().Regenerate();
           GameObject.Find("Player").GetComponent<Death>().respawnPoint = nextLevelStart;
           GameObject.Find("Player").GetComponent<Correr>().enabled = false;
           GameObject.Find("Player").GetComponent<Mover>().enabled = true;
        }
   }
}
