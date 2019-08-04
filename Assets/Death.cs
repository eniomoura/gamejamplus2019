using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class Death : MonoBehaviour
{
    public List<GameObject> lives;
    public Vector3 respawnPoint;
    public float respawnStartDistance;

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Equals("Monstro")){
            if (lives.Count>1){
                GameObject lastLife = lives.Last();
                GameObject.Destroy(lastLife);
                lives.Remove(lastLife);
                Respawn();
            }else if(lives.Count==1){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    
    public void Respawn(){
        transform.position=respawnPoint;
        if(GetComponent<Correr>().direction>0){
            GameObject.Find("Monstro")
            .GetComponent<Transform>()
            .position = new Vector3(transform.position.x-respawnStartDistance,1,0f);
        }else{
           GetComponent<Correr>().enabled = false;
           GetComponent<Mover>().enabled = true;
        }
    }
}