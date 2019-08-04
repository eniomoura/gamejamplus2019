using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao : MonoBehaviour {
    public GameObject player;
    public GameObject monstro;
    public GameObject ObjNormal;
    public Transform transformMonstro;
    public Transform transformPlayer;
    public float monsterStartDistance;
    public bool isTeleporting;

    public float quantidadeMovimentoMonstro;
    void Start () {
        transformMonstro = monstro.GetComponent<Transform>();
        transformPlayer = player.GetComponent<Transform>();
    }

    public void OnTriggerStay (Collider other) {
        if (other.gameObject.tag.Equals ("Normal") && GetComponent<Mover>().enabled) {
            monstro.GetComponent<Transform>().position = new Vector3 (
                transformPlayer.position.x + monsterStartDistance, 1, 0f);
            monstro.SetActive (true);
            GameObject[] lareiras = GameObject.FindGameObjectsWithTag ("Respawn");
            player.GetComponent<Mover>().enabled = false;
            Correr pc = player.GetComponent<Correr>();
            pc.direction = -1;
            pc.enabled = true;
            Correr mc = monstro.GetComponent<Correr>();
            mc.direction = -1;
            mc.enabled = true;
        } else if (other.gameObject.tag.Equals  ("Estranho") && GetComponent<Mover>().enabled) {
            if (!isTeleporting) {
                try{
                    other.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                }catch(Exception){}
                if (Input.GetKey (KeyCode.E)) {
                    isTeleporting = true;
                    Vector3 runnerStartPosition = new Vector3 (
                        550,
                        transformPlayer.position.y,
                        transformPlayer.position.z);
                    transformPlayer.position = runnerStartPosition;
                    player.GetComponent<Mover>().enabled = false;
                    Correr pc = player.GetComponent<Correr>();
                    pc.direction = 1;
                    pc.enabled = true;
                    Correr mc = monstro.GetComponent<Correr>();
                    mc.direction = 1;
                    mc.enabled = true;
                    monstro.GetComponent<Transform>().position = new Vector3 (
                        transformPlayer.position.x - monsterStartDistance, 1, 0f);
                    player.GetComponent<Death>().respawnPoint = runnerStartPosition;
                    monstro.SetActive (true);
                }
            }
        } else if (other.gameObject.tag.Equals ("Neutro") && GetComponent<Mover>().enabled) {
            if (!isTeleporting) {
                try{
                    other.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                }catch(Exception){}
                if (Input.GetKey (KeyCode.E)) {
                    monstro.GetComponent<Transform>().position = new Vector3 (
                        transformPlayer.position.x + monsterStartDistance, 1, 0f);
                    monstro.SetActive (true);
                    GameObject[] lareiras = GameObject.FindGameObjectsWithTag ("Respawn");
                    player.GetComponent<Mover>().enabled = false;
                    Correr pc = player.GetComponent<Correr>();
                    pc.direction = -1;
                    pc.enabled = true;
                    Correr mc = monstro.GetComponent<Correr>();
                    mc.direction = -1;
                    mc.enabled = true;
                }
            }
        }
    }

    public void OnTriggerExit (Collider other) {
        isTeleporting = false;
        try{
            other.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        }catch(Exception){}
    }
}