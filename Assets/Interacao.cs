using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao : MonoBehaviour
{
    public GameObject player;
    public GameObject monstro;
    public GameObject ObjNormal;
    public Transform transformMonstro;
    public Transform transformPlayer;
    public float monsterStartDistance;

    public float quantidadeMovimentoMonstro;
    void Start()
    {
       transformMonstro = monstro.GetComponent<Transform>();
       transformPlayer = player.GetComponent<Transform>();
    }

    public void OnTriggerStay(Collider other) 
    {
       if(other.gameObject.tag.Equals("Normal"))
       {
            monstro.GetComponent<Transform>().position = new Vector3(
            transformPlayer.position.x+monsterStartDistance,1,0f);
            monstro.SetActive(true);
            GameObject[] lareiras = GameObject.FindGameObjectsWithTag("Respawn");
            player.GetComponent<Mover>().enabled = false;
            Correr pc = player.GetComponent<Correr>();
            pc.direction = -1;
            pc.enabled = true;
            Correr mc = monstro.GetComponent<Correr>();
            mc.direction = -1;
            mc.enabled = true;
       }
    }   

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Estranho")){
           if(Input.GetKey(KeyCode.E))
           {
            Vector3 runnerStartPosition = new Vector3(
                transformPlayer.position.x+500,
                transformPlayer.position.y,
                transformPlayer.position.z);
            transformPlayer.position = runnerStartPosition;
            player.GetComponent<Mover>().enabled = false;
            player.GetComponent<Correr>().enabled = true;
            monstro.GetComponent<Transform>().position = new Vector3(
                transformPlayer.position.x-monsterStartDistance,1,0f);
            player.GetComponent<Death>().respawnPoint=runnerStartPosition;
            monstro.SetActive(true);
           }
        }
    }
}
