using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEstranho : MonoBehaviour
{
    public GameObject player;
    public float startDistance;
    Transform translate;
    public Vector3 local;

    void Start()
    {
        translate = player.GetComponent<Transform>();
        print(translate);
    }

    void OnTriggerEnter(Collider Colisao){
        if(Colisao.gameObject.name == "Player"){
           
            translate.position += local;
        }
    }
}
