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
        trPlayer = player.GetComponent<Transform>();
    }

    void Update()
    {
        
    }

    public bool correParaEsquerda()
    {
        if(andaMonstro == true)
        {
            //anda monstro
            Vector3 movement = new Vector3(-(0.2f) * speed,0f,0f);
            tr.position += movement; 

            //anda player
            trPlayer.position += movement;
        }
        return andaMonstro;
    }
}
